using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NCategoria
    {
        public DatoSistemasDataContext dt = null;


        /// <summary>
        /// Metodo para Listar Nombres de Categorias 
        /// </summary>
        /// <param name="buscar">Nombre de la categoria</param>
        /// <returns>TCategoria</returns>
        public List<TCategoria> Listar()
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TCategoria
                           
                             select c).OrderBy(c => c.cat_codigo).ToList<TCategoria>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Categoria");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }
        
        
        
        /// <summary>
        /// Metodo para Listar Categorias
        /// </summary>
        /// <param name="buscar">Nombre de la categoria</param>
        /// <returns>TCategoria</returns>
        public List<TCategoria> Listar(String buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TCategoria
                            where c.cat_nombre.Contains(buscar)
                             select c).OrderBy(c => c.cat_codigo).ToList<TCategoria>();
                  return t.ToList();
                }
                
                }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex,  "Categoria");
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
        public TCategoria getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TCategoria
                            where c.cat_codigo.Equals(codigo)
                            select c;
                    return t.Single();
                   
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Categoria");
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
        public TCategoria getDatos(string nombre)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TCategoria
                            where c.cat_nombre.Contains(nombre)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Categoria");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de categoria
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(ECategoria  d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_cat_insert(d.Cat_nombre);
                
                }
                
                
                }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex,  "Categoria");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(ECategoria d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                     this.dt.sp_cat_edit(d.Cat_codigo,d.Cat_nombre);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex,  "Categoria");
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
                    this.dt.sp_cat_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex,  "Categoria");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            
        }
    }

}
