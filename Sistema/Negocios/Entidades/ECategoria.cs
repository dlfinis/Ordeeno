using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class ECategoria
    {

        private int cat_codigo;
        public int Cat_codigo
        {
            get { return cat_codigo; }
            set { 
                cat_codigo = value; }
        }
        private String cat_nombre;
        public String Cat_nombre
        {
            get { return cat_nombre; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de categoria es obligatorio");
                }
                else {
                    cat_nombre = value;
                }

            }
        }
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ECategoria()
        { 
        
        
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="catcodigo"></param>
        /// <param name="catnombre"></param>
        public ECategoria(int catcodigo,String catnombre)
        {

            this.cat_codigo = catcodigo;
            this.cat_nombre = catnombre;
        }

    }
}
