using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class EDetallePedido
    {

        private int ped_codigo;

        public int Ped_codigo
        {
            get { return ped_codigo; }
            set { ped_codigo = value; }
        }

        private int prod_codigo;

        public int Prod_codigo
        {
            get { return prod_codigo; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Es necesario la seleccion del Producto");
                }
                else
                    prod_codigo = value;
            }
        }

        private string codprod_codigo;

        public string CodProd_codigo
        {
            get { return codprod_codigo; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Es necesario la seleccion del Producto-0");
                }
                else
                    codprod_codigo = value;
            }
        }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Es necesario la cantidad");
                }
                else
                    cantidad = value;
            }
        }

        private double dped_precio;

        public double Dped_precio
        {
            get { return dped_precio; }
            set
            {


                if (value < 0)
                {
                    dped_precio = 0.0;
                    if (Prod_codigo > 0)
                    {
                        dped_precio = Convert.ToDouble(getProducto.getDatos(Prod_codigo).Compra);
                    }
                }
                else
                    dped_precio = value;
            }
        }



        NConfiguracion getConf = new NConfiguracion();
        NProducto getProducto = new NProducto();
        


        private double dped_descuento;




        public double Dped_descuento
        {
            get { return dped_descuento; }
            set
            {

                if (value < 0.1)
                {
                    dped_descuento = 0.0;
                }
                else
                    dped_descuento = value;

            }
        }




        /// <sumcoly>
        /// Constructor sin parametros
        /// </sumcoly>
        public EDetallePedido()
        {


        }



        public EDetallePedido(int vencodigo, int prodcodigo, string prodcodprod, int cantidad,
            double dvenprecio, double dvendescuento, double dvenaumento)
        {

            this.Ped_codigo = vencodigo;

            this.Prod_codigo = prodcodigo;
            this.CodProd_codigo = prodcodprod;
            this.Cantidad = cantidad;
            this.Dped_precio = dvenprecio;
            this.Dped_descuento = dvendescuento;
           
        }



    }
}
