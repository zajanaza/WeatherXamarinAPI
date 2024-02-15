using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WeatherApiApp {
  [Activity(Label = "CitiesActivity")]
  public class CitiesActivity : Activity {
    TextView tvOstrava;
    TextView tvMadrid;
    TextView tvRome;
    TextView tvSydney;
    TextView tvReykjavik;
    TextInputEditText editTextSearch;
    Button btnSearch;

    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.cities_layout);          //nasazení Layoutu zobrazení
      SetupReference();
      SubscribeEventHandlers();
    }

    private void SubscribeEventHandlers() {
      tvOstrava.Click += TvOstrava_Click;
      tvMadrid.Click += TvMadrid_Click;
      tvRome.Click += TvRome_Click;
      tvSydney.Click += TvSydney_Click;
      tvReykjavik.Click += TvReykjavik_Click;
      btnSearch.Click += BtnSearch_Click;
      
    }

    private void BtnSearch_Click(object sender, EventArgs e) {      //načte zapsané město (bez diakritiky)
      SendBackCityName(RemoveAccents(editTextSearch.Text));
    }

    private void TvReykjavik_Click(object sender, EventArgs e) {
      SendBackCityName("Reykjavík");
    }

    private void SendBackCityName(string city) {
      var intent = new Intent();
      intent.PutExtra("City", city);                                  // vrací zpět výsledek jméno města
      SetResult(Result.Ok, intent);
      Finish();
    }

    private void TvSydney_Click(object sender, EventArgs e) {
      SendBackCityName("Skarsvag");
    }

    private void TvRome_Click(object sender, EventArgs e) {
      SendBackCityName("Praha");
    }

    private void TvMadrid_Click(object sender, EventArgs e) {
      SendBackCityName("Madrid");
    }

    private void TvOstrava_Click(object sender, EventArgs e) {
      SendBackCityName("El Vellon");
    }

    private void SetupReference() {
      tvOstrava = FindViewById<TextView>(Resource.Id.textViewOstrava);
      tvMadrid = FindViewById<TextView>(Resource.Id.textViewMadrid);
      tvRome = FindViewById<TextView>(Resource.Id.textViewRome);
      tvSydney = FindViewById<TextView>(Resource.Id.textViewSydney);
      tvReykjavik = FindViewById<TextView>(Resource.Id.textViewReykjavík);
      editTextSearch = FindViewById<TextInputEditText>(Resource.Id.textInputSearch);
      btnSearch = FindViewById<Button>(Resource.Id.buttonSearch);
    }
    public static string RemoveAccents(string text) {                     // metoda pro odstranění diakritiky
      StringBuilder sbReturn = new StringBuilder(); var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray(); foreach (char letter in arrayText) {
        if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
          sbReturn.Append(letter);
      }
      return sbReturn.ToString();
    }
  }
}