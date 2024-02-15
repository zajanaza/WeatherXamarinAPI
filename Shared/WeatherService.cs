using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Shared {
  public class WeatherService {
    //https://api.weatherapi.com/v1/current.json?key=61f76c71e11549e3bdd100033231312&q=London&aqi=no
    string apiKey = "61f76c71e11549e3bdd100033231312";
    IWeatherView weatherView;                                                     //datová složka rozhraní, pro odeslání dat do MainActivity do metody SetWeatherData

    public WeatherService(IWeatherView weatherView) {
      this.weatherView = weatherView;
    }

    public async Task GetWeatherForCityAsync(string city) {                          //získání info pro dané město, které je předáno parametrem
      var client = new HttpClient();
      var response = await client.GetAsync($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no");           //nátáhne info ve formátu JSON
      if (response.IsSuccessStatusCode) {
        var content = await response.Content.ReadAsStringAsync();                                     //uloží info do proměnné
        var weatherModel = JsonConvert.DeserializeObject<WeatherModel>(content);
        System.Diagnostics.Debug.WriteLine($"{weatherModel.Location.Name}: temperature: {weatherModel.Current.Temp_c}");
        weatherView.SetWeatherData(weatherModel);                                                   //pošle natažená data do Main do SetWeatherData (přes parametr závorce)

      }
    }
    
  } 
}
