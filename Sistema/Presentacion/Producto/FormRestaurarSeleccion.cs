using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Producto
{
    public partial class FormRestaurarSeleccion : Negocios.Base.FormBase
    {
        

        DateTime c1 = File.GetLastWriteTime(@"C:\SisElectro\DB\resp.bak");
        DateTime c2 = File.GetLastWriteTime(@"C:\SisElectro\DB\resp_1.bak");
        DateTime c3 = File.GetLastWriteTime(@"C:\SisElectro\DB\resp_2.bak");

        private String archivo = ""; 
        public FormRestaurarSeleccion()
        {
            InitializeComponent();
           

            rbtR1.Text = "Respaldo - "+c1 ;
            rbtR2.Text = "Respaldo Antiguo - " + c2;
            rbtR3.Text = "Respaldo Antiguo - " + c3;
        }

        private void rbtR1_CheckedChanged(object sender, EventArgs e)
        {
           
        archivo = @"C:\SisElectro\DB\resp.bak"; 
        }

        private void rbtR2_CheckedChanged(object sender, EventArgs e)
        {
            archivo = @"C:\SisElectro\DB\resp_1.bak"; 
        }

        private void rbtR3_CheckedChanged(object sender, EventArgs e)
        {
           archivo = @"C:\SisElectro\DB\resp_2.bak"; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!archivo.Equals(""))
            {
                DialogResult rs = MessageBox.Show("Desea realizar la restauracion:\n" +
                    "Restauracion es un regreso a un estado diferente de la informacion de la Base de Datos\n" +
                    "El estado es segun cque punto de restauracion ha elegido", "Atencion !", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.Yes)
                {

                    Cursor.Current = Cursors.WaitCursor;

                    // MessageBox.Show(@"backup database sistema to disk='C:\dbexportaX.ba' wITH INIT,STATs");
                    if (new Negocios.NBaseDatos().Restore(archivo))
                    {
                      MessageBox.Show("Se ha restaurado la base de datos", "Restauración",MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        Cursor.Current = Cursors.AppStarting;
                        this.Hide();
                        this.Close();
                    }
                    else
                        Cursor.Current = Cursors.AppStarting;

                   
                }
            }
            else
            {

                MessageBox.Show("No ha seleccionado un Respaldo" ,"Seleccion");
            }

        }
    }
}
