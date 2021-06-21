using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lista : ContentPage

    {
        SQLiteAsyncConnection conn1 = new SQLiteAsyncConnection(App.UBICACIONDB);
        public lista()
        {

            InitializeComponent();
            mostrar();
        }

       


        public async void mostrar()
        {
            try {

                
                var datos1 = await conn1.Table<Personas>().ToArrayAsync();

                if(datos1 != null)
                {
                    datos.ItemsSource = datos1;
                }
            }
            catch (SQLite.SQLiteException e)
            {

            }
        }


        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var personas = new Personas();
            var itemS = (Personas)e.SelectedItem;
            if (!string.IsNullOrEmpty(itemS.id.ToString()))
            {
                var persona = await conn1.Table<Personas>().Where(lista => lista.id == itemS.id).FirstOrDefaultAsync();

                if(persona != null)
                {
                    var listapersona = new ListaPersonas()
                    {
                        Id = persona.id,
                        Nombre = persona.name,
                        Apellido = persona.apellido,
                        Edad = persona.edad,
                        Correo = persona.correo,
                        Direccion = persona.direccion,
                        Fecha = persona.fecha
                    };

                    var actualizar = new Actualizar();
                    actualizar.BindingContext = listapersona;
                    await Navigation.PushAsync(actualizar);
                }
            }
        }

    }
}