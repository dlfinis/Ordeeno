using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocios.Entidades
{
    public class ETamanio
    {
        private int dim_codigo;
        public int Dim_codigo
        {
            get { return dim_codigo; }
            set
            {
                dim_codigo = value;
            }
        }
        private String dim_nombre;
        public String Dim_nombre
        {
            get { return dim_nombre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de dimension es obligatorio");
                }
                else
                {
                    dim_nombre = value;
                }

            }
        }
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ETamanio()
        {


        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="marcodigo"></param>
        /// <param name="marnombre"></param>
        public ETamanio(int dimcodigo, String dimnombre)
        {

            this.dim_codigo = dimcodigo;
            this.dim_nombre = dimnombre;
        }

    }
}
