using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class EPedido
    {


        private int ped_codigo;

        public int Ped_codigo
        {
            get { return ped_codigo; }
            set { ped_codigo = value; }
        }

        private int prov_codigo;

        public int Prov_codigo
        {
            get { return prov_codigo; }
            set
            {
                if (value < 1 || String.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("No ha seleccionado un proveedor");
                }
                else
                    prov_codigo = value;
            }
        }




        private double ped_subtotal12;

        public double Ped_subtotal12
        {
            get { return ped_subtotal12; }
            set
            {
                if (value < 0)
                {
                    ped_subtotal12 = 0.0;
                }
                else
                    ped_subtotal12 = value;
            }
        }

        private double ped_subtotal0;

        public double Ped_subtotal0
        {
            get { return ped_subtotal0; }
            set
            {
                if (value < 0)
                {
                    ped_subtotal0 = 0.0;
                }
                else
                    ped_subtotal0 = value;
            }
        }

        private double ped_subtotal;

        public double Ped_subtotal
        {
            get { return ped_subtotal; }
            set
            {
                if (value < 0)
                {
                    ped_subtotal = 0.0;
                }
                else
                    ped_subtotal = value;
            }
        }

        NConfiguracion getConf = new NConfiguracion();

      private double ped_descuento;

        public double Ped_descuento
        {
            get { return ped_descuento; }
            set
            {
               
                    if (value < 0)
                    {
                        ped_descuento = 0.0;
                    }
                    else
                        ped_descuento = value;
                
            }
        }

        private double ped_tiva;

        public double Ped_tiva
        {
            get
            {

                if (Ped_subtotal0 > 0)
                {
                    return 0.0;
                }
                else
                {
                    if (Ped_subtotal12 > 0)
                    {
                        return Ped_subtotal12 * Convert.ToDouble(getConf.getDatos("IVA").conf_valor);
                    }
                    else
                    {

                        return 0.0;
                    }
                }

            }

        }


        private DateTime ped_date;

        public DateTime Ped_date
        {
            get
            {
                if (!String.IsNullOrEmpty(ped_date + ""))
                    return ped_date;
                else
                    return DateTime.Now.Date;
            }
            set {

                
                ped_date = value;
            }

        }


        private char ped_estado;

        public char Ped_estado
        {
            get { return ped_estado; }
            set
            {
                if (value.Equals('S'))
                {
                    ped_estado = 'S';
                }
                else
                {
                    ped_estado = 'N';
                }
            }


        }


        private double ped_total;

        public double Ped_total
        {
            get
            {
                if (Ped_tiva > 0)
                {

                    return (Ped_subtotal12 - (Ped_descuento * Ped_subtotal12)) + Ped_tiva;

                }
                else
                {

                    return Ped_subtotal0 + (Ped_descuento * Ped_subtotal0);

                }
            }



        }


        /// <sumcoly>
        /// Constructor sin parametros
        /// </sumcoly>
        public EPedido()
        {
        }

        public EPedido(int vencodigo, int percodigo,
                       double vensubtotal12, double vensubtotal0,
                       double vensubtotal, double vendescuento)
        {

            this.Ped_codigo = vencodigo;
            this.Prov_codigo = percodigo;
            this.Ped_subtotal12 = vensubtotal12;
            this.Ped_subtotal0 = vensubtotal0;

            this.Ped_subtotal = vensubtotal;
            this.Ped_descuento = vendescuento;


        }



    }
}
