using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocios;

namespace Negocios.Entidades
{
    public partial class EProducto
    {




        private int prod_codigo;

        public int Prod_codigo
        {
            get { return prod_codigo; }
            set
            {
                prod_codigo = value;
            }
        }



        private string codprod_codigo;

        public String Codprod_codigo
        {
            get { return codprod_codigo; }
            set
            {
                if (String.IsNullOrEmpty(value)  || value.Length<3)
                {
                    throw new Exception("El campo de Codigo  de producto es necesario");
                }
                else
                {
                    codprod_codigo = value;
                }
                
                

            }
        }

        private string prod_nombre;

        public String Prod_nombre
        {
            get { return prod_nombre; }
            set
            {
                value = value.TrimEnd().TrimStart();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de producto es obligatorio");
                }
                else
                {
                    prod_nombre = value+" ";
                }

            }
        }


        private string prod_descripcion;

        public string Prod_descripcion
        {
            get { return prod_descripcion; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    prod_descripcion = "NINGUNA";
                }
                else
                {
                    prod_descripcion= value;
                }

            }
        }
        private string prod_dimension;

        public string Prod_dimension
        {
            get { return prod_dimension; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    prod_dimension = "NINGUNA";
                }
                else
                {
                    prod_dimension = value;
                }

            }
        }

        private string prod_color;

        public string Prod_color
        {
            get { return prod_color; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    prod_color = "NINGUN";
                }
                else
                {
                    prod_color = value;
                }

            }
        }
         
           private double prod_compra;

           public double Prod_compra
            {
              get { return prod_compra; }
              set { if (value<=0 )
                {
                   throw new Exception("Es necesario el valor del precio de compra");
                }
                else
                {
                    prod_compra = value;
                }
              }
            }


         private double prod_venta;

                public double Prod_venta
                {
                  get { return prod_venta; }
                  set {
                      if (value <= 0)
                      {
                          throw new Exception("Es necesario el valor del precio de venta sea mayor a 0");
                      }
                     
                      prod_venta = value;
                
                  
                  }
                }
         private int prod_stock_min;

            public int Prod_stock_min
            {
              get { return prod_stock_min; }
              set { if (value<=0 )
                {
                    prod_stock_min = this.Prod_mincantidad;
                }
                  else
                {
                    prod_stock_min = value;
                } }
            }

         private int prod_stock;

            public int Prod_stock
            {
              get { return prod_stock; }
              set { if (value<1 )
                {
                   prod_stock =0;
                }
                else
                {
                    prod_stock = value;
                } }
            }

            

       
         private char prod_iva;

            public char Prod_iva
            {
              get { return prod_iva; }
              set { 
                  
                  if(prod_iva.Equals('S'))
                  {prod_iva = value; }
                  else
                  {     if (prod_iva.Equals('N'))
                            prod_iva=value;
                        else
                            prod_iva='S';
                 
                  }
                   }
            }

            private double prod_aumento;

            public double Prod_aumento
            {
                get {            
                    NConfiguracion getInfo = new NConfiguracion();
                    prod_aumento = 
                        Convert.ToDouble(getInfo.getDatos("AUMENTO").conf_valor);
                    return prod_aumento;
                }
            }

            private int prod_mincantidad;

            public int Prod_mincantidad
            {
                get
                {
                    NConfiguracion getInfo = new NConfiguracion();
                    prod_mincantidad =
                        Convert.ToInt32(getInfo.getDatos("MINPRODUCTO").conf_valor);
                    return prod_mincantidad;
                }
            }

            private double prod_iva_valor;

            public double Prod_iva_valor
            {
                get
                {
                    NConfiguracion getInfo = new NConfiguracion();
                    prod_iva_valor =
                        Convert.ToDouble(getInfo.getDatos("IVA").conf_valor);
                    return prod_iva_valor;
                }
            }
         
     
        private int cat_codigo;

        public int Cat_codigo
        {
            get { return cat_codigo; }
            set
            {

                if (value<1)
                {
                    throw new Exception("El campo de categoria es obligatorio");
                }
                else
                {
                    cat_codigo = value;
                }

            }
        }

        private String cat_nombre;

        public String Cat_nombre
        {
            get { return cat_nombre; }
            set
            {
                value=value.TrimEnd().TrimStart();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de categoria es obligatorio");
                }
                else
                {
                    cat_nombre = value;
                }

            }
        }

        private int uni_codigo;

        public int Uni_codigo
        {
            get { return uni_codigo; }
            set
            {
                if (value < 1)
                {
                    uni_codigo = 1;
                }
                else
                {
                    uni_codigo = value;
                }

            }
        }

        private String uni_nombre;

        public String Uni_nombre
        {
            get { return uni_nombre; }
            set
            {
                value = value.TrimEnd().TrimStart();
                if (String.IsNullOrEmpty(value))
                {
                    uni_nombre = "UNIDAD";
                }
                else
                {
                    uni_nombre = value;
                }

            }
        }
       
        private int mar_codigo;
        public int Mar_codigo
        {
            get { return mar_codigo; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("El campo de Marca es obligatorio,seleccione o ingrese");
                }
                else
                {
                    mar_codigo = value;
                }

            }
        }

        private String mar_nombre;
        public String Mar_nombre
        {
            get { return mar_nombre; }
            set
            {
                value=value.TrimEnd().TrimStart();
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Marca es obligatorio,seleccione o ingrese");
                }
                else
                {
                    mar_nombre = value;
                }

            }
        }
        private int dcar_codigo;
        public int Dcar_codigo
        {
            get { return dcar_codigo; }
            set
            {
                if (value < 1)
                {
                    dcar_codigo = 0;
                }
                else
                {
                    dcar_codigo = value;
                }

            }
        }

         
	
       
        

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EProducto()
        {


        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="prod_codigo"></param>
        /// <param name="prod_nombre"></param>
        /// <param name="prod_despcripcion"></param>
     
        /// <param name="prod_compra"></param>
        /// <param name="prod_venta"></param>
        /// <param name="prod_iva"></param>
        /// <param name="prod_stock"></param>
        /// <param name="prod_stockmin"></param>
        /// <param name="prod_prov"></param>
        /// <param name="prod_cat"></param>
        /// <param name="prod_uni"></param>
        public EProducto(int prodcodigo,string prodcodprod,
            string prodnombre, string proddescripcion,
            double prodcompra,double prodventa,char prodiva,int prodstockmin,int prodstock,int prodprov,int prodcat,
            int produni,int prodmar,int proddcar )
        {
            this.Codprod_codigo = prodcodprod;
            this.Prod_codigo = prodcodigo;
            this.Prod_nombre=prodnombre;
      
           this.Mar_codigo=prodprov;
           this.Prod_descripcion=proddescripcion;
           
           
           this.Prod_compra=prodcompra;
           this.Prod_venta=prodventa;
           this.Prod_iva=prodiva;
           
           this.Prod_stock_min=prodstockmin;
           this.Prod_stock = prodstock;
           this.Mar_codigo = prodprov;
           this.Uni_codigo = produni;
           this.Cat_codigo = prodcat;
           this.Mar_codigo = prodmar;
           this.Dcar_codigo = proddcar;
        }

    }
}
