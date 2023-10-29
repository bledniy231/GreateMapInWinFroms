namespace FirstTask
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.longitudeTextBox = new System.Windows.Forms.TextBox();
			this.longitudeLabel = new System.Windows.Forms.Label();
			this.pointNameTextBox = new System.Windows.Forms.TextBox();
			this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.pointNameLable = new System.Windows.Forms.Label();
			this.latitudeTextBox = new System.Windows.Forms.TextBox();
			this.latitudeLabel = new System.Windows.Forms.Label();
			this.addCoordButton = new System.Windows.Forms.Button();
			this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
			this.TableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// longitudeTextBox
			// 
			this.longitudeTextBox.AllowDrop = true;
			this.longitudeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.longitudeTextBox.Location = new System.Drawing.Point(305, 20);
			this.longitudeTextBox.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.longitudeTextBox.Name = "longitudeTextBox";
			this.longitudeTextBox.Size = new System.Drawing.Size(161, 22);
			this.longitudeTextBox.TabIndex = 1;
			this.longitudeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LongitudeTextBox_KeyPress);
			// 
			// longitudeLabel
			// 
			this.longitudeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.longitudeLabel.AutoSize = true;
			this.longitudeLabel.Location = new System.Drawing.Point(238, 22);
			this.longitudeLabel.Name = "longitudeLabel";
			this.longitudeLabel.Size = new System.Drawing.Size(61, 16);
			this.longitudeLabel.TabIndex = 2;
			this.longitudeLabel.Text = "Долгота";
			// 
			// pointNameTextBox
			// 
			this.pointNameTextBox.AllowDrop = true;
			this.pointNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pointNameTextBox.Location = new System.Drawing.Point(592, 20);
			this.pointNameTextBox.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.pointNameTextBox.Name = "pointNameTextBox";
			this.pointNameTextBox.Size = new System.Drawing.Size(161, 22);
			this.pointNameTextBox.TabIndex = 7;
			// 
			// TableLayoutPanel
			// 
			this.TableLayoutPanel.ColumnCount = 7;
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.853762F));
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61261F));
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.853762F));
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61261F));
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.8385F));
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61261F));
			this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61613F));
			this.TableLayoutPanel.Controls.Add(this.pointNameLable, 4, 0);
			this.TableLayoutPanel.Controls.Add(this.latitudeTextBox, 1, 0);
			this.TableLayoutPanel.Controls.Add(this.latitudeLabel, 0, 0);
			this.TableLayoutPanel.Controls.Add(this.longitudeLabel, 2, 0);
			this.TableLayoutPanel.Controls.Add(this.pointNameTextBox, 5, 0);
			this.TableLayoutPanel.Controls.Add(this.longitudeTextBox, 3, 0);
			this.TableLayoutPanel.Controls.Add(this.addCoordButton, 6, 0);
			this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TableLayoutPanel.Location = new System.Drawing.Point(0, 468);
			this.TableLayoutPanel.Name = "TableLayoutPanel";
			this.TableLayoutPanel.RowCount = 1;
			this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TableLayoutPanel.Size = new System.Drawing.Size(917, 60);
			this.TableLayoutPanel.TabIndex = 8;
			// 
			// pointNameLable
			// 
			this.pointNameLable.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pointNameLable.AutoSize = true;
			this.pointNameLable.Location = new System.Drawing.Point(472, 22);
			this.pointNameLable.Name = "pointNameLable";
			this.pointNameLable.Size = new System.Drawing.Size(114, 16);
			this.pointNameLable.TabIndex = 10;
			this.pointNameLable.Text = "Название точки";
			// 
			// latitudeTextBox
			// 
			this.latitudeTextBox.AllowDrop = true;
			this.latitudeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.latitudeTextBox.Location = new System.Drawing.Point(72, 20);
			this.latitudeTextBox.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.latitudeTextBox.Name = "latitudeTextBox";
			this.latitudeTextBox.Size = new System.Drawing.Size(161, 22);
			this.latitudeTextBox.TabIndex = 9;
			this.latitudeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LatitudeTextBox_KeyPress);
			// 
			// latitudeLabel
			// 
			this.latitudeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.latitudeLabel.AutoSize = true;
			this.latitudeLabel.Location = new System.Drawing.Point(7, 22);
			this.latitudeLabel.Name = "latitudeLabel";
			this.latitudeLabel.Size = new System.Drawing.Size(57, 16);
			this.latitudeLabel.TabIndex = 8;
			this.latitudeLabel.Text = "Широта";
			// 
			// addCoordButton
			// 
			this.addCoordButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.addCoordButton.Location = new System.Drawing.Point(756, 3);
			this.addCoordButton.Name = "addCoordButton";
			this.addCoordButton.Size = new System.Drawing.Size(158, 54);
			this.addCoordButton.TabIndex = 11;
			this.addCoordButton.Text = "Добавить точку";
			this.addCoordButton.UseVisualStyleBackColor = true;
			this.addCoordButton.Click += new System.EventHandler(this.AddCoordButton_ClickAsync);
			// 
			// gMapControl
			// 
			this.gMapControl.Bearing = 0F;
			this.gMapControl.CanDragMap = true;
			this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
			this.gMapControl.GrayScaleMode = false;
			this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gMapControl.LevelsKeepInMemory = 5;
			this.gMapControl.Location = new System.Drawing.Point(0, 0);
			this.gMapControl.MarkersEnabled = true;
			this.gMapControl.MaxZoom = 2;
			this.gMapControl.MinZoom = 2;
			this.gMapControl.MouseWheelZoomEnabled = true;
			this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gMapControl.Name = "gMapControl";
			this.gMapControl.NegativeMode = false;
			this.gMapControl.PolygonsEnabled = true;
			this.gMapControl.RetryLoadTile = 0;
			this.gMapControl.RoutesEnabled = true;
			this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gMapControl.ShowTileGridLines = false;
			this.gMapControl.Size = new System.Drawing.Size(917, 468);
			this.gMapControl.TabIndex = 9;
			this.gMapControl.Zoom = 0D;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(917, 528);
			this.Controls.Add(this.gMapControl);
			this.Controls.Add(this.TableLayoutPanel);
			this.MinimumSize = new System.Drawing.Size(935, 575);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Карта техники";
			this.Load += new System.EventHandler(this.GMapControl_LoadAsync);
			this.TableLayoutPanel.ResumeLayout(false);
			this.TableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox longitudeTextBox;
		private System.Windows.Forms.Label longitudeLabel;
		private System.Windows.Forms.TextBox pointNameTextBox;
		private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
		private System.Windows.Forms.Label latitudeLabel;
		private System.Windows.Forms.TextBox latitudeTextBox;
		private System.Windows.Forms.Label pointNameLable;
		private System.Windows.Forms.Button addCoordButton;
		private GMap.NET.WindowsForms.GMapControl gMapControl;
	}
}

