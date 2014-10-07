using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocios;

namespace Negocios.Entidades
{
    public partial class EProveedor
    {




        private int prov_codigo;

        public int Prov_codigo
        {
            get { return prov_codigo; }
            set
            {
                prov_codigo = value;
            }
        }

        private string prov_nombre;

        public String Prov_nombre
        {
            get { return prov_nombre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de proveedor es obligatorio");
                }
                else
                {
                    prov_nombre = value;
                }

            }
        }

      
        private string prov_direccion;

        public string Prov_direccion
        {
            get { return prov_direccion; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    prov_direccion = "NINGUNA";
                }
                else
                {
                    prov_direccion = value;
                }

            }
        }
        private string ciu_nombre;

        public string Ciu_nombre
        {
            get { return ciu_nombre; }
            set
            {
                if(!String.IsNullOrEmpty(value))
                  ciu_nombre = value;
                else
                    throw new Exception("El campo de Ciudad  de Proveedor es obligatorio");

            }
        }

        private int ciu_codigo;

        public int Ciu_codigo
        {
            get { return ciu_codigo; }
            set
            {
                if (value<1 )
                {
                    throw new Exception("El campo de ciudad es obligatorio");
                }
                else
                {
                    ciu_codigo = value;
                }

            }
        }

        private string prov_telefono;

        public string Prov_telefono
        {
            get { return prov_telefono; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {

                    prov_telefono = "0000000000";
                }
                else
                {
                    prov_telefono = value;

                }

            }
        }
        private string prov_celular;

        public string Prov_celular
        {
            get { return prov_celular; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {

                    prov_celular = "0000000000";
                }
                else
                    prov_celular = value;

            }
        }


        private string prov_email;

        public string Prov_email
        {
            get { return prov_email; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {

                    prov_email = "NINGUNO";
                }
                else
                    prov_email = value;

            }
        }

        private string prov_identificacion;

        public string Prov_identificacion
        {
            get { return prov_identificacion; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de identificacion es unico \n y obligatorio");
                }
                else
                {
                    prov_identificacion = value;
                }

            }
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EProveedor()
        {


        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="provcodigo"></param>
        /// <param name="provnombre"></param>
        /// <param name="provapellido"></param>
        /// <param name="provdireccion"></param>
        /// <param name="provciudad"></param>
        /// <param name="provtelefono"></param>
        /// <param name="provcelular"></param>
        /// <param name="providentificacion"></param>
        public EProveedor(int provcodigo,
            string provnombre,  string provdireccion, int provciudad,
            string provtelefono, string provcelular, string provemail,string providentificacion)
        {

            this.prov_codigo = provcodigo;
            this.prov_nombre = provnombre;
           
            this.prov_direccion = provdireccion;
            this.ciu_codigo = provciudad;
            this.prov_telefono = provtelefono;
            this.prov_celular = provcelular;
            this.prov_email = provemail;
            this.prov_identificacion = providentificacion;

        }

    }
}
