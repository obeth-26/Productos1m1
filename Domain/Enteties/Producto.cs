using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enteties
{
    public class Producto
    {

        public int ID { get; set; }
        public string Nombre { get;  set; }
        public string Descripcion { get;  set; }
        public int Existencias { get;  set; }
        public decimal Precio { get; set; }
        public DateTime FechaCaducidad { get; set; }

        public unidadMedida medidas { get; set; }


    }
}
