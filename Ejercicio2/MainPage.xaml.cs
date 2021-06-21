using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void lista_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Bien!", "Podras ver la informacion almacenada", "Ver");
            await Navigation.PushAsync(new lista());
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var personas = new Modelos.Personas()
            {
                id = 0,
                name = nombre.Text,
                apellido = apellido.Text,
                edad = Convert.ToInt32(edad.Text),
                direccion = direccion.Text,
                correo = correo.Text,
                fecha = fecha.Date


            };

            try
            {
                SQLiteConnection conn1 = new SQLiteConnection(App.UBICACIONDB);
                conn1.CreateTable<Modelos.Personas>();
                conn1.Insert(personas);
                conn1.Close();

                await DisplayAlert("Success", "Datos Guardados", "Ok");
                await Navigation.PushAsync(new lista());



            }
            catch (SQLiteException r)
            {
                DisplayAlert("Success", " Error "+ r, "Ok");
            }

        }
    }
}
