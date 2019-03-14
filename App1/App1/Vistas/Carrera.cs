using App1.WService;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Vistas
{
    class Carrera : ContentPage
    {
        private ListView lv_carrera;
        private List<Modelos.Carrera> list_carrera;
        private WSCarrera objWSCarrera;
        public Carrera()
        {
            list_carrera = new List<Modelos.Carrera>();
            objWSCarrera = new WSCarrera();
            Title = "Carreras";
            Label lblIdCarrea = new Label
            {
                Text = "id_carrera",
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
                    lblIdCarrea,
                    lblCarrera,
                }
            };
            lv_carrera = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(ResultCellCarrera))
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
                    lv_carrera
                }
            };
            Content = st_inst;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                list_carrera = await objWSCarrera.listaCarrera();
                lv_carrera.ItemsSource = list_carrera;
            }
            catch (Exception e) { await DisplayAlert("", e.StackTrace, ""); }
        }
    }
    class ResultCellCarrera : ViewCell
    {
        public ResultCellCarrera()
        {
            var lblIdCarrera = new Label()
            {
                FontSize = 10,
                WidthRequest = 100,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblIdCarrera.SetBinding(Label.TextProperty, "id_carrera");
            var lblCarrera = new Label
            {
                FontSize = 10,
                WidthRequest = 50,
                HeightRequest = 35,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblCarrera.SetBinding(Label.TextProperty, "carrera");


            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    lblIdCarrera,
                    lblCarrera,
                }
            };
            View = stackList;
        }
    }
}
