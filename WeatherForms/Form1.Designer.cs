namespace WeatherForms {
  partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      lblCity = new Label();
      lblWeather = new Label();
      lblTemperature = new Label();
      lblWind = new Label();
      lblPrecipitation = new Label();
      cbCity = new ComboBox();
      SuspendLayout();
      // 
      // lblCity
      // 
      lblCity.AutoSize = true;
      lblCity.Location = new Point(147, 84);
      lblCity.Name = "lblCity";
      lblCity.Size = new Size(28, 15);
      lblCity.TabIndex = 0;
      lblCity.Text = "City";
      // 
      // lblWeather
      // 
      lblWeather.AutoSize = true;
      lblWeather.Location = new Point(147, 116);
      lblWeather.Name = "lblWeather";
      lblWeather.Size = new Size(51, 15);
      lblWeather.TabIndex = 1;
      lblWeather.Text = "Weather";
      // 
      // lblTemperature
      // 
      lblTemperature.AutoSize = true;
      lblTemperature.Location = new Point(147, 148);
      lblTemperature.Name = "lblTemperature";
      lblTemperature.Size = new Size(73, 15);
      lblTemperature.TabIndex = 2;
      lblTemperature.Text = "Temperature";
      // 
      // lblWind
      // 
      lblWind.AutoSize = true;
      lblWind.Location = new Point(147, 181);
      lblWind.Name = "lblWind";
      lblWind.Size = new Size(35, 15);
      lblWind.TabIndex = 3;
      lblWind.Text = "Wind";
      lblWind.Click += label4_Click;
      // 
      // lblPrecipitation
      // 
      lblPrecipitation.AutoSize = true;
      lblPrecipitation.Location = new Point(147, 218);
      lblPrecipitation.Name = "lblPrecipitation";
      lblPrecipitation.Size = new Size(74, 15);
      lblPrecipitation.TabIndex = 4;
      lblPrecipitation.Text = "Precipitation";
      // 
      // cbCity
      // 
      cbCity.FormattingEnabled = true;
      cbCity.Items.AddRange(new object[] { "Ostrava", "Madrid", "Sydney", "Rome", "Reykjavík" });
      cbCity.Location = new Point(147, 40);
      cbCity.Name = "cbCity";
      cbCity.Size = new Size(121, 23);
      cbCity.TabIndex = 5;
      cbCity.SelectedIndexChanged += cbCity_SelectedIndexChanged;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(373, 309);
      Controls.Add(cbCity);
      Controls.Add(lblPrecipitation);
      Controls.Add(lblWind);
      Controls.Add(lblTemperature);
      Controls.Add(lblWeather);
      Controls.Add(lblCity);
      Name = "Form1";
      Text = "Form1";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lblCity;
    private Label lblWeather;
    private Label lblTemperature;
    private Label lblWind;
    private Label lblPrecipitation;
    private ComboBox cbCity;
  }
}