using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using DataAccessLayer.Models;
using System.Collections.Generic;

namespace FirstTask
{
	public static class OverlayMarkers
	{
		public static GMapOverlay GetOverlayWithMarkers(List<CoordinateModel> coordinates, string overlayId, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
		{
			GMapOverlay gMapMarkers = new GMapOverlay(overlayId);
			coordinates.ForEach(coord => gMapMarkers.Markers.Add(GetOneGoogleMarker(coord)));
			return gMapMarkers;
		}

		public static GMarkerGoogle GetOneGoogleMarker(CoordinateModel coord, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
		{
			GMarkerGoogle mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(coord.Latitude, coord.Longitude), gMarkerGoogleType);
			mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker); // всплывающее окно с инфой к маркеру
			mapMarker.ToolTipText = coord.PointName; // текст внутри всплывающего окна
			mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver; // отображение всплывающего окна (при наведении)
			return mapMarker;
		}
	}
}
