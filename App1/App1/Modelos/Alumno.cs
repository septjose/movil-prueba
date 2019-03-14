using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Modelos
{
    class Alumno
    {
        public String id_alumno { get; set; }
        public String nombre { get; set; }
        public String a_paterno { get; set; }
        public String a_materno { get; set; }
        public String edad { get; set; }
        public Carrera carrera { get; set; }
    }
}
