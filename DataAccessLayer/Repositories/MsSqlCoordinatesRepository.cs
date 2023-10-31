using DataAccessLayer.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class MsSqlCoordinatesRepository : IRepository<Coordinate>
	{

		public async Task<int> CreateAsync(Coordinate item)
		{
			int responseId = -1;
			using (var sqlConnection = new SqlConnection(Configuration.GetConnectionString()))
			{
				await sqlConnection.OpenAsync();

				var parameters = CreateFullParamsForCoordinate(item);
				await SqlProcExecuteOnlyWithParams(sqlConnection, "CreateNewCoordinateProc", parameters);

				using (var sqlCommand = new SqlCommand("select Id from Coordinates where PointName = @pointName", sqlConnection))
				{
					sqlCommand.Parameters.Add(new SqlParameter("@pointName", item.PointName));
					using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
					{
						if (sqlReader.Read())
						{
							int.TryParse(sqlReader["Id"].ToString(), out responseId);
						}
					}
				}

				sqlConnection.Close();
			}

			return responseId;
		}

		public async Task UpdateAsync(Coordinate item)
		{
			using (var sqlConnection = new SqlConnection(Configuration.GetConnectionString()))
			{
				await sqlConnection.OpenAsync();

				var parameters = CreateFullParamsForCoordinate(item);
				await SqlProcExecuteOnlyWithParams(sqlConnection, "UpdateCoordinateProc", parameters);

				sqlConnection.Close();
			}
		}

		public async Task DeleteAsync(Coordinate item)
		{
			using (var sqlConnection = new SqlConnection(Configuration.GetConnectionString()))
			{
				await sqlConnection.OpenAsync();

				var parameters = CreateFullParamsForCoordinate(item);
				await SqlProcExecuteOnlyWithParams(sqlConnection, "DeleteCoordinateProc", parameters);

				sqlConnection.Close();
			}
		}

		public async Task<IEnumerable<Coordinate>> LoadAllAsync()
		{
			var coordinates = new List<Coordinate>();

			using (var sqlConnection = new SqlConnection(Configuration.GetConnectionString()))
			{
				await sqlConnection.OpenAsync();

				using (var sqlCommand = new SqlCommand("SelectTop1000Proc", sqlConnection))
				{
					sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
					using (var reader = await sqlCommand.ExecuteReaderAsync())
					{
						while (await reader.ReadAsync())
						{
							string pointName = reader["PointName"].ToString();
							double latitude = double.Parse(reader["Latitude"].ToString());
							double longitude = double.Parse(reader["Longitude"].ToString());

							coordinates.Add(new Coordinate(pointName, latitude, longitude));
						}
					}
				}

				sqlConnection.Close();
			}

			return coordinates;
		}

		public async Task InitializeDbAsync()
		{
			var initScripts = new List<string> { "InitialDataBaseQuery.sql", "InitialCoordinatesTableQuery.sql" };
			using (var sqlConnection = new SqlConnection(Configuration.GetConnectionString()))
			{
				await sqlConnection.OpenAsync();
				await SqlInitProcs(sqlConnection, initScripts[0]);
				await SqlInitProcs(sqlConnection, initScripts[1]);

				Configuration.ChangeDataBaseInConnectionString();
				sqlConnection.ChangeDatabase("FirstTask");

				var msSqlScriptsDir = new DirectoryInfo("MsSqlScripts");
				var sqlFiles = msSqlScriptsDir.GetFiles();
				foreach (var sqlFile in sqlFiles)
				{
					if (initScripts.Contains(sqlFile.Name))
					{
						continue;
					}

					await SqlInitProcs(sqlConnection, sqlFile.Name);
				}

				sqlConnection.Close();
			}
		}

		private async Task SqlInitProcs(SqlConnection sqlConnection, string procName)
		{
			string sqlQueryInitDb = File.ReadAllText($"MsSqlScripts\\{procName}");

			using (var sqlCommandInitDb = new SqlCommand(sqlQueryInitDb, sqlConnection))
			{
				await sqlCommandInitDb.ExecuteNonQueryAsync();
			}
		}

		private async Task SqlProcExecuteOnlyWithParams(SqlConnection sqlConnection, string procName, params SqlParameter[] sqlParameters)
		{
			using (var sqlCommand = new SqlCommand(procName, sqlConnection))
			{
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.Parameters.AddRange(sqlParameters);

				await sqlCommand.ExecuteNonQueryAsync();
			}
		}

		private SqlParameter[] CreateFullParamsForCoordinate(Coordinate item)
			=> new SqlParameter[]
			{
				new SqlParameter("@pointName", item.PointName),
				new SqlParameter("@latitude", item.Latitude),
				new SqlParameter("@longitude", item.Longitude)
			};
	}
}
