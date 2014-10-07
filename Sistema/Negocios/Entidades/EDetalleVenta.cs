using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class EDetalleVenta
    {

        private int ven_codigo;

        public int Ven_codigo
        {
            get { return ven_codigo; }
            set { ven_codigo = value; }
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
            set {
                if (value < 0)
                {
                    throw new Exception("Es necesario la cantidad");
                }
                else
                    cantidad = value; }
        }

        private double dven_precio;

        public double Dven_precio
        {
            get { return dven_precio; }
            set {

               
                if (value < 0)
                {
                  dven_precio =0.0 ;
                  if (Prod_codigo > 0)
                  {
                      dven_precio = Convert.ToDouble(getProducto.getDatos(Prod_codigo).Venta);
                  }
                }
                else
                dven_precio = value; }
        }

       
        
        NConfiguracion getConf = new NConfiguracion();
        NProducto getProducto = new NProducto();
        public double dven_aumento;
        public double Dven_aumento
        {
            get { return dven_aumento; }
            set
            {
               
                
                    if (value < 0)
                    {
                        dven_aumento = 0.0;
                    }
                    else
                    {
                        dven_aumento = value;
                    
                     
                    }
                
            }
        }

        
        private double dven_descuento;




        public double Dven_descuento
        {
            get { return dven_descuento; }
            set
            {
               
                    if (value <0)
                    {
                        dven_descuento = 0.0;
                    }
                    else
                        dven_descuento = value;
                
            }
        }

      


        /// <sumcoly>
        /// Constructor sin parametros
        /// </sumcoly>
        public EDetalleVenta()
        {


        }

       

        public EDetalleVenta(int vencodigo,int prodcodigo,string prodcodprod,int cantidad,
            double dvenprecio,double dvendescuento,double dvenaumento)
     
        {

            this.Ven_codigo = vencodigo;

            this.Prod_codigo = prodcodigo;
            this.CodProd_codigo = prodcodprod;
            this.Cantidad = cantidad;
            this.Dven_precio = dvenprecio;
            this.Dven_descuento = dvendescuento;
            this.Dven_aumento = dvenaumento;
          

        }
        


    }
}
