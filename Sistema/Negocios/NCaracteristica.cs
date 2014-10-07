using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;
namespace Negocios
{
    public class NCaracteristica
    {
        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar Caracteristicas
        /// </summary>
        /// <param name="buscar">Nombre de la caracteristica</param>
        /// <returns>TCaracteristica</returns>
        public List<TCaracteristica_Detalle> Listar(String buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TCaracteristica_Detalle
                             where c.Tipo.Contains(buscar) 
                             select c).OrderBy(c => c.Codigo).ToList<TCaracteristica_Detalle>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Caracteristica");
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
        public TCaracteristica getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TCaracteristica
                            where c.car_codigo.Equals(codigo)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Caracteristica");
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
        public TCaracteristica getDatos(string nombre)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TCaracteristica
                            where c.car_tipo.Contains(nombre)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Caracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }




        /// <summary>
        /// Registro de caracteristica
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(ECaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_car_insert(d.Car_tipo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Caracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(ECaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_car_edit(d.Car_codigo, d.Car_tipo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Caracteristica");
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
                    this.dt.sp_car_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Caracteristica");
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