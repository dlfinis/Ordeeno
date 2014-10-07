using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NTamanio
    {
        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar Tamanioes
        /// </summary>
        /// <param name="buscar">Nombre de la Tamanio</param>
        /// <returns>TTamanio</returns>
        public List<TTamanio> Listar(String buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TTamanio
                             where c.dim_nombre.Contains(buscar)
                             select c).OrderBy(c => c.dim_codigo).ToList<TTamanio>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Tamanio");
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
        public TTamanio getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TTamanio
                            where c.dim_codigo.Equals(codigo)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Tamanio");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de Tamanio
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(ETamanio d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_dim_insert(d.Dim_nombre);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Tamanio");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(ETamanio d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_dim_edit(d.Dim_codigo, d.Dim_nombre);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Tamanio");
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
                    this.dt.sp_dim_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Tamanio");
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
