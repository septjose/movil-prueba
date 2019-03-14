using App1.Modelos;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1.WService
{
    class WSAlumno
    {
        HttpClient http;
        public async Task<List<Modelos.Alumno>> listaAlumno()
        {
            List<Modelos.Alumno> listaCarrera = null;
            try
            {
                http = new HttpClient();
                http.BaseAddress = new Uri("http://localhost:59516/Service1.svc");

                var result = await http.GetAsync("/GetAllStudents/");
                var cadena = result.Content.ReadAsStringAsync().Result;
                listaCarrera = new List<Alumno>();
                var objJson = JObject.Parse(cadena);
                var arrJson = objJson.SelectToken("alumno").ToList();

                Alumno alumno;
                foreach (var car in arrJson)
                {
                    alumno = new Alumno();
                    alumno = JsonConvert.DeserializeObject<Alumno>(car.ToString());
                    listaCarrera.Add(alumno);
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
