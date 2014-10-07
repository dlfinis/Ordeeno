using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormConfiguracion : Negocios.Base.FormBase
    {

        public enum Conf
        { 
        Seleccione=0,
        IVA=1,
        Descuento,
        Aumento,
        DiasActualizacion,
        InventarioMinimo
        
        }
        Conf cn;
        Negocios.NConfiguracion nconf = new Negocios.NConfiguracion();
        Negocios.Entidades.EConfiguracion econf = new Negocios.Entidades.EConfiguracion();
       
        public FormConfiguracion()
        {
            InitializeComponent();
            cmbClave.DataSource = Enum.GetValues(typeof(Conf));
        }

        private void FormConfiguracion_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void FormConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cn = (Conf)Enum.Parse(typeof(Conf), this.cmbClave.Items[cmbClave.SelectedIndex].ToString());
            //MessageBox.Show(cn + "--");

            if (cn.ToString().Equals("Seleccione"))
            {
                txtDescripcion.Text = "";

                txtValor.Text = "";
            }
            switch (cn.ToString())
            {

                case "IVA": 
                    txtDescripcion.Text = "Porcentaje Valor de los Impuestos"; 
                    txtValor.NumeroDecimal = true;
                    txtValor.Text = nconf.getDatos("IVA").conf_valor;
                    label4.Text = "%";
                    econf.Conf_clave = nconf.getDatos("IVA").conf_clave;
                    break;

                case "Descuento":  txtDescripcion.Text="Porcentaje Descuento Global en los Productos"; 
                    txtValor.NumeroDecimal = true;
                    txtValor.Text = nconf.getDatos("DESCUENTO").conf_valor;
                    label4.Text = "%";
                    econf.Conf_clave = nconf.getDatos("DESCUENTO").conf_clave;
                    break;
                case "Aumento":  txtDescripcion.Text="Porcentaje de aumento desde el Pecio de Compra"; 
                    txtValor.NumeroDecimal = true;
                     txtValor.Text = nconf.getDatos("AUMENTO").conf_valor;
                     econf.Conf_clave = nconf.getDatos("AUMENTO").conf_clave;
                     label4.Text = "%";
                     break;
                case "DiasActualizacion":  txtDescripcion.Text="#Dias desde el dia actual, hacia N dias de actualizacion ";
                    txtValor.NumeroDecimal = false;
                    txtValor.Text = nconf.getDatos("ACTUALIZACION").conf_valor;
                    econf.Conf_clave = nconf.getDatos("ACTUALIZACION").conf_clave;
                    //MessageBox.Show(econf.Conf_clave);
                    break;
                case "InventarioMinimo":  txtDescripcion.Text="Cantidad del stock de advertencia,del almacen"; 
                    txtValor.NumeroDecimal = false;
                    txtValor.Text = nconf.getDatos("MINPRODUCTO").conf_valor;
                    econf.Conf_clave = nconf.getDatos("MINPRODUCTO").conf_clave;
                    label4.Text = "#Objectos";
                    break;
       
        
            }

          //  txtDescripcion.Text = cn.GetType(.GetEnumValues(cmbClave.SelectedIndex).GetValue;


        }
      
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                
                econf.Conf_valor = txtValor.Text;
                nconf.Editar(econf);
                MessageBox.Show("Registro actualizado completo", "Edicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbClave.Focus();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Editar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClave.SelectedIndex = 0;
            }
        }
    }
}
