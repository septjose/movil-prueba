using App1.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Vistas
{
    class MenuDataOptions : List<MenuOpcion>
    {
        public MenuDataOptions()
        {
            this.Add(new MenuOpcion()
            {
                Title = "Inicio",
                IconSource = "iconoInicio.png",
                TargetType = typeof(Alumno),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Alumno",
                IconSource = "iconoBuzon.png",
                TargetType = typeof(Alumno),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Carrera",
                IconSource = "iconoCorreo.png",
                TargetType = typeof(Carrera),
            });
        }
    }
}
