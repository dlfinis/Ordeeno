using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NPedido
    {

        public DatoSistemasDataContext dt = null;

        /// <summary>
        /// Metodo para Listar Pedido
        /// </summary>
        /// <param name="buscar">Codigo del Pedido</param>
        /// <returns>TPedido</returns>
        public List<TPedido_Foreign> Listar()
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TPedido_Foreign
                             select c).OrderByDescending(c => c.Codigo).ToList<TPedido_Foreign>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }
        /// <summary>
        /// Metodo para Listar Pedido
        /// </summary>
        /// <param name="buscar">Codigo del Pedido</param>
        /// <returns>TPedido</returns>
        public List<TPedido> Listar(int buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TPedido
                             where c.ped_codigo.Equals(buscar)


                             select c).OrderByDescending(c => c.ped_codigo).ToList<TPedido>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }


        public System.Data.DataTable ListarReporte(int numero)
        {
            DataDetallePedidos.TDetalle_Pedido_ForeignDataTable ddt = new DataDetallePedidos.TDetalle_Pedido_ForeignDataTable();

            using (this.dt = new DatoSistemasDataContext())
            {
                var query = from c in this.dt.TDetalle_Pedido_Foreign

                            select c;
                try
                {
                    foreach (TDetalle_Pedido_Foreign c in query)
                    {

                        ddt.Rows.Add(c.PedidoCod, c.ProductoCod);
                    }
                }
                catch { }

            }


            return ddt;
        }
        /// <summary>
        /// Metodo para Listar Productos por Eleccion y Secundaria 
        /// </summary>
        /// <param name="buscar">Cadena a buscar</param>
        /// <param name="opcion">Tipo</param>
        /// <param name="opcion2">Mayor o menor</param>
        /// <returns>TProducto_Foreign</returns>
        public List<TPedido_Foreign> Listar(String buscar, string opcion)
        {




            try
            {


                #region Proveedor

                try
                {





                    using (this.dt = new DatoSistemasDataContext())
                    {

                        return (from p in this.dt.TPedido_Foreign
                                where p.Vendedor.Contains(buscar)
                                || p.IdVendedor.Contains(buscar)
                                select p).OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();



                    }

                }
                catch (Exception ex)
                {

                    throw new Exception("Error al listar \n" + ex.Message);
                }
                #endregion




            }

            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }



        /// <summary>
        /// Metodo para Listar Productos por Eleccion y Secundaria 
        /// </summary>
        /// <param name="buscar">Cadena a buscar</param>
        /// <param name="opcion">Tipo</param>
        /// <param name="opcion2">Mayor o menor</param>
        /// <returns>TProducto_Foreign</returns>
        public List<TPedido_Foreign> Listar(String buscar, string opcion, string opcion2)
        {

            try
            {

                switch (opcion)
                {
                    #region Estado
                    case "Estado":
                        try
                        {



                            using (this.dt = new DatoSistemasDataContext())
                            {
                                if (opcion2.Equals("Factura"))
                                {
                                    return (from p in this.dt.TPedido_Foreign
                                            where p.Estado.Equals("FACTURA")
                                            select p).OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();

                                }
                                else
                                {
                                    return (from p in this.dt.TPedido_Foreign
                                            where p.Estado.Equals("COTIZACION")
                                            select p).OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();

                                }


                            }



                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                    #endregion

                    #region Fecha

                    case "Fecha":
                        try
                        {

                            DateTime fecha;


                            bool nbool = DateTime.TryParse(buscar.Trim(), out fecha);
                            if (nbool && fecha != null)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                        return (from p in this.dt.TPedido_Foreign

                                                select p).Where(p => p.Fecha <= fecha)
                                                    .OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();




                                    }
                                    else
                                    {
                                        return (from p in this.dt.TPedido_Foreign

                                                select p).Where(p => p.Fecha >= fecha)
                                                   .OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();


                                    }


                                }


                            }
                            else
                            {
                                throw new Exception("Ingreso de busqueda incorrecto, solo numeros positivos\n");
                            }
                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                    #endregion


                    #region Total

                    case "Monto":
                        try
                        {

                            double monto = 0.0;


                            bool nbool = Double.TryParse(buscar.Trim(), out monto);
                            if (nbool && monto > -1.0)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                        return (from p in this.dt.TPedido_Foreign
                                                where p.Total <= monto
                                                select p).OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();

                                    }
                                    else
                                    {
                                        return (from p in this.dt.TPedido_Foreign
                                                where p.Total >= monto
                                                select p).OrderByDescending(p => p.Codigo).ToList<TPedido_Foreign>();

                                    }


                                }


                            }
                            else
                            {
                                throw new Exception("Ingreso de busqueda incorrecto, solo numeros positivos\n");
                            }
                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                    #endregion


                    default: return null;


                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Producto");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        public System.Data.DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            System.Data.DataTable dtReturn = new System.Data.DataTable();

            // column names 
            System.Reflection.PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {

                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (System.Reflection.PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new System.Data.DataColumn(pi.Name, colType));
                    }
                }

                System.Data.DataRow dr = dtReturn.NewRow();

                foreach (System.Reflection.PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }


        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TPedido getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TPedido
                            where c.ped_codigo.Equals(codigo)

                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de Pedido
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EPedido d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_ped_insert(d.Prov_codigo, d.Ped_estado, d.Ped_descuento,d.Ped_date);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EPedido d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_ped_edit(d.Ped_codigo, d.Prov_codigo, d.Ped_estado, d.Ped_descuento,d.Ped_date);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
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
                    this.dt.sp_ped_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Pedido");
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
