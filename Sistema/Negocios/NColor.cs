using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NColor
    {
        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar Colores
        /// </summary>
        /// <param name="buscar">Nombre de la color</param>
        /// <returns>TColor</returns>
        public List<TColor> Listar(String buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TColor
                             where c.col_nombre.Contains(buscar)
                             select c).OrderBy(c => c.col_codigo).ToList<TColor>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Color");
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
        public TColor getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TColor
                            where c.col_codigo.Equals(codigo)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Color");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de color
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EColor d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_col_insert(d.Col_nombre);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Color");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EColor d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_col_edit(d.Col_codigo, d.Col_nombre);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Color");
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
                    this.dt.sp_col_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Color");
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
