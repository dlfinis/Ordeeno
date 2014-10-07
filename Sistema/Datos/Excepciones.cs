using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Datos
{
    /// <summary>
    /// Permite gestionar las excepciones tanto a nivel de base de datos como del cliente
    /// </summary>
    public static partial class Excepciones 
    {
        #region Datos
        /// <summary>
        /// Permite retornar el mensaje de error personalizado
        /// este emnsaje puede ser utilizados en los formularios
        /// por ejemplo en un MessageBox o ser mostrado en otro componente.
        /// </summary>
        private static string _mensajePersonalizado;
        
        

        #endregion

        #region Propiedades
        public static string MensajePersonalizado {
           
            set {
                _mensajePersonalizado = value;
               
            }
            get {
                return _mensajePersonalizado;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Gestiona o administra las excepciones  producidas en el servidor de BD
        /// </summary>
        public static void Gestionar(SqlException exception) {


           // HandlingException(exception);


            LogExceptions(exception);
            string mensaje = null;
            string saltoLinea = "\n";//<br>
            //Como los mensajes pueden cambiar,es mejor crear los principales
            //textos en variables.
            string problema="EL PROLEMA GENERADO PUEDE DEBERSE A LOS SIGUIENTES FACTORES";
            string solucion = "POR FAVOR, PRUEBE LA SIGUIENTE SOLUCION: ";
            string mensajeFinal = "NOTA: En caso de persistir el problema, llame a Soporte Tecnico"+
                             saltoLinea +
                             "o consulte con el Administrador del Sistema";
            //verificar el numero de error generado por la BSD
            //y personaizar el mensajerror 

           
            
            switch (exception.Number)
            {
                case 18456:
                    mensaje = problema +
                        saltoLinea +
                        "1.- eL NOMBRE DE USUARIO O LA CONTRASEÑA SON INCORRECTOS" +
                        "2.- Los campos usuarios y contraseña son requeridos"+ 
                        saltoLinea +
                         solucion +
                         saltoLinea +
                        "1.- Verifique que el nombre de usuario y/o contraseña sean correctos " +
                         saltoLinea + saltoLinea +
                        mensajeFinal;
                    break;
                case 2627:
                    mensaje = problema +
                  saltoLinea +
                  "1.- El nombre de cadena esta duplicado" +
                  "2.- Los campos usuarios y contraseña son rerqueridos" +
                  saltoLinea +
                   solucion +
                   saltoLinea +
                  "1.- Verifique que el contenido no este duplicado " +
                   saltoLinea + saltoLinea +
                  mensajeFinal;
                    break;


                default:
                    //Errores desconocidos-no personalizados
                    mensaje = "ERROR DESCONOCIDO" +
                       saltoLinea + saltoLinea +
                        "Mensaje: " + exception.Message +
                        saltoLinea +
                        "\nNUMERO: " + exception.Number;
                    break;
            }
            //Retornar el mensaje de error personalizado, en el campo 
            //privado: _mensajePersonalizado de la clase
            //Para que quien utilice la clase decida de que forma 
            //o en que control mustra el mensaje. Puede ser:
            //1.-MessageBox
            //2.-ErrorProvider
            // 3.-Label
            // 4.-Formulario,etc
            _mensajePersonalizado = mensaje;
           
        }


        /// <summary>
        /// Gestiona o administra las excepciones  producidas en el servidor de BD
        /// </summary>
        public static void Gestionar(SqlException exception,string origen)
        {
            LogExceptions(exception);
            string mensaje = null;
            string saltoLinea = "\n";//<br>
            //Como los mensajes pueden cambiar,es mejor crear los principales
            //textos en variables.
            string problema = "EL PROLEMA GENERADO PUEDE DEBERSE A LOS SIGUIENTES FACTORES";
            string solucion = "POR FAVOR, PRUEBE LA SIGUIENTE SOLUCION: ";
            string mensajeFinal = "NOTA: En caso de persistir el problema, llame a Soporte Tecnico" +
                             saltoLinea +
                             "o consulte con el Administrador del Sistema";
            //verificar el numero de error generado por la BSD
            //y personaizar el mensajerror 



            switch (exception.Number)
            {
                case 18456:
                    mensaje = problema +
                        saltoLinea + 
                        "1.- Un campo o campos  en "+origen+" SON INCORRECTOS" +
                        saltoLinea +
                        "2.- Algunos campos en :"+origen+ "son rerqueridos" +
                        saltoLinea +
                         solucion +
                         saltoLinea +
                        "1.- Verifique los datos sean correctos " +
                         saltoLinea + saltoLinea +
                        mensajeFinal;
                    break;

                case 2627:
                    mensaje = problema +
                  saltoLinea +
                  "\n1.- Un campo o campos en "+origen+" esta duplicado" +
                   saltoLinea +
                   solucion +
                   saltoLinea +
                  "1.- Verifique que el contenido este correcto y no exista previamente " +
                   saltoLinea + saltoLinea +
                  mensajeFinal;
                    break;

                case 547:

                    mensaje = problema +
                   saltoLinea +
                   "\n Informacion del item de  " + origen + " esta siendo utilizado en la base de datos " +
                    saltoLinea +
                    solucion +
                    saltoLinea +
                   "-Elimine los registros donde se este utilizando la informacion" +
                    saltoLinea + saltoLinea +
                   mensajeFinal;
                    break;



                default:
                    //Errores desconocidos-no personalizados
                    mensaje = "ERROR DESCONOCIDO" +
                       saltoLinea + saltoLinea +
                        "Mensaje: " + exception.Message +
                        saltoLinea +
                        "\nNUMERO: " + exception.Number;
                        //saltoLinea +
                        //"\nFuente: " + exception.Source +
                        //saltoLinea +
                        //"\nLinea:" + exception.StackTrace;
                    break;
            }
            //Retornar el mensaje de error personalizado, en el campo 
            //privado: _mensajePersonalizado de la clase
            //Para que quien utilice la clase decida de que forma 
            //o en que control mustra el mensaje. Puede ser:
            //1.-MessageBox
            //2.-ErrorProvider
            // 3.-Label
            // 4.-Formulario,etc
            _mensajePersonalizado = mensaje;

        }

        /// <summary>
        /// Gestiona o administra las excepciones  producidas en el cliente
        /// </summary>
        public static void Gestionar(Exception exception) {
            
            
            LogExceptions(exception);
            string mensaje = null;
            string saltoLinea = "\n";//<br>
            //Como los mensajes pueden cambiar,es mejor crear los principales
            //textos en variables.
            string problema = "EL PROLEMA GENERADO PUEDE DEBERSE A LOS SIGUIENTES FACTORES";
            string solucion = "POR FAVOR, PRUEBE LA SIGUIENTE SOLUCION: ";
            string mensajeFinal = "NOTA: En caso de persistir el problema, llame a Soporte Tecnico" +
                             saltoLinea +
                             "o consulte con el Administrador del Sistema";
            //verificar el numero de error generado por la BSD
            //y personaizar el mensajerror 
            string tipoException=exception.GetType().ToString();
            switch (tipoException)
            {
                case "System.ArgumentException":
                    mensaje = problema +
                        saltoLinea +
                        "1.- El argumento no es valido" +
                         saltoLinea +
                         saltoLinea+
                         solucion +
                         saltoLinea +
                        "1.- Verifique que el argumento  sea correcto. " +
                         saltoLinea + saltoLinea +
                        mensajeFinal;
                    break;
              
                case "System.Data.SqlClient.SqlException":
                   
                    Gestionar((SqlException)exception.InnerException);
                    break;

                default:
                   // Errores desconocidos-no personalizados
                    mensaje = "ERROR DESCONOCIDO" +
                       saltoLinea + saltoLinea +
                        "Mensaje: " + exception.Message +
                        saltoLinea +
                        "\nTipo: " + exception.GetType();
                    break;
            }
            //Retornar el mensaje de error personalizado, en el campo 
            //privado: _mensajePersonalizado de la clase
            //Para que quien utilice la clase decida de que forma 
            //o en que control mustra el mensaje. Puede ser:
            //1.-MessageBox
            //2.-ErrorProvider
            // 3.-Label
            // 4.-Formulario,etc
            _mensajePersonalizado = mensaje;
        }
        public static void Mostrar(string tipo,string titulo)
        {
           
            switch (tipo)
            {
            
                case "Information": System.Windows.Forms.MessageBox.Show(Excepciones.MensajePersonalizado,titulo,System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
                    
                    return;

                case "Warning": System.Windows.Forms.MessageBox.Show(Excepciones.MensajePersonalizado, titulo, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
        
            }

           
            
           
          
        }
        #endregion

      

   
      

    }
}
