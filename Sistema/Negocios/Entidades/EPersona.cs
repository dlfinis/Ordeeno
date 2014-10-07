using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocios;

namespace Negocios.Entidades
{
    public partial class EPersona
    {

        
        
        
        private int per_codigo;
                
        public int Per_codigo
        {
            get { return per_codigo; }
            set { 
                per_codigo = value; }
        }

        private string per_nombre;
          
        public String Per_nombre
        {
            get { return per_nombre; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Nombre de persona es obligatorio");
                }
                else {
                    per_nombre = value;
                }

            }
        }

        private string per_apellido;

        public string Per_apellido
        {
            get { return per_apellido; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de Apellido de persona es obligatorio");
                }
                else {
                    per_apellido = value;
                }

            }
        }
        private string per_direccion;

        public string Per_direccion
        {
            get { return per_direccion; }
             set {
                if (String.IsNullOrEmpty(value))
                {
                    per_direccion = "NINGUNA";
                }
                else {
                    per_direccion = value;
                }

            }
        }
        private string ciu_nombre;

        public string Ciu_nombre
        {
            get { return ciu_nombre; }
            set {

                if (!String.IsNullOrEmpty(value))
                    ciu_nombre = value;
                else
                    throw new Exception("El campo de Ciudad  de Persona es obligatorio");
                

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

        private string per_telefono;

        public string Per_telefono
        {
            get { return per_telefono; }
             set {
                 if (String.IsNullOrEmpty(value))
                 {

                     per_telefono = "0000000000";
                 }
                 else
                 {
                     per_telefono = value;
                 
                 }

            }
        }
        private string per_celular;

        public string Per_celular
        {
            get { return per_celular; }
             set {
                 if (String.IsNullOrEmpty(value))
                 {

                     per_celular = "0000000000";
                 }
                 else
                     per_celular = value;

            }
        }
        private string per_identificacion;

        public string Per_identificacion
        {
            get { return per_identificacion; }
             set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("El campo de identificacion es unico \n y obligatorio");
                }
                else {
                    per_identificacion = value;
                }

            }
        }

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public EPersona()
        { 
        
        
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="percodigo"></param>
        /// <param name="pernombre"></param>
       /// <param name="perapellido"></param>
       /// <param name="perdireccion"></param>
       /// <param name="perciudad"></param>
       /// <param name="pertelefono"></param>
       /// <param name="percelular"></param>
       /// <param name="peridentificacion"></param>
        public EPersona(int percodigo,
            string pernombre,string perapellido,string perdireccion,int perciudad,
            string pertelefono,string percelular,string peridentificacion)
        {

            this.per_codigo = percodigo;
            this.per_nombre = pernombre;
            this.per_apellido=perapellido;
            this.per_direccion=perdireccion;
            this.ciu_codigo=perciudad;
            this.per_telefono=pertelefono;
            this.per_celular=percelular;
            this.per_identificacion=peridentificacion;

        }

    }
}
