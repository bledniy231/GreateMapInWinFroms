namespace DataAccessLayer.Models
{
	public class CoordinateModel
	{
		public CoordinateModel(string pointName, double latitude, double longitude)
		{
			PointName = pointName;
			Latitude = latitude;
			Longitude = longitude;
		}

		public string PointName { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
