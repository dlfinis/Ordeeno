using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocios.Entidades
{
    public class EProductoCaracteristica
    {

        private int dcar_codigo;

        public int Dcar_codigo
        {
            get { return dcar_codigo; }
            set {

                if(dcar_codigo<0)
                 throw new Exception("Error de DCaracteristica");
                else
                dcar_codigo = value; }
        }
        private int prod_codigo;

        public int Prod_codigo
        {
            get { return prod_codigo; }
            set {

                if (value < 0)
                    throw new Exception("Se debe elegir un porudcto");
                else
                prod_codigo = value; }
        }
        
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EProductoCaracteristica()
        {


        }

        public EProductoCaracteristica(int pccodigo,int pcproducto)
        {
            Dcar_codigo = pccodigo;
            Prod_codigo = pcproducto;

        }


    }
}
