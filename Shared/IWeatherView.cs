using System;
using System.Collections.Generic;
using System.Text;

namespace Shared {                                     //rozhraní obsahující metodu, kterou bude implementovat MainActivity
  public interface IWeatherView {
    void SetWeatherData(WeatherModel model);  
  }
}
