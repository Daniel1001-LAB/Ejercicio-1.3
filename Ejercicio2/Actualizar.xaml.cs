using Ejercicio2.Modelos;
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
    public partial class Actualizar : ContentPage
    {
        SQLiteAsyncConnection conn1 = new SQLiteAsyncConnection(App.UBICACIONDB);

        public Actualizar()
        {
            InitializeComponent();
        }

        private async void lista_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new lista());
        }

        private async void btnDlt_Clicked(object sender, EventArgs e)
        {
            try
            {
                var personas = await conn1.Table<Personas>().Where(item => item.id == Convert.ToInt32(Idu.Text)).FirstOrDefaultAsync();
                if (personas != null)
                {
                    await conn1.DeleteAsync(personas);
                }
            }
            catch (SQLiteException w)
            {

            }
           
        }
            private async void btnAct_Clicked(object sender, EventArgs e)
        {
            
                if (!string.IsNullOrEmpty(Idu.Text))
            {
                var personas = new Personas()
                {
                    id = Convert.ToInt32(Idu.Text),
                    name = nombre.Text,
                    apellido = apellido.Text,
                    edad = Convert.ToInt32(edad.Text),
                    direccion = direccion.Text,
                    correo = correo.Text,
                    fecha = Convert.ToDateTime(fecha.Date)
                };

                

                await conn1.UpdateAsync(personas);
                conn1.CloseAsync();
            }
                
        }
    }
}
