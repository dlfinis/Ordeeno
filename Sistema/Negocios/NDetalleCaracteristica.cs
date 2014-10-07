using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;
namespace Negocios
{
    public class NDetalleCaracteristica
    {
        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar Caracteristicas
        /// </summary>
        /// <param name="buscar">Nombre de la caracteristica</param>
        /// <returns>TCaracteristica</returns>
        public List<TDetalleProducto_Caracteristica> Listar(int dcarcodigo,int prodcodigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalleProducto_Caracteristica
                               where c.CodDCar.Equals(dcarcodigo) &&
                                     c.Codigo.Equals(prodcodigo)
                                     
                             select c).OrderBy(c => c.CodDCar).ToList<TDetalleProducto_Caracteristica>();
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
        /// Metodo para Listar Caracteristicas
        /// </summary>
        /// <param name="buscar">Nombre de la caracteristica</param>
        /// <returns>TCaracteristica</returns>
        public List<TDetalleProducto_Caracteristica> Listar(string dcar, int prodcodigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalleProducto_Caracteristica
                             where c.Tipo.Contains(dcar) &&
                                   c.Codigo.Equals(prodcodigo)

                             select c).OrderBy(c => c.CodDCar).ToList<TDetalleProducto_Caracteristica>();
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
        public TDetalleProducto_Caracteristica getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TDetalleProducto_Caracteristica
                            where c.CodDCar.Equals(codigo)
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
        public bool existCaracteristica(string tipo,int dcarcodigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                 
                    var t = from c in this.dt.TDetalleProducto_Caracteristica
                            

                            
                            where c.Tipo.Contains(tipo) &&
                                  c.CodDCar.Equals(dcarcodigo)
                            select c;

                    //System.Windows.Forms.MessageBox.Show(t.ToList().Count+"\n"+tipo+"\n"+dcarcodigo);
                    return t.ToList().Count>0 ? true :false;

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


        public String existValor(string valor, int dcarcodigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {

                    var t = from c in this.dt.TDetalleProducto_Caracteristica



                            where c.Valor.Contains(valor) &&
                                  c.CodDCar.Equals(dcarcodigo)
                            select c;

                    //System.Windows.Forms.MessageBox.Show(t.ToList().Count+"\n"+tipo+"\n"+dcarcodigo);
                    return t.Distinct().ToList().Count>0 ?t.Single().Tipo:"" ;

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
        public int Insertar(EDetalleCaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_dcar_insert(d.Dcar_codigo,d.Car_tipo,d.Car_valor);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DCaracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EDetalleCaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_dcar_edit(d.Dcar_codigo, d.Car_tipo, d.Car_valor);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DCaracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }
        public void Eliminar(EDetalleCaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_dcar_delete(d.Dcar_codigo,d.Car_tipo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DCaracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void EliminarDetalle(int codigo)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_dcar_delete_complete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DCaracteristica");
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