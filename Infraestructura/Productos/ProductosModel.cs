using Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Productos
{
   public class ProductosModel
    {

        private Producto[] Productos;

        #region GRUD
        public void Add(Producto p)
        {

            Add(p, ref Productos);

        }

        public Producto[] GetAll()
        {

            return Productos;
        }

        public int Update(Producto p)
        {

            if(p == null)
            {
                throw new ArgumentException("El producto no puede ser null");
            }

            int index = GetIndexById(p.ID);
            if(index < 0)
            {

                throw new Exception ($"El producto con id {p.ID} no se encuentra");
            }

            Productos[index] = p;
            return index;
        }

        public bool Delete(Producto p)
        {
            if (p == null)
            {
                throw new ArgumentException("El producto no puede ser null");
            }

            int index = GetIndexById(p.ID);
            if (index < 0)
            {

                throw new Exception($"El producto con id {p.ID} no se encuentra");
            }

            if(index != Productos.Length - 1)
            {
                Productos[index] = Productos[Productos.Length - 1];
            }

            Producto[] temp = new Producto[Productos.Length - 1];
            Array.Copy(Productos, temp, temp.Length);
            Productos = temp;
            return Productos.Length == temp.Length;
        }
        #endregion

        #region Private Method
        private void Add(Producto p, ref Producto[] pds)
        {

            if (pds == null)
            {

                pds = new Producto [1];
                pds[pds.Length - 1] = p;
                return;
            }

            Producto[] tmp = new Producto[pds.Length + 1];
            Array.Copy(pds, tmp, pds.Length);
            tmp[tmp.Length - 1] = p;
            pds = tmp;


        }
        private int GetIndexById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException ("El id no puede ser negativo o cero");

            }

            int index = int.MaxValue, i = 0;

            if(Productos == null)
            {
                return index;
            }

            foreach(Producto p in Productos)
            {
                if(p.ID == id)
                {
                    index = i;
                }
                i++;
                break;

            }
            return index;
        }
        #endregion

        #region Queries
        public Producto GetProductoByid(int id)
        {

            if(id <= 0)
            {
                throw new ArgumentException ($"El id {id} no es valido");
            }

            int index = GetIndexById(id);

            return index <= 0 ? null : Productos[index];
        }
        #endregion
    }
}
