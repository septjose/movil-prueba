using App1.WService;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Vistas
{
    class Alumno : ContentPage
    {
        private ListView lv_alumno;
        private List<Modelos.Alumno> list_alumno;
        private WSAlumno objWSAlumno;
        public Alumno()
        {
            list_alumno = new List<Modelos.Alumno>();
            objWSAlumno = new WSAlumno();
            Title = "Alumnos";
            Label lblNombre = new Label
            {
                Text = "nombre",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };
            Label lblAPaterno = new Label
            {
                Text = "Apellido paterno",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };

            Label lblAMaterno = new Label
            {
                Text = "Apellido Materno",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };

            Label lblEdad = new Label
            {
                Text = "Edad",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };

            Label lblCarrera = new Label
            {
                Text = "Carrera",
                TextColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 35,
            };


            StackLayout stkCarga1 = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#2196F3"),
                Children = {
                    lblNombre,
                    lblAPaterno,
                    lblAMaterno,
                    lblEdad,
                }
            };
            lv_alumno = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(ResultCellAlumno))
            };
            StackLayout st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    stkCarga1,
                    lv_alumno
                }
            };
            Content = st_inst;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                list_alumno = await objWSAlumno.listaAlumno();
                lv_alumno.ItemsSource = list_alumno;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }
        }
    }
    class ResultCellAlumno : ViewCell
    {
        public ResultCellAlumno()
        {
            var lblNombre = new Label()
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblNombre.SetBinding(Label.TextProperty, "Nombre");
            var lblAPaterno = new Label
            {
                FontSize = 10,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblAPaterno.SetBinding(Label.TextProperty, "Apellido Paterno");

            var lblAMaterno = new Label
            {
                FontSize = 10,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblAMaterno.SetBinding(Label.TextProperty, "Apellido Materno");

            var lblEdad = new Label
            {
                FontSize = 10,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblEdad.SetBinding(Label.TextProperty, "Edad");

            var lblCarrera = new Label
            {
                FontSize = 10,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblAPaterno.SetBinding(Label.TextProperty, "Carrera");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    lblNombre,
                    lblAPaterno,
                    lblAMaterno,
                    lblEdad,
                    //lblCarrera
                }
            };
            View = stackList;
        }
    }
}
