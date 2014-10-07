using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormMDI : DevComponents.DotNetBar.Office2007RibbonForm
    {

        private static FormMDI principal;

        public static FormMDI Principal
        {
            get { return FormMDI.principal; }
            set { FormMDI.principal = value; }
        }


        private static FormDataProveedores dprov_seleccion;

        public static FormDataProveedores Dprov_seleccion
        {
            get { return FormMDI.dprov_seleccion; }
            set { FormMDI.dprov_seleccion = value; }
        }

        public FormMDI()
        {
            InitializeComponent();
            Dprov_seleccion = frm_dproveedor;
            Principal = this;
           
         
            FormMDI.Usuario="USUARIO";
           
        }

        

      

        private void ExitToolsButtonItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
        private void CascadeToolButtonItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolButtonItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolButtonItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolButtonItem_Click(object sender, EventArgs e)
        {
            //LayoutMdi(MdiLayout.ArrangeIcons);
            foreach (Form childForm in MdiChildren)
            {
                        childForm.WindowState = childForm.WindowState == FormWindowState.Minimized ? FormWindowState.Normal: FormWindowState.Minimized;
            }
        }

        private void CloseAllToolButtonItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        FormDataCiudades frm_dciudad = new FormDataCiudades();



        private void FormMDI_FormClosing(object sender, FormClosingEventArgs e)
        {

             DialogResult rs= MessageBox.Show("Desea Salir ? " + Usuario,"ORDEENO",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

             if (rs == DialogResult.Yes)
             {
                 this.Hide();
                 Thread.SpinWait(10);

                 foreach (Form childForm in MdiChildren)
                 {
                     childForm.Close();
                 }

                 Application.ExitThread();
                 Application.Exit();
             }
             else
             {
                 e.Cancel = true;
             }

        }
        FormDataMarcas frm_dmarca = new FormDataMarcas();



        



       
        private void btnCiudad_Click_1(object sender, EventArgs e)
        {

            //Base.FormDataBusq bs = new Base.FormDataBusq();
            //bs.Show();
            if (!frm_dciudad.Visible)
            {
                try
                {
                    this.frm_dciudad.MdiParent = this;
                
                    frm_dciudad.btnEditar.Enabled = FormMDI.Usuario.Equals("ADMIN");
                    this.frm_dciudad.Show();
                    


                }
                catch (System.ObjectDisposedException)
                {
                    frm_dciudad = new FormDataCiudades();
                    this.frm_dciudad.MdiParent = this;
                  
                    this.frm_dciudad.Show();
                  
                }
            }
            else
            {
                frm_dciudad.Focus();
            }

        }

        private void btnMarca_Click_1(object sender, EventArgs e)
        {
            if (!frm_dmarca.Visible)
            {
                try
                {
                    this.frm_dmarca.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dmarca.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dmarca = new FormDataMarcas();
                    this.frm_dmarca.MdiParent = this;

                    this.frm_dmarca.Show();
                }
            }
            else
                frm_dmarca.Focus();
        }

      
        private void btnOcultar_Click(object sender, EventArgs e)
        {
            
            rbControl.Expanded = false;
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            
            rbControl.Expanded = true;
        }

        FormDataPersonas frm_dpersona = new FormDataPersonas();
        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (!frm_dpersona.Visible)
            {
                try
                {
                    this.frm_dpersona.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dpersona.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dpersona = new FormDataPersonas();
                    this.frm_dpersona.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dpersona.Show();
                }
            }
            else
                frm_dpersona.Focus();
        }

        private void btnSalirSistema_Click(object sender, EventArgs e)
        {
            
            foreach (Form frm in this.MdiChildren)
            {

                frm.Close();
            }
           
              
                System.Threading.Thread.SpinWait(10);
                Application.ExitThread();
                Application.Exit();
        
        }

        FormDataProveedores frm_dproveedor = new FormDataProveedores();
     
        private void btnProveedor_Click(object sender, EventArgs e)
        {
            if (!frm_dproveedor.Visible)
            {
                try
                {
                    this.frm_dproveedor.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dproveedor.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dproveedor = new FormDataProveedores();
                    this.frm_dproveedor.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dproveedor.Show();
                }
            }
            else
                frm_dproveedor.Focus();
        }

        #region Background

        private void LoadForm(Form frm)
        {

           
            frm.Show();

            frm.Opacity = 90;
        }

#endregion
        Producto.FormDataProductos frm_dproductos = new Producto.FormDataProductos();
           
        private void btnProducto_Click(object sender, EventArgs e)
        {
            if (FormMDI.IsUsuarioAdmin())
            {

                if (!frm_dproductos.Visible)
                {

                    try
                    {
                        frm_dproductos.MdiParent = this;
                        //Thread.SpinWait(1);
                        frm_dproductos.Show();
                        // Task t = Task.Factory.StartNew(() => LoadForm(frm_dproductos));



                    }
                    catch (System.ObjectDisposedException)
                    {
                        frm_dproductos = new Producto.FormDataProductos();
                        frm_dproductos.MdiParent = this;
                        frm_dproductos.Show();
                    }
                }
                else
                    frm_dproductos.Focus();
                
            }           
         
        }
        Producto.FormDataTamanios frm_ddimension = new Producto.FormDataTamanios();
        private void btnDimension_Click(object sender, EventArgs e)
        {
            if (!frm_ddimension.Visible)
            {
                try
                {
                    this.frm_ddimension.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_ddimension.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_ddimension = new Producto.FormDataTamanios();
                    this.frm_ddimension.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_ddimension.Show();
                }
            }
            else
                frm_ddimension.Focus();
        }
        Producto.FormDataColores frm_dcolor = new Producto.FormDataColores();
        private void Color_Click(object sender, EventArgs e)
        {
            if (!frm_dcolor.Visible)
            {
                try
                {
                    this.frm_dcolor.MdiParent = this;
                    System.Threading.Thread.Sleep(100);
                    System.Threading.Thread.Sleep(250);
                    this.frm_dcolor.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dcolor = new Producto.FormDataColores();
                    this.frm_dcolor.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dcolor.Show();
                }
            }
            else
                frm_dcolor.Focus();
        }

        private void rbControl_Click(object sender, EventArgs e)
        {

        }
        Producto.FormDataUnidades frm_dunidad = new Producto.FormDataUnidades();
       
        private void btnUnidad_Click(object sender, EventArgs e)
        {
            if (!frm_dunidad.Visible)
            {
                try
                {
                    this.frm_dunidad.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dunidad.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dunidad = new Producto.FormDataUnidades();
                    this.frm_dunidad.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dunidad.Show();
                }
            }
            else
                frm_dunidad.Focus();

        }
        Venta.FormConsulta frm_dconsulta = new Venta.FormConsulta();
     
        private void vbtnConsulta_Click(object sender, EventArgs e)
        {


            if (!frm_dconsulta.Visible)
            {
                try
                {
                    this.frm_dconsulta.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dconsulta.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dconsulta = new Venta.FormConsulta();
                    this.frm_dconsulta.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dconsulta.Show();
                }
            }
            else
                frm_dconsulta.Focus();
        }

    


        private void btnRespaldo_Click(object sender, EventArgs e)
        {
            if (FormMDI.IsUsuarioAdmin())
            {
                Cursor.Current = Cursors.WaitCursor;

                // MessageBox.Show(@"backup database sistema to disk='C:\dbexportaX.ba' wITH INIT,STATs");
                if (new Negocios.NBaseDatos().Create())
                {
                    MessageBox.Show("El Respaldo de la base de datos fue realizado satisfactoriamente", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.AppStarting;

                }
                else
                    Cursor.Current = Cursors.AppStarting;
            }   
         }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (FormMDI.IsUsuarioAdmin())
            {
                //Cursor.Current = Cursors.WaitCursor;
                Producto.FormRestaurarSeleccion frm = new Producto.FormRestaurarSeleccion();

                frm.ShowDialog();
               
            }

        }

        FormConfiguracion frm_configuracion = new FormConfiguracion();
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            //Base.FormDataBusq bs = new Base.FormDataBusq();
            //bs.Show();
            if (FormMDI.IsUsuarioAdmin())
            {
                if (!frm_configuracion.Visible)
                {
                    try
                    {
                        this.frm_configuracion.MdiParent = this;
                        System.Threading.Thread.Sleep(250);
                        this.frm_configuracion.Show();

                    }
                    catch (System.ObjectDisposedException)
                    {
                        frm_configuracion = new FormConfiguracion();
                        this.frm_configuracion.MdiParent = this;
                        System.Threading.Thread.Sleep(250);
                        this.frm_configuracion.Show();
                    }
                }
                else
                {
                    frm_configuracion.Focus();
                }
            }
            
        }
        Producto.FormDataProductosSeleccion frm_dprod = new Producto.FormDataProductosSeleccion();
        Venta.FormDataVentas frm_dven = new Venta.FormDataVentas();  
        
        private void btnVenta_Click(object sender, EventArgs e)
        {


            if (!frm_dven.Visible)
            {

                try
                {

                    this.frm_dven.MdiParent = this;
                    System.Threading.Thread.Sleep(250);

                    this.frm_dven.Show();


                    this.frm_dven.Opacity = 90;


                }
                catch (System.ObjectDisposedException)
                {
                    frm_dven = new Venta.FormDataVentas();
                    this.frm_dven.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dven.Show();
                }
            }
            else
                frm_dven.Focus();
        }

        private void rbnMain_Load(object sender, EventArgs e)
        {
            //FormSplashScreen frm = new FormSplashScreen();
           // frm.ShowDialog();

            //rbControl.Expanded = false;
            
            this.Activate();
           
        }
        Producto.FormDataCaracteristicas frm_dcar = new Producto.FormDataCaracteristicas();  
        
        private void rbtCaracteristicas_Click(object sender, EventArgs e)
        {

            if (!frm_dcar.Visible)
            {

                try
                {

                    this.frm_dcar.MdiParent = this;
                    System.Threading.Thread.Sleep(250);

                    this.frm_dcar.Show();


                    this.frm_dcar.Opacity = 90;


                }
                catch (System.ObjectDisposedException)
                {
                    frm_dcar = new Producto.FormDataCaracteristicas();
                    this.frm_dcar.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dcar.Show();
                }
            }
            else
                frm_dcar.Focus();
        }

        private void rbtPedido_Click(object sender, EventArgs e)
        {
            if (!frm_dven.Visible)
            {

                try
                {

                    this.frm_dven.MdiParent = this;
                    this.frm_dven.TitleText = "Pedidos";
                    System.Threading.Thread.Sleep(250);

                    this.frm_dven.Show();

                    frm_dcar.Activate();
                    this.frm_dven.Opacity = 90;


                }
                catch (System.ObjectDisposedException)
                {
                    frm_dven = new Venta.FormDataVentas();
                    this.frm_dven.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dven.Show();
                }
            }
            else
                frm_dven.Focus();
        }

        Pedido.FormDataPedidos frm_dped = new Pedido.FormDataPedidos();
        private void rbtPedido_Click_1(object sender, EventArgs e)
        {


            if (!frm_dped.Visible)
            {

                try
                {

                    this.frm_dped.MdiParent = this;
                    System.Threading.Thread.Sleep(250);

                    this.frm_dped.Show();


                    this.frm_dped.Opacity = 90;


                }
                catch (System.ObjectDisposedException)
                {
                    frm_dped = new Pedido.FormDataPedidos();
                    this.frm_dped.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dped.Show();
                }
            }
            else
                frm_dped.Focus();
        }
       
    
        private void btnUsuario_Click(object sender, EventArgs e)
        {

            if (this.MdiChildren.Where(p => p.IsAccessible.Equals(true) ).Count() > 0)
            {
                DialogResult res = MessageBox.Show("Desea Continuar ?: \nSe Cerraran todos los formularios ", "Inicio de Sesion de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                if (res == DialogResult.Yes)
                {
                    foreach (Form childForm in MdiChildren)
                    {
                        childForm.Close();
                    }

                    FormUsuario frm_usr = new FormUsuario();

                    frm_usr.editar = true;
                    System.Threading.Thread.Sleep(250);
                    frm_usr.ShowDialog();
                    //MessageBox.Show(ConfigurationManager.AppSettings["SISTEMA"]);


                }
            }
            else
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                FormUsuario frm_usr = new FormUsuario();

                frm_usr.editar = true;
                System.Threading.Thread.Sleep(250);
                frm_usr.ShowDialog();
            }


        }


       
        FormDataCategorias frm_dcategoria = new FormDataCategorias();
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            if (!frm_dcategoria.Visible)
            {
                try
                {
                    this.frm_dcategoria.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dcategoria.Show();

                }
                catch (System.ObjectDisposedException)
                {
                    frm_dcategoria = new FormDataCategorias();
                    this.frm_dcategoria.MdiParent = this;
                    System.Threading.Thread.Sleep(250);
                    this.frm_dcategoria.Show();
                }
            }
            else
                frm_dcategoria.Focus();

        }

        Reportes.FormReporte frm_reporte = new Reportes.FormReporte();
        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (FormMDI.IsUsuarioAdmin())
            {

                if (!frm_reporte.Visible)
                {
                    try
                    {
                        this.frm_reporte.MdiParent = this;
                        System.Threading.Thread.Sleep(250);
                        frm_reporte.Show();
                    }
                    catch (System.ObjectDisposedException)
                    {
                        frm_reporte = new Reportes.FormReporte();
                        this.frm_reporte.MdiParent = this;
                        System.Threading.Thread.Sleep(250);
                        frm_reporte.Show();
                    }
                }
                else
                    frm_reporte.Focus();
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            
                FormCorreoUsuario frm_correo = new FormCorreoUsuario();
                frm_correo.ShowDialog();
               

        }

        #region usuario
        private static string usuario;

        public static string Usuario
        {
            get { return FormMDI.usuario; }
            set { FormMDI.usuario = value; }
        }



        public static void usuarioValido(Control control)
        {
            control.Enabled = FormMDI.usuario.Equals("ADMIN");
        }

        public static void usuarioValido(DevComponents.DotNetBar.ButtonItem control)
        {
            control.Enabled = FormMDI.usuario.Equals("ADMIN");
        }

        public static void usuarioValido(DataGridView lista, string column, bool visible)
        {
            if (!FormMDI.usuario.Equals("ADMIN"))
            {
                lista.Columns[column].Resizable = DataGridViewTriState.False;
                lista.Columns[column].Visible = visible;
                lista.Columns[column].ReadOnly = true;
            }
            else
            {
                lista.Columns[column].Resizable = DataGridViewTriState.True;
                lista.Columns[column].Visible = true;
                lista.Columns[column].ReadOnly = false;

            }

        }

        public static void usuarioValido(DataGridView lista, string column, int width)
        {
            if (FormMDI.usuario.Equals("ADMIN"))
            {
                lista.Columns[column].Resizable = DataGridViewTriState.True;
                lista.Columns[column].FillWeight = width;
            }
            else
            {
                lista.Columns[column].Resizable = DataGridViewTriState.False;
                lista.Columns[column].FillWeight = 10;

            }

        }

        public static bool IsUsuarioAdmin()
        {

            if (FormMDI.Usuario.Equals("ADMIN"))
            {
                return true;

            }
            else
            {

                MessageBox.Show("Esta accion solo esta disponible para el administrador", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        #endregion usuario
    }
}
