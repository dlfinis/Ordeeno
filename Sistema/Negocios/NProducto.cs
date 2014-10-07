using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocios.Entidades;

namespace Negocios
{
    public class NProducto
    {


        public DatoSistemasDataContext dt = null;



      
        public String ListarCaracteristica(int codprod)
        {

            String temp="";
            List<String> ltemp;
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {



                    //cr.Valor.Contains(buscar) && 
                    //                cr.Tipo.Contains("Color")    



                    var t= (from cr in this.dt.TDetalleProducto_Caracteristica
                            

                            where

                                 cr.Codigo.Equals(codprod) &&
                                !cr.Valor.Contains("NINGUN")

                            select cr.Valor);

                   ltemp= t.ToList();

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

            foreach (String s in ltemp)
            {
                temp += s + " ";
            
            }
            return temp;

        }


        /// <summary>
        /// Metodo para Listar Productos por Nombres
        /// </summary>
        /// <param name="buscar">Nombre de la Producto</param>
        /// <returns>TProducto_Caracteristica_Foreign</returns>
        public List<String> ListarCaracteristicas(String tipo)
        {

            
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {



                    //cr.Valor.Contains(buscar) && 
                    //                cr.Tipo.Contains("Color")    


                    if (tipo.Contains("COLOR"))
                    {
                        return (
                                from cr in this.dt.TColor







                                select cr.col_nombre).ToList();

                    
                    }

                    if (tipo.Contains("TAMANIO"))
                    {
                        return (
                                from cr in this.dt.TTamanio







                                select cr.dim_nombre).Distinct().ToList();

                    }

                    return (
                             from cr in this.dt.TDetalleProducto_Caracteristica


                             where

                             cr.Tipo.Contains(tipo)


                             select cr.Valor).Distinct().ToList();

                   

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

        
        /// <summary>
        /// Metodo para Listar Productos por Nombres
        /// </summary>
        /// <param name="buscar">Nombre de la Producto</param>
        /// <returns>TProducto_Caracteristica_Foreign</returns>
        public List<TProducto_Caracteristica_Foreign> Listar(String buscar)
        {


                List<String> lbsq = buscar.TrimEnd().TrimStart().Split(' ').ToList();

               // System.Windows.Forms.MessageBox.Show(lbsq.Count+" "+buscar);
                //lbsq.ForEach(p => System.Windows.Forms.MessageBox.Show("vacio" + p));
                
                    

                

            string sql="";
            string like="";
           
            string token="%";
            string ap="'";
            string or =" or ";
            double valor = 0.0;
            try
            {
                sql = @"SELECT  *  FROM TProducto_Caracteristica_Foreign WHERE ";

                like = " Nombre like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " CodProd like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " Marca like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " Unidad like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " Categoria like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " Descripcion like " + ap + token + lbsq[0] + token + ap + "\n";
                if (Double.TryParse(lbsq[0], out valor))
                {
                    like += or + "Stock between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                            or + "Compra between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                            or + "Venta between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                            or + "VentaConIVA between " + (valor - 10) + " and " + (valor + 10)+ "\n";
                }

                if (lbsq.Count >0 )
               
                {
                    sql = @"SELECT  *  FROM TProducto_Caracteristica_Foreign WHERE ";

                    like = " Nombre like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " CodProd like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " Marca like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " Unidad like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " Categoria like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " Descripcion like " + ap + token + lbsq[0] + token + ap + "\n";

                    if (Double.TryParse(lbsq[0], out valor))
                    {
                        like += or + "Stock between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                or + "Compra between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                or + "Venta between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                or + "VentaConIVA between " + (valor - 10) + " and " + (valor + 10)+ "\n";
                    }
                        for (int i = 1; i < lbsq.Count; i++)
                        {


                            like += 
                            or +" Nombre like " + ap + token + lbsq[i] + token + ap +"\n" +
                            or+" CodProd like " + ap + token + lbsq[i] + token + ap +"\n"+
                            or+" Marca like " + ap + token + lbsq[i] + token + ap +"\n"+
                            or+" Unidad like " + ap + token + lbsq[i] + token + ap +"\n"+
                            or+" Categoria like " + ap + token + lbsq[i] + token + ap +"\n"+
                            or+" Descripcion like " + ap + token + lbsq[i] + token + ap+"\n" ;
                            if (Double.TryParse(lbsq[i], out valor))
                            {
                                like += or + "Stock between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                        or + "Compra between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                        or + "Venta between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                        or + "VentaConIVA between " + (valor - 10) + " and " + (valor + 10)+ "\n";
                            }

                        }

                    


                    string query = string.Format(sql+like);
                    

                    using (this.dt = new DatoSistemasDataContext())
                    {
                        
                       
                        //var results = dt.ExecuteQuery<TProducto_Caracteristica_Foreign>(query)
                        //    .Distinct().OrderBy(p => p.CodProd.Substring(p.CodProd.IndexOf('-') < 0 ? p.CodProd.Length : p.CodProd.IndexOf('-')) + ""
                        //).
                        //               ThenBy(p => p.CodProd.Substring(p.CodProd.IndexOf('-') > 0 ? p.CodProd.IndexOf('-') : p.CodProd.Length) + ""
                        //).ToList();

                        var results = dt.ExecuteQuery<TProducto_Caracteristica_Foreign>(query)
                           .Distinct().OrderBy(p => p.CodProd).ThenBy(p => p.Categoria).ToList();

                        return results;
                    }

                }
                else
                {
                    if (Double.TryParse(buscar, out valor))
                    {
                        var tmp = (from prd in dt.TProducto_Caracteristica_Foreign
                                   where
                                       prd.Stock < valor - 10 && prd.Stock > valor + 10 ||
                                       prd.Compra < valor - 10 && prd.Stock > valor + 10 ||
                                       prd.Venta < valor - 10 && prd.Stock > valor + 10 ||
                                       prd.VentaConIVA < valor - 10 && prd.Stock > valor + 10

                                   select prd).Distinct().OrderBy(p => p.CodProd).ThenBy(p => p.Categoria).ToList();


                        return tmp;
                    }
                    else
                    {
                        using (this.dt = new DatoSistemasDataContext())
                        {
                            var tmp = (from prd in dt.TProducto_Caracteristica_Foreign
                                       where
                                            prd.CodProd.Contains(buscar) ||

                                            prd.Nombre.Contains(buscar) ||
                                            prd.Marca.Contains(buscar) ||
                                            prd.Unidad.Contains(buscar) ||
                                            prd.Categoria.Contains(buscar) ||
                                            prd.Descripcion.Contains(buscar)

                                       select prd).Distinct().OrderBy(p => p.CodProd).ThenBy(p => p.Categoria).ToList();


                            return tmp;

                        }
                    }

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


        /// <summary>
        /// Metodo para Listar Productos por Nombres
        /// </summary>
        /// <param name="buscar">Nombre de la Producto</param>
        /// <returns>TProducto_Caracteristica_Foreign</returns>
        public List<TProducto_Caracteristica_Foreign> ListarSeleccion(String buscar)
        {


            List<String> lbsq = buscar.TrimEnd().TrimStart().Split(' ').ToList();

            // System.Windows.Forms.MessageBox.Show(lbsq.Count+" "+buscar);
            //lbsq.ForEach(p => System.Windows.Forms.MessageBox.Show("vacio" + p));
            string sql = "";
            string like = "";

            string token = "%";
            string ap = "'";
            string or = " or ";
            double valor=0.0;

            try
            {
                sql = @"SELECT  *  FROM TProducto_Caracteristica_Foreign WHERE ";


                like = " Nombre like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " CodProd like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " Marca like " + ap + token + lbsq[0] + token + ap + "\n" +
                        or + " Unidad like " + ap + token + lbsq[0] + token + ap + "\n";

                if (Double.TryParse(lbsq[0], out valor))
                {
                    like += or + "Stock between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                            or + "Compra between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                            or + "Venta between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                            or + "VentaConIVA between " + (valor - 10) + " and " + (valor + 10)+ "\n";
                }


                if (lbsq.Count > 0)
                {
                    sql = @"SELECT  *  FROM TProducto_Caracteristica_Foreign WHERE ";

                    like = " Nombre like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " CodProd like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " Marca like " + ap + token + lbsq[0] + token + ap + "\n" +
                            or + " Unidad like " + ap + token + lbsq[0] + token + ap + "\n";
                  
                    
                    if (Double.TryParse(lbsq[0], out valor))
                    {
                        like += or + "Stock between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                or + "Compra between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                or + "Venta between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                or + "VentaConIVA between " + (valor - 10) + " and " + (valor + 10)+ "\n";
                    }

                          

                    for (int i = 1; i < lbsq.Count; i++)
                    {


                        like +=
                        or + " Nombre like " + ap + token + lbsq[i] + token + ap + "\n" +
                        or + " CodProd like " + ap + token + lbsq[i] + token + ap + "\n" +
                        or + " Marca like " + ap + token + lbsq[i] + token + ap + "\n" +
                        or + " Unidad like " + ap + token + lbsq[i] + token + ap + "\n";

                        if (Double.TryParse(lbsq[0], out valor))
                        {
                            like += or + "Stock between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                    or + "Compra between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                    or + "Venta between " + (valor - 10) + " and " + (valor + 10)+ "\n" +
                                    or + "VentaConIVA between " + (valor - 10) + " and " + (valor + 10)+ "\n";
                        }

                      


                    }




                    string query = string.Format(sql + like);


                    using (this.dt = new DatoSistemasDataContext())
                    {


                        //var results = dt.ExecuteQuery<TProducto_Caracteristica_Foreign>(query)
                        //    .Distinct().OrderBy(p => p.CodProd.Substring(p.CodProd.IndexOf('-') < 0 ? p.CodProd.Length : p.CodProd.IndexOf('-')) + ""
                        //).
                        //               ThenBy(p => p.CodProd.Substring(p.CodProd.IndexOf('-') > 0 ? p.CodProd.IndexOf('-') : p.CodProd.Length) + ""
                        //).ToList();
                       // System.Windows.Forms.MessageBox.Show(query);
                        var results = dt.ExecuteQuery<TProducto_Caracteristica_Foreign>(query)
                           .Distinct().OrderBy(p => p.CodProd).ThenBy(p => p.Categoria).ToList();

                        return results;
                    }

                }
                else
                {

                    using (this.dt = new DatoSistemasDataContext())
                    {

                        if (Double.TryParse(buscar, out valor))
                        {
                            var tmp = (from prd in dt.TProducto_Caracteristica_Foreign
                                       where
                                           prd.Stock < valor -10 && prd.Stock > valor +10 ||
                                           prd.Compra < valor -10 && prd.Stock > valor +10 ||
                                           prd.Venta < valor -10 && prd.Stock > valor +10 ||
                                           prd.VentaConIVA < valor -10 && prd.Stock > valor +10 

                                       select prd).Distinct().OrderBy(p => p.CodProd).ThenBy(p => p.Categoria).ToList();

                            return tmp;
                        }
                        else
                        {
                            var tmp = (from prd in dt.TProducto_Caracteristica_Foreign
                                       where
                                            prd.CodProd.Contains(buscar) ||

                                            prd.Nombre.Contains(buscar) ||
                                            prd.Marca.Contains(buscar) ||
                                            prd.Unidad.Contains(buscar) 
                                           

                                       select prd).Distinct().OrderBy(p => p.CodProd).ThenBy(p => p.Categoria).ToList();

                            return tmp;

                        }
                    }

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

        public System.Data.DataTable getDataTable()
        {
            using (this.dt = new DatoSistemasDataContext())
            {
               
                var tmp = (from prd in dt.TProducto_Caracteristica_Foreign
                          

                           select prd).First();
                var t = Listar("").AsEnumerable().ToList();


            
                //IEnumerable<System.Data.DataRow> query = (IEnumerable<System.Data.DataRow>)(from p in dt.TProducto_Caracteristica_Foreign.AsEnumerable()
                  //                                       select p).First();
               
                
            // Create a table from the query.
                System.Data.DataTable boundTable = LINQToDataTable(t);

                return boundTable;
               
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
                    ==typeof(Nullable<>)))
                     {
                         colType = colType.GetGenericArguments()[0];
                     }

                    dtReturn.Columns.Add(new System.Data.DataColumn(pi.Name, colType));
               }
          }

          System.Data.DataRow dr = dtReturn.NewRow();

          foreach (System.Reflection.PropertyInfo pi in oProps)
          {
               dr[pi.Name] = pi.GetValue(rec, null) == null ?DBNull.Value :pi.GetValue
               (rec,null);
          }

          dtReturn.Rows.Add(dr);
     }
     return dtReturn;
}

        #region PMetodo
        /// <summary>
        /// Metodo para Listar Productos por Nombres
        /// </summary>
        /// <param name="buscar">Nombre de la Producto</param>
        /// <returns>TProducto_Caracteristica_Foreign</returns>
        //public List<TProducto_Caracteristica_Foreign> ListarPB(String buscar)
        //{



        //    List<TProducto_Caracteristica_Foreign> lpr;
        //    List<TDetalleProducto_Caracteristica> ldcar;
        //    try
        //    {
        //        using (this.dt = new DatoSistemasDataContext())
        //        {



        //            //cr.Valor.Contains(buscar) && 
        //            //                cr.Tipo.Contains("Color")    

        //            var tvm = (from p in this.dt.TProducto_Caracteristica_Foreign

        //                       select p);

                   
                   

        //            var tvc=(from cr in this.dt.TDetalleProducto_Caracteristica
        //                    select cr);
        //            ldcar=tvc.ToList();
        //            lpr = tvm.ToList();

                  
        //        }
        //        foreach (Datos.TProducto_Caracteristica_Foreign pr in lpr)
        //        {

        //            pr.Nombre += " " + ListarCaracteristica(pr.Codigo);
        //            // System.Windows.Forms.MessageBox.Show(buscar + "====" + pr.Nombre + " 1");

        //        }


        //        int cn = 0, pst = 0; ;
        //        List<String> lbsq = new List<String>();
        //        string bsq= buscar.TrimEnd().TrimStart();
        //        string temp = "";
        //        foreach(char ps in bsq )
        //        {

        //            if (!ps.Equals(' '))
        //            {
        //                temp += ps;


        //                lbsq.Add(temp);
        //                //System.Windows.Forms.MessageBox.Show(temp);


        //            }
        //            else
        //            {
        //                temp ="";
        //                    //System.Windows.Forms.MessageBox.Show("Vacio");
        //            }
              
        //        }

        //        if (lbsq.Count > 1)
        //        {
        //            List<TProducto_Caracteristica_Foreign> ltmp = new List<TProducto_Caracteristica_Foreign>(); 
        //            for (int i = 0; i < lbsq.Count; i++)
        //            {
        //                var t = (from p in lpr
        //                         from cr in ldcar
        //                        .Where(cr => cr.Codigo.Equals(p.Codigo)).DefaultIfEmpty()
        //                         where

        //                               p.CodProd.Contains(buscar) ||
        //                               cr.Valor.Contains(buscar) ||

        //                               p.Nombre.Contains(lbsq[i]) ||
        //                               p.Marca.Contains(buscar) ||
        //                               p.Unidad.Contains(buscar) ||
        //                               p.Categoria.Contains(buscar) ||
        //                               p.Descripcion.Contains(buscar)

        //                         select p).Distinct().Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();
        //                ltmp = t;
        //                string sql = string.Format("");
        //                 using (this.dt = new DatoSistemasDataContext())
        //                 {

                             
        //                    var results = dt.ExecuteQuery<TProducto_Caracteristica_Foreign>
        //                  (@"SELECT contactname FROM customers WHERE city = {0}",
        //                            "London");
        //                 }
        //            }

        //            return ltmp;


        //        }
        //        else
        //        {
        //            var t = (from p in lpr
        //                     from cr in ldcar
        //                    .Where(cr => cr.Codigo.Equals(p.Codigo)).DefaultIfEmpty()
        //                     where

        //                           p.CodProd.Contains(buscar) ||
        //                           cr.Valor.Contains(buscar) ||

        //                           p.Nombre.Contains(buscar) ||
        //                           p.Marca.Contains(buscar) ||
        //                           p.Unidad.Contains(buscar) ||
        //                           p.Categoria.Contains(buscar) ||
        //                           p.Descripcion.Contains(buscar)

        //                     select p).Distinct().Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

        //            return t;
                
        //        }
               

                




        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex, "Producto");
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex);
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }

        //    //foreach (Datos.TProducto_Caracteristica_Foreign pr in ltpr)
        //    //{
             
        //    //    pr.Nombre +=" "+ ListarCaracteristica(pr.Codigo);
        //    //   // System.Windows.Forms.MessageBox.Show(buscar + "====" + pr.Nombre + " 1");
        //    //    if (pr.Nombre.Contains(buscar))
        //    //    {
        //    //        System.Windows.Forms.MessageBox.Show(buscar + "====" + pr.Nombre + " 2");
        //    //    }

        //    //    lpr.Add(pr); 
                   
                
        //    //}

        //    //var tm = lpr.Where(p => p.Nombre.Contains(buscar));
        //    //return tm.ToList();

        //}

        ///// <summary>
        ///// Metodo para Listar Productos por Nombres
        ///// </summary>
        ///// <param name="buscar">Nombre de la Producto</param>
        ///// <returns>TProducto_Caracteristica_Foreign</returns>
        //public List<TProducto_Caracteristica_Foreign> ListarM(String buscar)
        //{



        //    List<TProducto_Caracteristica_Foreign> lpr = Listar(buscar);
        //    List<TProducto_Caracteristica_Foreign> ltpr = new List<TProducto_Caracteristica_Foreign>();
        //    try
        //    {
                
        //    foreach (Datos.TProducto_Caracteristica_Foreign pr in lpr)
        //    {
                
               

        //            ltpr.Add(pr);

                

        //    }



        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex, "Producto");
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex);
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }

        //    return ltpr;

        //}


        ///// <summary>
        ///// Metodo para Listar Productos por Nombres
        ///// </summary>
        ///// <param name="buscar">Nombre de la Producto</param>
        ///// <returns>TProducto_Caracteristica_Foreign</returns>
        //public List<TProducto_Caracteristica_Foreign> ListarN(String nbuscar)
        //{

        //    List<TProducto_Caracteristica_Foreign> lpr = new List<TProducto_Caracteristica_Foreign>();
        //    List<TProducto_Caracteristica_Foreign> ltpr;
        //    try
        //    {
        //        using (this.dt = new DatoSistemasDataContext())
        //        {



        //            //cr.Valor.Contains(buscar) && 
        //            //                cr.Tipo.Contains("Color")    



        //            var t = (from p in this.dt.TProducto_Caracteristica_Foreign
        //                     from cr in this.dt.TDetalleProducto_Caracteristica
        //                     .Where(cr => cr.Codigo == p.Codigo).DefaultIfEmpty()

        //                     where

        //                           p.CodProd.Contains(nbuscar)


        //                     select p).Distinct().Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

        //            ltpr = t;


        //        }




        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex, "Producto");
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex);
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }

        //    foreach (Datos.TProducto_Caracteristica_Foreign pr in ltpr)
        //    {
        //        pr.Nombre += " " + ListarCaracteristica(pr.Codigo);
        //        lpr.Add(pr);

        //    }
        //    return lpr;

        //}

        #endregion

        /// <summary>
        /// Metodo para Listar Productos por Eleccion
        /// </summary>
        /// <param name="buscar">Cadena a buscar</param>
        ///  <param name="opcion">Tipo</param>
        /// <returns>TProducto_Caracteristica_Foreign</returns>
        public List<TProducto_Caracteristica_Foreign> Listar(String buscar, string opcion)
        {
          
            try
            {
                #region
                switch (opcion)
                {

                    case "Seleccione":
                        try
                        {
                            return Listar(buscar);
                            

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }

                    case "CodigoProd":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                var t = (from p in this.dt.TProducto_Caracteristica_Foreign
                                         where p.CodProd.Contains(buscar)
                                         select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                return t;
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
                                var t = (from p in this.dt.TProducto_Caracteristica_Foreign
                                        where p.Nombre.Contains(buscar)
                                         select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                            

                                
                                return t;



                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                    
                  

                    case "Descripcion":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                var t = (from p in this.dt.TProducto_Caracteristica_Foreign
                                        where p.Descripcion.Contains(buscar)
                                        select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                return t;
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }


                     

                    case "Categoria":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                var t = (from p in this.dt.TProducto_Caracteristica_Foreign
                                        where p.Categoria.Contains(buscar)
                                      select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();


                                return t;
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                     
                    case "Unidad":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                              var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                        where p.Unidad.Contains(buscar)
                                      select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();


                              return t;
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                     
                    case "Marca":
                        try
                        {
                            using (this.dt = new DatoSistemasDataContext())
                            {
                                var t = (from p in this.dt.TProducto_Caracteristica_Foreign
                                        where p.Marca.Contains(buscar)
                                        select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();


                                return t;
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }

                   
                    default: 
                        
                        try
                        {


                            //System.Windows.Forms.MessageBox.Show(opcion+"}"+buscar);
                           
                            using (this.dt = new DatoSistemasDataContext())
                            {
                               
                                  
                                     
                               //cr.Valor.Contains(buscar) && 
                                 //                cr.Tipo.Contains("Color")    
                      var t= (from c in this.dt.TCaracteristica
                                           join d in this.dt.TDetalle_Caracteristica
                                           on c.car_codigo equals d.car_codigo
                                           join p in this.dt.TProducto_Caracteristica_Foreign
                                           on d.dcar_codigo equals p.CodDcar
                                           where c.car_tipo.Contains(opcion) &&
                                                 d.car_valor.Contains(buscar)

                                          select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                              return t;
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }

                      

                }
                #endregion

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


        /// <summary>
        /// Metodo para Listar Productos por Eleccion y Secundaria 
        /// </summary>
        /// <param name="buscar">Cadena a buscar</param>
        /// <param name="opcion">Tipo</param>
        /// <param name="opcion2">Mayor o menor</param>
        /// <returns>TProducto_Caracteristica_Foreign</returns>
        public List<TProducto_Caracteristica_Foreign> Listar(String buscar, string opcion,string opcion2)
        {
        
            
            try
            {
                
                switch (opcion)
                {

                    case "Seleccione":
                        try
                        {
                            return Listar(buscar);


                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);

                        }
                  #region StockMinimo
                    case "StockMinimo":
                        try
                        {

                            int stockmin = 0;
                      

                            bool nbool = Int32.TryParse(buscar.Trim(), out stockmin);
                            if (nbool && stockmin > -1)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                       var t=(from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.StockMin <= stockmin
                                              select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                      return t;
                                    }
                                    else
                                    {
                                        var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.StockMin >= stockmin
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
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
                        
                  #region Stock
                    
                    case "Stock":
                        try
                        {

                            int stock = 0;
                      

                            bool nbool = Int32.TryParse(buscar.Trim(), out stock);
                            if (nbool && stock > -1)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                        var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.Stock <= stock
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
                                    }
                                    else
                                    {
                                        var t=(from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.Stock >= stock
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
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
                        
                    #region IVA

                    case "IVA":
                        try
                        {

                            
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Si"))
                                    {
                                        var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.IVA.Equals(Convert.ToChar("S"))
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
                                    }
                                    else
                                    {
                                        var t=(from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.IVA.Equals(Convert.ToChar("N"))
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
                                    }


                                }


                            
                        }
                        catch (Exception ex)
                        {

                            throw new Exception("Error al listar \n" + ex.Message);
                        }
                    #endregion
                        
                    #region Compra

                    case "Compra":
                        try
                        {

                            double compra= 0.0;


                            bool nbool = Double.TryParse(buscar.Trim(), out compra);
                            if (nbool && compra > -1.0)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                      var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.Compra <= compra
                                              select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                     return t;
                                    }
                                    else
                                    {
                                        var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.Compra >= compra
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
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
                        
                    #region Venta

                    case "Venta":
                        try
                        {

                            double venta = 0.0;


                            bool nbool = Double.TryParse(buscar.Trim(), out venta);
                            if (nbool && venta > -1.0)
                            {
                                using (this.dt = new DatoSistemasDataContext())
                                {
                                    if (opcion2.Equals("Menor"))
                                    {
                                      var t=(from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.Venta <= venta  ||
                                                      p.VentaConIVA <= venta
                                             select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                     return t;
                                    }
                                    else
                                    {
                                        var t= (from p in this.dt.TProducto_Caracteristica_Foreign
                                                where p.Venta >= venta
                                                ||
                                                      p.VentaConIVA >= venta
                                                select p).Distinct().OrderBy(p => p.Categoria).ThenBy(p => p.CodProd).ToList();

                                       return t;
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

                    default: return null;
                    #endregion
                  


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

        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public bool getCodProd(string codigo)
        {

            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProducto_Caracteristica_Foreign
                            where c.CodProd.Contains(codigo)
                            select c;
                    return t.ToList().Count>0 ? true :false;

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


        ///// <summary>
        ///// Metodo para obtener el registro deseado
        ///// </summary>
        ///// <param name="codigo"></param>
        ///// <returns></returns>
        //public TProducto_Foreign getDatos(int codigo)
        //{
        //    TProducto_Foreign single = new TProducto_Foreign();
        //    try
        //    {
        //        using (this.dt = new DatoSistemasDataContext())
        //        {
        //            var t = from c in this.dt.TProducto_Foreign
        //                    where c.Codigo.Equals(codigo)
        //                    select c;
        //            return t.Single();

        //        }

        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex, "Producto");
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);

        //    }
        //    catch (Exception ex)
        //    {
        //        Datos.Excepciones.Gestionar(ex);
        //        throw new Exception(Datos.Excepciones.MensajePersonalizado);
        //    }

        //}


        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TProducto getDatosBase(int codigo)
        {
              try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProducto
                            where c.pro_codigo.Equals(codigo)
                            select c;
                    return t.Single();

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

        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TProducto_Caracteristica_Foreign getDatos(int codigo)
        {
            TProducto_Foreign single = new TProducto_Foreign();
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProducto_Caracteristica_Foreign
                            where c.Codigo.Equals(codigo)
                            select c;
                    return t.Single();

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


        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TProducto_Caracteristica_Foreign getDatosCar(int codigo)
        {
            TProducto_Caracteristica_Foreign single = new TProducto_Caracteristica_Foreign();
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProducto_Caracteristica_Foreign
                            where c.Codigo.Equals(codigo)
                            select c;
                    return t.Single();

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
               
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        /// <summary>
        /// Registro de Producto
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EProducto d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_prod_insert(d.Codprod_codigo,d.Prod_nombre,
                                                 d.Cat_nombre,
                                                 d.Mar_nombre,
                                                 d.Uni_nombre,
                                                 d.Dcar_codigo,
                                                 d.Prod_descripcion,
                                               
                                                 d.Prod_compra,
                                                 d.Prod_venta,
                                                 d.Prod_iva,
                                                 d.Prod_stock_min,
                                                 d.Prod_stock);

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

        public void Editar(EProducto d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_prod_edit(d.Prod_codigo,d.Codprod_codigo, d.Prod_nombre,
                                                 d.Cat_nombre,
                                                 d.Mar_nombre,
                                                 d.Uni_nombre,
                                                 d.Dcar_codigo,
                                                 d.Prod_descripcion,
                                                 
                                                 d.Prod_compra,
                                                 d.Prod_venta,
                                                 d.Prod_iva,
                                                 d.Prod_stock_min,
                                                 d.Prod_stock);

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
        public void Eliminar(int codigo)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_prod_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Producto");
                System.Windows.Forms.MessageBox.Show((Datos.Excepciones.MensajePersonalizado));
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                System.Windows.Forms.MessageBox.Show((Datos.Excepciones.MensajePersonalizado));
            }
        }


       
        public double getAumento(double compra)
        {
            EProducto d = new EProducto();
            return (compra + compra * d.Prod_aumento);
        
        }

        public int getCantidadMinima()
        {
            EProducto d = new EProducto();
            return d.Prod_mincantidad;

        }

        public double getIVA_Valor()
        {
            EProducto d = new EProducto();
            return d.Prod_iva_valor;

        }


    }

}

