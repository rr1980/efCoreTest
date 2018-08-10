using Microsoft.AspNetCore.Mvc;
using RR_Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IBenutzerRepository _benutzerRepository;

        public SampleDataController(IBenutzerRepository benutzerRepository)
        {
            _benutzerRepository = benutzerRepository;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts()
        {
            //var benutzer1 = new Benutzer()
            //{
            //    UserName = "rr1980",
            //    Passwort = "12345",
            //};

            //var benutzer2 = new Benutzer()
            //{
            //    UserName = "rr1980_3",
            //    Passwort = "12345",
            //};

            //var p = new Person()
            //{
            //    Name = "Riesner",
            //    Vorname = "Rene",
            //    Adresse = new Adresse()
            //    {
            //        Plz = "15344",
            //        Ort = "Strausberg"
            //    }
            //};


            //benutzer1.Person = p;
            //benutzer2.Person = p;

            //try
            //{
            //    await _benutzerRepository.Add(benutzer1);
            //}
            //catch
            //{
            //    await _benutzerRepository.Add(benutzer2);
            //}

            //var reuslt = (await _benutzerRepository.GetAll()).ToList();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
