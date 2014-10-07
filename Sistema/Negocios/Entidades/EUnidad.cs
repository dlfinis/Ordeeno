using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocios.Entidades
{
    public class EUnidad
    {
        private int uni_codigo;
        public int Uni_codigo
        {
            get { return uni_codigo; }
            set
            {
                uni_codigo = value;
            }
        }
        private String uni_nombre;
        public String Uni_nombre
        {
            get { return uni_nombre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de unidad es obligatorio");
                }
                else
                {
                    uni_nombre = value.ToUpper().ToUpper();
                }

            }
        }

        private String uni_prefijo;
        public String Uni_prefijo
        {
            get { return uni_prefijo; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Prefijo de unidad es obligatorio");
                }
                else
                {
                    uni_prefijo = value.ToUpper();
                }

            }
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EUnidad()
        {


        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="unicodigo"></param>
        /// <param name="uninombre"></param>
        /// <param name="uniprefijo"></param>
        public EUnidad(int unicodigo, String uninombre,String uniprefijo)
        {

            this.Uni_codigo = unicodigo;
            this.Uni_nombre = uninombre;
            this.Uni_prefijo = uniprefijo;
        }

    }
}
