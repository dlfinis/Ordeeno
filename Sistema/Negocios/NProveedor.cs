using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocios.Entidades;
using System.Data;

namespace Negocios
{
    public class NProveedor
    {


        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar Proveedores por Nombres
        /// </summary>
        /// <param name="buscar">Nombre de la Proveedor</param>
        /// <returns>TProveedor_TCiudad</returns>
        public List<TProveedor_TCiudad> Listar(String buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return (from p in this.dt.TProveedor_TCiudad
                            where p.Nombre.Contains(buscar) ||
                                  p.Identificacion.Contains(buscar) ||
                                  p.Telefono.Contains(buscar) ||
                                  p.Email.Contains(buscar) ||
                                  p.Ciudad.Contains(buscar) ||
                                  p.Celular.Contains(buscar) ||
                                  p.Direccion.Contains(buscar) 
                            select p).OrderBy(p => p.Nombre).ToList<TProveedor_TCiudad>();

                    
                }

            }
          
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }



        }

        /// <summary>
        /// Metodo para Listar Proveedores por Eleccion
        /// </summary>
        /// <param name="buscar">Cadena a buscar</param>
        /// <returns>TProveedor_TCiudad</returns>
        public List<TProveedor_TCiudad> Listar(String buscar, string opcion)
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
                                return (from p in this.dt.TProveedor_TCiudad
                                        where p.Identificacion.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TProveedor_TCiudad>();
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
                                return (from p in this.dt.TProveedor_TCiudad
                                        where p.Nombre.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TProveedor_TCiudad>();
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
                                return (from p in this.dt.TProveedor_TCiudad
                                        where p.Ciudad.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TProveedor_TCiudad>();
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
                                return (from p in this.dt.TProveedor_TCiudad
                                        where p.Telefono.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TProveedor_TCiudad>();
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
                                return (from p in this.dt.TProveedor_TCiudad
                                        where p.Celular.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TProveedor_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                      


                    case "Email":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                return (from p in this.dt.TProveedor_TCiudad
                                        where p.Email.Contains(buscar)
                                        select p).OrderBy(p => p.Codigo).ToList<TProveedor_TCiudad>();
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                      


                         default: throw new Exception(" No se puede Listar");

                }
                #endregion

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
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
        public TProveedor_TCiudad getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProveedor_TCiudad
                            where c.Codigo.Equals(codigo)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
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
        public TProveedor_TCiudad getDatos(string nombre)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProveedor_TCiudad
                            where c.Nombre.Equals(nombre)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
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
        public TProveedor_TCiudad getDatosCodProd(string identificacion)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProveedor_TCiudad
                            where c.Identificacion.Equals(identificacion.Trim())
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }



        


        /// <summary>
        /// Registro de Proveedor
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EProveedor d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_prov_insert(d.Prov_nombre,
                                                 d.Prov_direccion,
                                                 d.Ciu_nombre,
                                                 d.Prov_telefono,
                                                 d.Prov_celular,
                                                 d.Prov_email,
                                                 d.Prov_identificacion);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EProveedor d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_prov_edit(d.Prov_codigo, d.Prov_nombre,
                                                d.Prov_direccion,
                                                d.Ciu_nombre,
                                                d.Prov_telefono,
                                                d.Prov_celular,
                                                d.Prov_email,
                                                d.Prov_identificacion);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
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
                    this.dt.sp_prov_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Proveedor");
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

