using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Presentacion
{
    public partial class FormSplashScreen : DevComponents.DotNetBar.Office2007RibbonForm
    {
        const int DEFAULT_TIME = 1000;

        Thread t;
        public FormSplashScreen()
        {
            InitializeComponent();
            this.Shown += new EventHandler(FormSplashScreen_Shown);
            this.FormClosing += new FormClosingEventHandler(FormSplashScreen_FormClosing);
            this.btnCerrar.Click += new EventHandler(closeButton_Click);

        }
        void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        void FormSplashScreen_Shown(object sender, EventArgs e)
        {
            initvalues();
            t = new System.Threading.Thread(initApplication);
            t.Start();
        }

        private void initvalues()
        {
            titleLabel.Text = String.Format("{0} Sistema", " ORDEENO ");
            messageLabel.Text = "Inicializando...";
        }

        public void initApplication()
        {
            Thread.Sleep(DEFAULT_TIME);
            this.Invoke((MethodInvoker)(() => setMessage("Buscando Actualizaciones...")));
            Thread.Sleep(DEFAULT_TIME);
            this.Invoke((MethodInvoker)(() => setMessage("Conectando a la Base...")));
            Thread.Sleep(DEFAULT_TIME);
                       Thread.Sleep(DEFAULT_TIME);
            this.Invoke((MethodInvoker)(() => setMessage("Loading settings...")));
            Thread.Sleep(DEFAULT_TIME);
            this.Invoke((MethodInvoker)(() => setMessage("Cargando Preferencias...")));
            Thread.Sleep(DEFAULT_TIME);
            this.Invoke((MethodInvoker)(() => setMessage("Empezando Aplicacion...")));
            Thread.Sleep(DEFAULT_TIME);
            if (this.InvokeRequired) this.Invoke(new Action(finishProcess));
        }

        public void setMessage(string msg)
        {
            messageLabel.Text = msg;
        }



        void FormSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null && t.IsAlive)
            {
                t.Abort();
                t = null;
               
            }
            
        }

        private void finishProcess()
        {
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        private void FormSplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
