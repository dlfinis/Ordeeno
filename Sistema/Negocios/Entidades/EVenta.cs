using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class EVenta
    {


        private int ven_codigo;

        public int Ven_codigo
        {
            get { return ven_codigo; }
            set { ven_codigo = value; }
        }

        private int per_codigo;

        public int Per_codigo
        {
            get { return per_codigo; }
            set
            {
                if (value < 1 || String.IsNullOrEmpty(value.ToString()) )
                {
                    throw new Exception("No ha seleccionado una persona");
                }
                else
                    per_codigo = value;
            }
        }

       
        

        private double ven_subtotal12;

        public double Ven_subtotal12
        {
            get { return ven_subtotal12; }
            set {
                if (value < 0 )
                {
                    ven_subtotal12 = 0.0;
                }
                else
                    ven_subtotal12 = value;
            }
        }

        private double ven_subtotal0;

        public double Ven_subtotal0
        {
            get { return ven_subtotal0; }
            set
            {
                if (value < 0 )
                {
                    ven_subtotal0 = 0.0;
                }
                else
                    ven_subtotal0 = value;
            }
        }

        private double ven_subtotal;

        public double Ven_subtotal
        {
            get { return ven_subtotal; }
            set
            {
                if (value < 0 )
                {
                    ven_subtotal = 0.0;
                }
                else
                    ven_subtotal = value;
            }
        }

        NConfiguracion getConf = new NConfiguracion();
        
        public double ven_descuento;

        public double Ven_descuento
        {
            get { return ven_descuento; }
            set
            {
                double descuento = Convert.ToDouble((getConf.getDatos("DESCUENTO").conf_valor));
                if (value > descuento && value < 0)
                {
                    throw new Exception("No es posible hacer ese descuento,desde 0.0% hasta " + descuento);

                }
                else
                {
                    if (value < 0)
                    {
                        ven_descuento = 0.0;
                    }
                    else
                        ven_descuento = value;
                }
            }
        }

        private double ven_tiva;

        public double Ven_tiva
        {
            get {

                if (Ven_subtotal0 > 0)
                {
                    return 0.0;
                }
                else
                {
                    if (Ven_subtotal12 > 0)
                    {
                        return Ven_subtotal12 * Convert.ToDouble(getConf.getDatos("IVA").conf_valor);
                    }
                    else {

                        return 0.0;
                    }
                }
                  
            }
           
        }


        private DateTime ven_date;

        public DateTime Ven_date
        {
            get {

                if (!String.IsNullOrEmpty(ven_date + ""))
                    return ven_date;
                else
                    return DateTime.Now.Date;
            }

            set {
                ven_date = value;
            }
           
        }


        private char ven_estado;

        public char Ven_estado
        {
            get { return ven_estado; }
            set
            {
                if (value.Equals('S'))
                {
                    ven_estado = 'S';
                }
                else
                {
                    ven_estado = 'N';
                }
            }
                       
                 
        }


        private double ven_total;

        public double Ven_total
        {
            get { 
                if(Ven_tiva>0)
            {

                return (Ven_subtotal12 - (Ven_descuento * Ven_subtotal12))+Ven_tiva;
                
             }
                else
                {

                    return Ven_subtotal0 + (Ven_descuento*Ven_subtotal0);

                }
            }
            
            
           
        }


        /// <sumcoly>
        /// Constructor sin parametros
        /// </sumcoly>
        public EVenta()
        {
        }

        public EVenta(int vencodigo,int percodigo,
                       double vensubtotal12,double vensubtotal0,
                       double vensubtotal,double vendescuento)
     
        {

            this.Ven_codigo = vencodigo;
            this.Per_codigo = percodigo;
            this.Ven_subtotal12 = vensubtotal12;
            this.Ven_subtotal0 = vensubtotal0;
            
            this.Ven_subtotal= vensubtotal;
            this.Ven_descuento = vendescuento;
          

        }
       


    }
}
