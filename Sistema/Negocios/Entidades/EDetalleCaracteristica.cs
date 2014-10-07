using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
   public  class EDetalleCaracteristica
    {

        private int dcar_codigo;

        public int Dcar_codigo
        {
            get { return dcar_codigo; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("No es valido el registrar");
                  
                }
                else
                    dcar_codigo = value;
            }
        }

        private int car_codigo;

        public int Car_codigo
        {
            get { return car_codigo; }
            set {
                if (value < 1)
                {
                    throw new Exception("No es valido esa caracteristica");
                    
                }
                else
                    car_codigo = value;
            }
        }

        private string car_tipo;

        public string Car_tipo
        {
            get { return car_tipo; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("No es posible dejar vacio el tipo de caracteristica");

                }
                else
                    car_tipo = value;
            }
        }
        private string car_valor;

        public string Car_valor
        {
            get { return car_valor; }
            set { car_valor = value; }
        }

        
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EDetalleCaracteristica()
        {


        }

        public EDetalleCaracteristica(int dcarcodigo,string cartipo,string carvalor)
        {
            Dcar_codigo = dcarcodigo;
            Car_tipo = cartipo;
            Car_valor = carvalor;

        }

    }
}
