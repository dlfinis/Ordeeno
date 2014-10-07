using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NDetallePedido
    {

        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar DetallePedido
        /// </summary>
        /// <param name="buscar">Codigo del DetallePedido</param>
        /// <returns>TDetallePedido</returns>
        public List<TDetalle_Pedido> Listar(int buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalle_Pedido
                             where c.ped_codigo.Equals(buscar)


                             select c).OrderBy(c => c.ped_codigo).ToList<TDetalle_Pedido>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }

        /// <summary>
        /// Metodo para Listar DetallePedido
        /// </summary>
        /// <param name="buscar">Codigo del DetallePedido</param>
        /// <returns>TDetallePedido</returns>
        public List<TDetalle_Pedido> Listar(int buscar, int producto)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalle_Pedido
                             where c.ped_codigo.Equals(buscar)
                             && c.prod_codigo.Equals(producto)


                             select c).OrderBy(c => c.ped_codigo).ToList<TDetalle_Pedido>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }



        /// <summary>
        /// Metodo para Listar DetallePedido
        /// </summary>
        /// <param name="buscar">Codigo del DetallePedido</param>
        /// /// <param name="producto">Codigo del Producto</param>
        /// <returns>TDetallePedido</returns>
        public List<TDetalle_Pedido_Producto> ListarP(int buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalle_Pedido_Producto
                             where c.CodVen.Equals(buscar)

                             select c).OrderBy(c => c.CodVen).ToList<TDetalle_Pedido_Producto>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
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
        public TDetalle_Pedido getDatos(int codigo, int codprod)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TDetalle_Pedido
                            where c.ped_codigo.Equals(codigo)
                            && c.prod_codigo.Equals(codprod)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de DetallePedido
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EDetallePedido d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_det_pedido_insert(
                        d.Ped_codigo, d.Prod_codigo,
                        d.Dped_precio, d.Cantidad);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EDetallePedido d)
        {

            try
            {

                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_det_pedido_edit(d.Ped_codigo, d.Prod_codigo,
                       d.Dped_precio, d.Cantidad);

                }





            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }
        public void Eliminar(int codigo, int producto)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_det_pedido_delete(codigo, producto);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetallePedido");
                System.Windows.Forms.MessageBox.Show(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

    }
}
