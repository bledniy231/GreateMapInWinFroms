using GMap.NET.WindowsForms;
using System;
using System.Windows.Forms;

namespace FirstTask.Forms
{
	public partial class MarkerInfoForm : Form
	{
		private readonly GMapMarker _marker;

		public MarkerInfoForm(GMapMarker marker)
		{
			InitializeComponent();
			pointNameLabelForFill.Text = marker.ToolTipText;
			latitudeLabelForFill.Text = marker.Position.Lat.ToString();
			longitudeLabelForFill.Text = marker.Position.Lng.ToString();
			_marker = marker;
		}

		private void DeletePointFromMapButton_Click(object sender, EventArgs e)
		{
			var response = MessageBox.Show("Удалить точку?", "Внимание!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (response == DialogResult.Yes)
			{
				DeletePointClicked?.Invoke(_marker);
			}

			Close();
		}

		private void ExitPointInfoFormButton_Click(object sender, EventArgs e)
			=> Close();

		public event Action<GMapMarker> DeletePointClicked;
	}
}
