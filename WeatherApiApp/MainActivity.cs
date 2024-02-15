using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Shared;
using System;
using System.Threading.Tasks;

namespace WeatherApiApp {
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
  //MainLauncher true určuje, co startuje první
  public class MainActivity : AppCompatActivity, IWeatherView {
    Button btnChangeCity;          //deklarace proměnných
    ImageView imgViewWeather;
    TextView tvCity;
    TextView tvWeather;
    TextView tvTemperature;
    TextView tvWind;
    TextView tvPrecipitation;
    WeatherService weatherService;
    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.activity_main);               //nasazení Layoutu zobrazení
      SetupReference();                                           //volání inicializační metody
      SubscribeEventHandlers();                                  //volání metody pro inicializaci metod událostí
      weatherService = new WeatherService(this);
    }

    private void SubscribeEventHandlers() {                    //inicializace metod událostí
      btnChangeCity.Click += BtnChangeCity_Click;
    }

    private void BtnChangeCity_Click(object sender, EventArgs e) {                //metoda události
      var intent = new Intent(this, typeof(CitiesActivity));                      // do intent je uložená aktivita
      StartActivityForResult(intent, 1);                                          // pod číslem 1 se pak bude vracet výsledek aktivity uložené v intent                                                                                  
    }

    private void SetupReference() {                                          // inicializační metoda
      btnChangeCity = FindViewById<Button>(Resource.Id.buttonChangeCity);
      imgViewWeather = FindViewById<ImageView>(Resource.Id.imageViewWeatherPicture);
      tvCity = FindViewById<TextView>(Resource.Id.textViewCityName);
      tvWeather = FindViewById<TextView>(Resource.Id.textViewWeather);
      tvTemperature = FindViewById <TextView> (Resource.Id.textViewTemperature);
      tvWind = FindViewById<TextView>(Resource.Id.textViewWind);
      tvPrecipitation = FindViewById<TextView>(Resource.Id.textViewPrecipitation);
    }

    protected override async void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {         // metoda pro zachycení výsledky z TvRekjavik_Click
      base.OnActivityResult(requestCode, resultCode, data);
      if (requestCode == 1 && resultCode==Result.Ok) {                                    // kontroluje příchozi data a číslo aktivity
        string city = data.GetStringExtra("City");                                        // zachycení dat pomocí nastaveného klíče "City"
        tvCity.Text = city;                                                               // uložení příchozích dat do textView
        await weatherService.GetWeatherForCityAsync(city);                                //natáhne a uloží info o danném město
        
      }
    }
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    public async void SetWeatherData(WeatherModel model) {
      tvCity.Text = model.Location.Name;
      tvPrecipitation.Text = $"{model.Current.Precip_mm} mm";
      tvTemperature.Text = $"{model.Current.Temp_c} °C";
      tvWeather.Text = model.Current.Condition.Text;
      tvWind.Text = $"{model.Current.Wind_dir} {model.Current.Wind_kph} km/h ";
      imgViewWeather.SetImageBitmap(await GetImageBitmapFromUrlAsync(@$"https:{model.Current.Condition.Icon}"));           //natáhne se obrázek pomocí
    }
    private async Task<Bitmap> GetImageBitmapFromUrlAsync(string url) {                   //pro stažení obrázku, který je natažený také ve WeatherModelu (odkaz)
      Bitmap imageBitmap = null;
      using (var httpClient = new System.Net.Http.HttpClient()) { //přidat do References System.Net.Http
        var imageBytes = await httpClient.GetByteArrayAsync(url);
        if (imageBytes != null && imageBytes.Length > 0) {
          imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
        }
      }
      return imageBitmap;
    }
  }
}