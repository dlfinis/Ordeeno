using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocios.Entidades;

namespace Negocios
{
   public  class NPersona
    {

     
       public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar Personas por Nombres
        /// </summary>
        /// <param name="buscar">Nombre de la Persona</param>
        /// <returns>TPersona_TCiudad</returns>
        public List<TPersona_TCiudad> Listar(String buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return (from p in this.dt.TPersona_TCiudad
                            where p.Nombre.Contains(buscar) ||
                                  p.Apellido.Contains(buscar) ||
                                  p.Identificacion.Contains(buscar) ||
                                  p.Telefono.Contains(buscar) ||
                               
                                  p.Ciudad.Contains(buscar) ||
                                  p.Celular.Contains(buscar) ||
                                  p.Direccion.Contains(buscar)
                                  
                            select p).OrderBy(p=>p.Codigo).ToList<TPersona_TCiudad>();
                    
                    ///
                    /// 
                    //return (from p in this.dt.TPersona_TCiudad
                    //        join c in this.dt.TCiudad
                    //       on p.ciu_codigo equals c.ciu_codigo

                    //        select new TPersona_TCiudad
                    //        {
                    //            Codigo = p.per_codigo,
                    //            Nombre = p.per_nombre,
                    //            Apellido = p.per_apellido,
                    //            Direccion = p.per_direccion,
                    //            Ciudad = c.ciu_nombre,
                    //            Telefono = p.per_telefono,
                    //            Celular = p.per_celular,
                    //            Identificacion = p.per_identificacion
                    //        }).ToList<TPersona_TCiudad>();
                    
                    ///
                    
                }
                
                }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        
        
        }

        /// <summary>
        /// Metodo para Listar Personas por Eleccion
        /// </summary>
        /// <param name="buscar">Cadena a buscar</param>
        /// <returns>TPersona_TCiudad</returns>
        public List<TPersona_TCiudad> Listar(String buscar,string opcion)
        {

            
            try
            {
                #region
                switch (opcion)
                {
                    case "Identificacion":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TPersona_TCiudad
                                        where p.Identificacion.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TPersona_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                        
                    case "Nombre":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TPersona_TCiudad
                                        where p.Nombre.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TPersona_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                       
                    case "Apellido":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TPersona_TCiudad
                                        where p.Apellido.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TPersona_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                      

                    case "Ciudad":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TPersona_TCiudad
                                        where p.Ciudad.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TPersona_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                       
                    case "Telefono":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TPersona_TCiudad
                                        where p.Telefono.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TPersona_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                        
                    case "Celular":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TPersona_TCiudad
                                        where p.Celular.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TPersona_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {
                           
                            throw new Exception("Error al listar \n" + ex.Message);
                        }

                    default: return null;
                       

                }
                #endregion

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            

        }


        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TPersona_TCiudad getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TPersona_TCiudad
                            where c.Codigo.Equals(codigo)
                            select c;
                    return t.Single();
                   
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }


        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TPersona_TCiudad getDatosCodProd(string identificacion)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TPersona_TCiudad
                            where c.Identificacion.Equals(identificacion.Trim())
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }



        /// <summary>
        /// Registro de Persona
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EPersona  d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_per_insert(d.Per_nombre,
                                                 d.Per_apellido,
                                                 d.Per_direccion,
                                                 d.Ciu_nombre,
                                                 d.Per_telefono,
                                                 d.Per_celular,
                                                 d.Per_identificacion);
                
                }
                
                
                }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EPersona d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_per_edit(d.Per_codigo, d.Per_nombre,
                                                d.Per_apellido,
                                                d.Per_direccion,
                                                d.Ciu_nombre,
                                                d.Per_telefono,
                                                d.Per_celular,
                                                d.Per_identificacion);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }
        public void Eliminar(int codigo)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_per_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Persona");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }
    }

    }

