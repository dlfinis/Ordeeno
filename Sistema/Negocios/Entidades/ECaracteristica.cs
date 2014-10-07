using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class ECaracteristica
    {

        private int car_codigo;

        public int Car_codigo
        {
            get { return car_codigo; }
            set { car_codigo = value; }
        }
        private string car_tipo;

        public string Car_tipo
        {
            get { return car_tipo; }
            set { car_tipo = value; }
        }
        
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ECaracteristica()
        {


        }

        public ECaracteristica(int carcodigo,string cartipo)
        {
            Car_codigo = carcodigo;
            Car_tipo = cartipo;

        }

    }
}
