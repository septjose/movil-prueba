using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using App1.Modelos;

namespace App1.WService
{
    class WSCarrera
    {
        HttpClient http;
        public async Task<List<Modelos.Carrera>> listaCarrera()
        {
            List<Modelos.Carrera> listaCarrera = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://localhost:59516/Service1.svc");

                var result = await http.GetAsync("/GetAllBachelors/");
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaCarrera = new List<Carrera>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("carrera").ToList();

                Carrera carrera;
                foreach (var car in arrJson)
                {
                    carrera = new Carrera();
                    carrera = JsonConvert.DeserializeObject<Carrera>(car.ToString());
                    listaCarrera.Add(carrera);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }
            return listaCarrera;
        }
    }
}
