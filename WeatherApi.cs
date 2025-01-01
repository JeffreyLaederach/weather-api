using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WeatherAPI
{
    class WeatherApi
    {
        internal static async Task ApiFunctionAsync()
        {
            // using HttpClient client = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "API_KEY_GOES_HERE");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            var body = await response.Content.ReadAsStringAsync(); // From the URL query code above 

            dynamic weather = JsonConvert.DeserializeObject(body);

            // General location and time info
            Console.WriteLine($"Address: {weather.resolvedAddress}");
            Console.WriteLine($"Time Zone: {weather.timezone}");
            Console.WriteLine($"Time Zone Offset: {weather.tzoffset}");

            // Loop through every "day" in the JSON and print specified details
            foreach (var day in weather.days)
            {
                string weather_date = day.datetime;
                string weather_desc = day.description;
                string weather_cond = day.conditions;
                string weather_tmax = day.tempmax;
                string weather_tmin = day.tempmin;
                string weather_tavg = day.temp;
                string weather_dew = day.dew;
                string weather_hum = day.humidity;
                string weather_pressure = day.pressure;
                string weather_precip = day.precip;
                string weather_precipprob = day.precipprob;
                string weather_windspeed = day.windspeed;
                string weather_winddir = day.winddir;
                string weather_cloudcover = day.cloudcover;
                string weather_uvindex = day.uvindex;
                string weather_solarradiation = day.solarradiation;
                string weather_solarenergy = day.solarenergy;

                Console.WriteLine($"\n Forecast for Date: {weather_date}");
                Console.WriteLine($" General Conditions: {weather_desc}");
                Console.WriteLine($" Conditions: {weather_cond}");
                Console.WriteLine($" The High Temperature will be: {weather_tmax}");
                Console.WriteLine($" The Low Temperature will be: {weather_tmin}");
                Console.WriteLine($" Average Temperature: {weather_tavg}");
                Console.WriteLine($" Dew Point: {weather_dew}");
                Console.WriteLine($" External Relative Humidity: {weather_hum} %");
                Console.WriteLine($" Pressure at Sea Level: {weather_pressure} mb");
                Console.WriteLine($" Precipitation: {weather_precip} inches");
                Console.WriteLine($" Chance of Precipitation: {weather_precipprob} %");
                Console.WriteLine($" Wind Speed: {weather_windspeed} mph");
                Console.WriteLine($" Wind Direction: {weather_winddir} degrees");
                Console.WriteLine($" Cloud Cover: {weather_cloudcover} %");
                Console.WriteLine($" UV Index: {weather_uvindex}");
                Console.WriteLine($" Solar Radiation: {weather_solarradiation} W/m^2");
                Console.WriteLine($" Solar Energy: {weather_solarenergy} MJ/m^2\n");
            }
        }
    }
}
