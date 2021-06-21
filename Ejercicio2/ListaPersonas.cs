using System;

namespace Ejercicio2
{
    internal class ListaPersonas
    {
        public ListaPersonas()
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
    }
}