using DataAccessLayer;
using DataAccessLayer.Domain;
using FirstTask.Forms;
using GMap.NET.WindowsForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FirstTask
{
	public partial class MainForm : Form
	{
		private GMapMarker _selectedMarkerForDragAndDrop;
		private bool _isDragging = false;
		private readonly IRepository<Coordinate> _coordinatesRepository = new MsSqlCoordinatesRepository();

		public MainForm()
		{
			InitializeComponent();
		}

		private async void GMapControl_LoadAsync(object sender, EventArgs e)
		{
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
			gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
			gMapControl.MinZoom = 2;
			gMapControl.MaxZoom = 19;
			gMapControl.Zoom = 10;
			gMapControl.Position = new GMap.NET.PointLatLng(55.163491061033234, 61.416926896980414);
			gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			gMapControl.CanDragMap = true;
			gMapControl.DragButton = MouseButtons.Left;
			gMapControl.ShowCenter = false;
			gMapControl.ShowTileGridLines = false;
			gMapControl.OnMarkerClick += GMapControl_OnMarkerClick;
			gMapControl.MouseDown += GMapControl_MouseDown;
			gMapControl.MouseUp += GMapControl_MouseUp;
			gMapControl.MouseMove += GMapControl_MouseMove;


			await _coordinatesRepository.InitializeDbAsync();
			var points = await _coordinatesRepository.LoadAllAsync();
			var overlayWithMarkers = OverlayMarkers.GetOverlayWithMarkers(points.ToList(), "Markers");

			gMapControl.Overlays.Add(overlayWithMarkers);
		}

		private void GMapControl_MouseDown(object sender, MouseEventArgs e)
		{
			_selectedMarkerForDragAndDrop = gMapControl.Overlays
				.SelectMany(o => o.Markers)
				.FirstOrDefault(m => m.IsMouseOver == true);

			_isDragging = e.Button == MouseButtons.Left && _selectedMarkerForDragAndDrop != null;
		}


		private void GMapControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (_isDragging)
			{
				_selectedMarkerForDragAndDrop.Position = gMapControl.FromLocalToLatLng(e.X, e.Y);
			}
		}

		private async void GMapControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (_selectedMarkerForDragAndDrop == null || !_isDragging)
			{
				return;
			}

			var latlng = gMapControl.FromLocalToLatLng(e.X, e.Y);
			_selectedMarkerForDragAndDrop.Position = latlng;

			var coordModel = new Coordinate(_selectedMarkerForDragAndDrop.ToolTipText, latlng.Lat, latlng.Lng);
			await _coordinatesRepository.UpdateAsync(coordModel);

			_selectedMarkerForDragAndDrop = null;
			_isDragging = false;
		}



		private void GMapControl_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}

			using (var markerInfoForm = new MarkerInfoForm(marker))
			{
				markerInfoForm.DeletePointClicked += MarkerInfoForm_DeletePointClicked;
				markerInfoForm.ShowDialog();
			}
		}

		private async void MarkerInfoForm_DeletePointClicked(GMapMarker marker)
		{
			var coordModel = new Coordinate(marker.ToolTipText, marker.Position.Lat, marker.Position.Lng);
			await _coordinatesRepository.DeleteAsync(coordModel);
			gMapControl.Overlays.FirstOrDefault(ov => ov.Id.Equals(marker.Overlay.Id))?.Markers.Remove(marker);
			gMapControl.Update();
		}

		private void LongitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
			=> e.Handled = KeyPressValidation(longitudeTextBox, e.KeyChar);


		private void LatitudeTextBox_KeyPress(object sender, KeyPressEventArgs e)
			=> e.Handled = KeyPressValidation(latitudeTextBox, e.KeyChar);

		private bool KeyPressValidation(TextBox textBox, char letter)
		{
			switch (letter)
			{
				case '-':
					return textBox.Text.Length != 0 || textBox.Text.Contains("-") || textBox.Text.Contains(",");
				case ',':
					return textBox.Text.Length == 0 || textBox.Text.Contains(",");
				case (char)8:
					return false;
				default:
					return !char.IsDigit(letter);
			}
		}

		private async void AddCoordButton_ClickAsync(object sender, EventArgs e)
		{
			if (!TryParseLatitude(latitudeTextBox.Text, out var latitudeDouble) 
				|| !TryParseLongitude(longitudeTextBox.Text, out var longitudeDouble))
			{
				MessageBox.Show("Введены не корректные координаты!", "Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				latitudeTextBox.Clear();
				longitudeTextBox.Clear();
				pointNameTextBox.Clear();

				return;
			}

			var coord = new Coordinate(pointNameTextBox.Text, latitudeDouble, longitudeDouble);
			var inputMarker = OverlayMarkers.GetOneGoogleMarker(coord);

			if (gMapControl.Overlays.Count == 0)
			{
				var newOverlay = new GMapOverlay("Markers");
				newOverlay.Markers.Add(inputMarker);
				gMapControl.Overlays.Add(newOverlay);

				_ = await _coordinatesRepository.CreateAsync(coord);
			}
			else
			{
				gMapControl.Overlays.FirstOrDefault(ov => ov.Id.Equals("Markers")).Markers.Add(inputMarker);
				_ = await _coordinatesRepository.CreateAsync(coord);
			}

			gMapControl.Update();
			latitudeTextBox.Clear();
			longitudeTextBox.Clear();
			pointNameTextBox.Clear();
		}

		private bool TryParseLatitude(string latitudeString, out double latitudeDouble)
			=> double.TryParse(latitudeString, out latitudeDouble) && (latitudeDouble >= -90 && latitudeDouble <= 90);


		private bool TryParseLongitude(string longitudeString, out double longitudeDouble)
			=> double.TryParse(longitudeString, out longitudeDouble) && (longitudeDouble >= -180 && longitudeDouble <= 180);
	}
}
