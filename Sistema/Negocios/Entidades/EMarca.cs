using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocios.Entidades
{
    public class EMarca
    {
          private int mar_codigo;
        public int Mar_codigo
        {
            get { return mar_codigo; }
            set { 
                mar_codigo = value; }
        }
        private String mar_nombre;
        public String Mar_nombre
        {
            get { return mar_nombre; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de marca es obligatorio");
                }
                else {
                    mar_nombre = value;
                }

            }
        }

        private int prov_codigo;
        public int Prov_codigo
        {
            get { return prov_codigo; }
            set
            {
                if (value<1)
                {
                    throw new Exception("El campo de Proveedor de marca es obligatorio");
                }
                else
                {
                    prov_codigo = value;
                }

            }
        }
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EMarca()
        { 
        
        
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="marcodigo"></param>
        /// <param name="marnombre"></param>
        public EMarca(int marcodigo,String marnombre,int provcodigo)
        {

            this.mar_codigo = marcodigo;
            this.mar_nombre = marnombre;
            this.prov_codigo = provcodigo;
        }

    }
}
