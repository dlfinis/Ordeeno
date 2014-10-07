using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Negocios.Entidades;

namespace Negocios
{
    public class NProducto_Caracteristica
    {
        public DatoSistemasDataContext dt = null;


      
    

        /// <summary>
        /// Metodo para obtener el registro deseado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public TProducto_Caracteristica getDatos(int codigo)
        {
            TProducto_Caracteristica df = new TProducto_Caracteristica();
            df.dcar_codigo = 0;
            df.prod_codigo = 0;
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    var t = from c in this.dt.TProducto_Caracteristica
                            where c.prod_codigo.Equals(codigo)
                            select c;

                    if (t.ToList().Count>0)
                        return t.Single();
                    else
                        return df;

                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Producto_Caracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }

        }
    


        /// <summary>
        /// Ingreso de caracteristica producto
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public int Insertar(EProductoCaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    return this.dt.sp_pcar_insert(d.Prod_codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Producto_Caracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }

        
        /// <summary>
        /// Edicion de caracteristica producto
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public void Editar(EProductoCaracteristica d)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                     this.dt.sp_pcar_edit(d.Dcar_codigo,d.Prod_codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Producto_Caracteristica");
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                throw new Exception(Datos.Excepciones.MensajePersonalizado);
            }
        }


        /// <summary>
        /// Eliminacion de caracteristica producto
        /// </summary>
        /// <param name="d"></param>
        /// <returns>codigo de Registro</returns>
        public void Eliminar(int codigo)
        {
            try
            {
                using (this.dt = new DatoSistemasDataContext())
                {
                    this.dt.sp_pcar_delete(codigo);

                }


            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Datos.Excepciones.Gestionar(ex, "Producto_Caracteristica");
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