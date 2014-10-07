using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NVenta
    {

        public DatoSistemasDataContext dt = null;

        /// <summary>
        /// Metodo para Listar Venta
        /// </summary>
        /// <param name="buscar">Codigo del Venta</param>
        /// <returns>TVenta</returns>
        public List<TVenta_Foreign> Listar()
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TVenta_Foreign
                             
                             select c).OrderByDescending(c => c.Codigo).ToList<TVenta_Foreign>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex,"Venta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }
        /// <summary>
        /// Metodo para Listar Venta
        /// </summary>
        /// <param name="buscar">Codigo del Venta</param>
        /// <returns>TVenta</returns>
        public List<TVenta> Listar(int buscar)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = (from c in this.dt.TVenta
                             where c.ven_codigo.Equals(buscar)


                             select c).OrderByDescending(c => c.ven_codigo).ToList<TVenta>();
                    return t.ToList();
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Venta");
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
        DataDetalleVentas.TDetalle_Venta_ForeignDataTable ddt = new DataDetalleVentas.TDetalle_Venta_ForeignDataTable();
       
            using (this.dt = new DatoSistemasDataContext())
        {
            var query = from c in this.dt.TDetalle_Venta_Foreign
                        
                        select c;
            try
            {
                foreach (TDetalle_Venta_Foreign c in query)
                {

                    ddt.Rows.Add(c.VentaCod,c.ProductoCod);
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
        public List<TVenta_Foreign> Listar(String buscar, string opcion)
        {




            try
            {

                
                    #region Persona
                  
                        try
                        {

                   


                           
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                   
                                        return (from p in this.dt.TVenta_Foreign
                                                where p.Comprador.Contains(buscar)
                                                || p.IdComprador.Contains(buscar)
                                                select p).OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();



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
                Datos.Excepciones.Gestionar(ex, "Venta");
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
        public List<TVenta_Foreign> Listar(String buscar, string opcion, string opcion2)
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
                                        return (from p in this.dt.TVenta_Foreign
                                                where p.Estado.Equals("FACTURA")
                                                select p).OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();

                                    }
                                    else
                                    {
                                        return (from p in this.dt.TVenta_Foreign
                                                where p.Estado.Equals("COTIZACION")
                                                select p).OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();

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

                            DateTime fecha ;


                            bool nbool = DateTime.TryParse(buscar.Trim(), out fecha);
                            if (nbool && fecha != null)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                        return (from p in this.dt.TVenta_Foreign
                                               
                                                    select p).Where(p=>p.Fecha <= fecha)
                                                    .OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();
                                                
                                                
                                                

                                    }
                                    else
                                    {
                                        return (from p in this.dt.TVenta_Foreign

                                                select p).Where(p => p.Fecha >= fecha)
                                                   .OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();
                                                

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
                                        return (from p in this.dt.TVenta_Foreign
                                                where p.Total<=monto
                                                select p).OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();

                                    }
                                    else
                                    {
                                        return (from p in this.dt.TVenta_Foreign
                                                where p.Total >= monto
                                                select p).OrderByDescending(p => p.Codigo).ToList<TVenta_Foreign>();

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
        public TVenta getDatos(int codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TVenta
                            where c.ven_codigo.Equals(codigo)
                          
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Venta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }


        }

        /// <summary>
        /// Registro de Venta
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EVenta d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_ven_insert(d.Per_codigo,d.Ven_estado,d.Ven_descuento,d.Ven_date);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Venta");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        public void Editar(EVenta d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_ven_edit(d.Ven_codigo, d.Per_codigo, d.Ven_estado,d.Ven_descuento,d.Ven_date);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Venta");
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
                    this.dt.sp_ven_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Venta");
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
