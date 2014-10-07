using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocios;

namespace Negocios.Entidades
{
    public partial class EConfiguracion
    {




        private int conf_codigo;

        public int Conf_codigo
        {
            get { return conf_codigo; }
            set { conf_codigo = value; }
        }
        private string conf_clave;

        public string Conf_clave
        {
            get { return conf_clave; }
            set { conf_clave = value; }
        }
        private string conf_valor;

        public string Conf_valor
        {
            get { return conf_valor; }
            set
            {

                if (String.IsNullOrEmpty(value.Trim()))
                { throw new Exception("EL valor de la clave de configuracion es necesario"); }
                else
                {
                    int valor = 0;
                    double valdecimal = 0.0;
                    if (Conf_clave.Equals("ACTUALIZACION") || Conf_clave.Equals("MINPRODUCTO"))
                    {
                        if (Int32.TryParse(value, out valor) && valor > -1)
                        {
                            conf_valor = valor + "";
                        }
                        else
                        {
                            throw new Exception("EL valor de la clave debe ser mayor a -1");
                        }
                    }
                    else
                    {
                        if (Double.TryParse(value, out valdecimal) && valdecimal > -0.1 && valdecimal<1.0)
                        {
                            conf_valor = valdecimal + "";
                        }
                        else
                        {
                            throw new Exception("EL valor de la clave debe ser mayor a -0.1 y menor a 0.99");
                        }

                    }
                }
            }
        }

     





        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EConfiguracion()
        {


        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="confcodigo"></param>
        /// <param name="confnombre"></param>
        /// <param name="confvalor"></param>
       
        public EConfiguracion(int confcodigo,
            string confnombre, string confvalor)
        {

            this.Conf_codigo = confcodigo;
            this.Conf_valor = confvalor;
            this.Conf_clave = confnombre;

        }

        public EConfiguracion(string confnombre, string confvalor)
        {

            
            this.Conf_valor = confvalor;
            this.Conf_clave = confnombre;

        }

    }
}
