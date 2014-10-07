using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Negocios.Entidades
{
    public class EColor
    {
        private int col_codigo;
        public int Col_codigo
        {
            get { return col_codigo; }
            set
            {
                col_codigo = value;
            }
        }
        private String col_nombre;
        public String Col_nombre
        {
            get { return col_nombre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de color es obligatorio");
                }
                else
                {
                    col_nombre = value;
                }

            }
        }
        /// <sumcoly>
        /// Constructor sin parametros
        /// </sumcoly>
        public EColor()
        {


        }
        /// <sumcoly>
        /// Constructor con parametros
        /// </sumcoly>
        /// <param name="colcodigo"></param>
        /// <param name="colnombre"></param>
        public EColor(int colcodigo, String colnombre)
        {

            this.col_codigo = colcodigo;
            this.col_nombre = colnombre;
        }

    }
}
