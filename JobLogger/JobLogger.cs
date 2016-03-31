using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JobLogger
{
    public class JobLogger
    {
        //Mantener formato de declaracion de atributos
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logToDatabase;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        
        //Eliminamos la variable "_initialized" porque nunca la usamos
        //private bool _initialized;
        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
        }
        //Conflicto con 2 variables de distinto tipo pero con el mismo nombre
        //Quitar static de la funcion "LogMessage"
        public void LogMessage(string sMessage, bool message, bool warning, bool error)
        {
            sMessage.Trim();
            if (sMessage == null || sMessage.Length == 0)
            {
                return;
            }
            if (!_logToConsole && !_logToFile && !_logToDatabase)
            {
                throw new Exception("Invalid configuration");
            }
            if ((!_logError && !_logMessage && !_logWarning) || (!message && !warning
            && !error))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
            
            int t = 0; string l = "";
            //if(!System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
            //Cambiar el formato de la fecha de "DateTime.Now.ToShortDateString()" a "DateTime.Now.ToString("dd-MM-yyyy")" (porque los nombre de archivos no pueden llevar el caracter de "/")
            //Cambiar la negacion en el if porque si no existe el archivo no se puede proseguir a leerlo "if(!...)" a "if(...)"
            if (System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"))
            {
                l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt");
            }

            //Agrupamos los If similares y le agregamos el ELSE para no recorrer todos lo caminos de los IF
            if (message && _logMessage)
            {
                t = 1;
                l = l + DateTime.Now.ToShortDateString() + " " + sMessage + "\r\n";
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (error && _logError)
            {
                t = 2;
                l = l + DateTime.Now.ToShortDateString() + " " + sMessage + "\r\n";
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (warning && _logWarning)
            {
                t = 3;
                l = l + DateTime.Now.ToShortDateString() + " " + sMessage + "\r\n";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            //Verificamos si tenemos acceso a registrar en la base de datos
            if(_logToDatabase)
            {
                //System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
                //Obtener la cadena de conexion de "ConnectionStrings" en vez de "AppSettings"
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                connection.Open();
                //Asignar la cadena de conexion al comando de sql
                System.Data.SqlClient.SqlCommand command = new
                System.Data.SqlClient.SqlCommand("Insert into Log Values('" + sMessage + "', " + t.ToString() + ")", connection);
                command.ExecuteNonQuery();
            }
            //Verificamos si tenemos acceso a registrar en un archivo de texto
            if (_logToFile)
            {
                System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", l);
            }
            //Verificamos si tenemos acceso a registrar en la Consola
            if (_logToConsole)
            {
                Console.WriteLine(DateTime.Now.ToShortDateString() + " " + sMessage);
            }
            //Reiniciamos el color de la consola
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool get_logToFile() => _logToFile;
        public bool get_logToConsole() => _logToConsole;
        public bool get_logToDatabase() => _logToDatabase;

    }
}
