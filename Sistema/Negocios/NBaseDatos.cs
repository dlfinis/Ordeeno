using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Negocios
{
    public class NBaseDatos
    {

        public string catalog = "sistema";
        public NBaseDatos()
        { }
        public Boolean Create()
        {

            ////string respaldo= String.Format(BD+@"\"+"restore.bak'");

            //System.Windows.Forms.MessageBox.Show("backup database sistema to disk='C:\\dbexportaX.ba wITH INIT,STATs");
            //string sBackup = String.Format("backup database sistema to disk='C:\\dbexportaX.bak' wITH INIT,STATs");

            //SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

            //csb.DataSource = "localhost";
            //csb.InitialCatalog = "sistema";
            //csb.IntegratedSecurity = true;


            //System.Windows.Forms.MessageBox.Show(csb + "");
            //using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            //{
            //    try
            //    {
            //        con.Open();

            //        SqlCommand cmdBackUp = new SqlCommand(sBackup, con);

            //        cmdBackUp.ExecuteNonQuery();

            //        System.Windows.Forms.MessageBox.Show("Se ha creado un BackUp de La base de datos satisfactoriamente",
            //            "Copia de seguridad de base de datos",
            //            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            //        con.Close();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message,
            //            "Error al copiar la base de datos",
            //            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //        return false;
            //    }
            //}


            bool desea_respaldar = true;

            if (Directory.Exists(@"C:\SisElectro\DB"))
            {
                if (File.Exists(@"C:\SisElectro\DB\resp.bak"))
                {
                    if (System.Windows.Forms.MessageBox.Show(@"Desea realizar el respaldo de la Base de Datos", "Respaldo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        if (File.Exists(@"C:\SisElectro\DB\resp_1.bak"))
                        {
                            if (File.Exists(@"C:\SisElectro\DB\resp_2.bak"))
                            {
                                File.Delete(@"C:\SisElectro\DB\resp_2.bak");

                            }
                            File.Move(@"C:\SisElectro\DB\resp_1.bak", @"C:\SisElectro\DB\resp_2.bak");
                            File.Move(@"C:\SisElectro\DB\resp.bak", @"C:\SisElectro\DB\resp_1.bak");
                        }
                        else
                        {
                            File.Move(@"C:\SisElectro\DB\resp.bak", @"C:\SisElectro\DB\resp_1.bak");
                        }


                    }
                    else
                        desea_respaldar = false;
                }
            }
            else
            {
                
                if (System.Windows.Forms.MessageBox.Show(@"Desea realizar el respaldo de la Base de Datos", "Respaldo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    desea_respaldar = false;
                }
                else
                    Directory.CreateDirectory(@"C:\SisElectro\DB");

            }


            //poner cursor de relojito mintras respalda


            string sBackup = @"backup database "+catalog+@" to disk ='C:\SisElectro\DB\resp.bak' with init,stats";
   

            if (desea_respaldar)
            {


                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

                csb.DataSource = "localhost";
                csb.InitialCatalog = catalog;
                csb.IntegratedSecurity = true;
                csb.ConnectTimeout = 10;
               
                using (SqlConnection conx = new SqlConnection(csb.ConnectionString))
                {
                    try
                    {
                        conx.Open();
                        SqlCommand cmdBackUp = new SqlCommand(sBackup, conx);
                        cmdBackUp.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Erro a la Creacion del Backup", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            
                        conx.Close();
                        return false;
                    }
                }

                return true;
            }
            return false;
            //return false;
            //    string sBackup = "BACKUP DATABASE " + p_database +
            //    " TO DISK = '" + p_backup_file + "'" +
            //    " WITH FORMAT, " + 
            //    " MEDIA NAME ='Nombredeseado', NAME = 'Copia de la BD ';" ;

            //backup database BDATOS to disk=’C:\dbexporta.bak’ with init
            //    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            //    csb.DataSource = p_server;
            //    csb.InitialCatalog = "sistema";
            //    csb.IntegratedSecurity = true;

        }

        public Boolean Restore(String archivo)
        {
            
            string sRestore=@"restore database sistema from disk ='"+archivo+"'";
            string sCommand = @"USE master ; " +
                            
                             @"ALTER DATABASE sistema SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                             sRestore +
                             @"ALTER DATABASE sistema SET MULTI_USER; ";
            try
                            
            {


                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

                csb.DataSource = "localhost";
                csb.InitialCatalog = "sistema";
                csb.IntegratedSecurity = true;
                csb.ConnectTimeout = 10;

                using (SqlConnection conx = new SqlConnection(csb.ConnectionString))
                {
                    try
                    {
                        conx.Open();
                        SqlCommand cmdBackUp = new SqlCommand(sCommand, conx);
                        cmdBackUp.ExecuteNonQuery();



                        conx.Close();
                        return true;
                    }
                                  //MessageBox.Show("No se puede Llenar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     
                    catch (Exception exp)
                    {
                        System.Windows.Forms.MessageBox.Show(exp.Message, "Erro al Restaurar", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            
                        conx.Close();
                        return false;
                    }

                   
                }
                
                        
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message, "Erro al Restaurar", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

           
        }

    }
}
