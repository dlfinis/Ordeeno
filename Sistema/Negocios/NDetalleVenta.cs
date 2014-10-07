using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NDetalleVenta
    {

        public DatoSistemasDataContext dt = null;
        /// <summary>
        /// Metodo para Listar DetalleVenta
        /// </summary>
        /// <param name="buscar">Codigo del DetalleVenta</param>
        /// <returns>TDetalleVenta</returns>
        public List<TDetalle_Venta> Listar(int buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalle_Venta
                             where c.ven_codigo.Equals(buscar)


                             select c).OrderBy(c => c.ven_codigo).ToList<TDetalle_Venta>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }

        /// <summary>
        /// Metodo para Listar DetalleVenta
        /// </summary>
        /// <param name="buscar">Codigo del DetalleVenta</param>
        /// <returns>TDetalleVenta</returns>
        public List<TDetalle_Venta> Listar(int buscar,int producto)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalle_Venta
                             where c.ven_codigo.Equals(buscar)
                             && c.prod_codigo.Equals(producto)


                             select c).OrderBy(c => c.ven_codigo).ToList<TDetalle_Venta>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }



        /// <summary>
        /// Metodo para Listar DetalleVenta
        /// </summary>
        /// <param name="buscar">Codigo del DetalleVenta</param>
        /// /// <param name="producto">Codigo del Producto</param>
        /// <returns>TDetalleVenta</returns>
        public List<TDetalle_Venta_Producto> ListarP(int buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TDetalle_Venta_Producto
                             where c.CodVen.Equals(buscar)
                                   
                             select c).OrderBy(c => c.CodVen).ToList<TDetalle_Venta_Producto>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
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
        public TDetalle_Venta getDatos(int codigo, int codprod)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TDetalle_Venta
                            where c.ven_codigo.Equals(codigo)
                            && c.prod_codigo.Equals(codprod)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de DetalleVenta
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EDetalleVenta d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_det_venta_insert(d.Ven_codigo, d.Prod_codigo,
                        d.Dven_precio, d.Cantidad, d.Dven_descuento, d.Dven_aumento);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EDetalleVenta d)
        {
            
            try
            {
                
                    using (this.dt = new DatoSistemasDataContext())
                    {
                        this.dt.sp_det_venta_edit(d.Ven_codigo, d.Prod_codigo,
                           d.Dven_precio, d.Cantidad, d.Dven_descuento, d.Dven_aumento);

                    }
              
                   
              


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }
        public void Eliminar(int codigo,int producto)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_det_venta_delete(codigo, producto);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "DetalleVenta");
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
