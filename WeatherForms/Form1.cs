

using Shared;

namespace WeatherForms {
  public partial class Form1 : Form, IWeatherView {
    WeatherService weatherService;
    public Form1() {
      InitializeComponent();
      weatherService = new WeatherService(this);
    }

    private void label4_Click(object sender, EventArgs e) {
    }

    private async void cbCity_SelectedIndexChanged(object sender, EventArgs e) {
      string city = cbCity.SelectedItem.ToString();
      await weatherService.GetWeatherForCityAsync(city);              //díky implementaci IWeatherView
    }

    public void SetWeatherData(WeatherModel model) {                 //díky implementaci IWeatherView
      lblCity.Text = model.Location.Name;
      lblPrecipitation.Text = $"Precipitation: {model.Current.Precip_mm} mm";
      lblTemperature.Text = $"{model.Current.Condition.Text}";
      lblWeather.Text = $"{model.Current.Condition.Text}";
      lblWind.Text = $"{model.Current.Wind_dir} {model.Current.Wind_kph} km/h";
    }
  }
}