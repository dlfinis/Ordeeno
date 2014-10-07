using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class ECiudad
    {

        private int ciu_codigo;
        public int Ciu_codigo
        {
            get { return ciu_codigo; }
            set { 
                ciu_codigo = value; }
        }
        private String ciu_nombre;
        public String Ciu_nombre
        {
            get { return ciu_nombre; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de ciudad es obligatorio");
                }
                else {
                    ciu_nombre = value;
                }

            }
        }
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ECiudad()
        { 
        
        
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="ciucodigo"></param>
        /// <param name="ciunombre"></param>
        public ECiudad(int ciucodigo,String ciunombre)
        {

            this.ciu_codigo = ciucodigo;
            this.ciu_nombre = ciunombre;
        }

    }
}
