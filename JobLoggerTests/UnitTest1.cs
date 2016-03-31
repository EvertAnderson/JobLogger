using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobLogger;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JobLoggerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod_Invalid_Configuration()
        {
            string cadena = "Hello World!";
            JobLogger.JobLogger obj = new JobLogger.JobLogger(false, false, false, true, true, true);
            obj.LogMessage(cadena, true, false, false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod_ErrorWarningMessage_MustBeSpecified()
        {
            string cadena = "Hello World!";
            JobLogger.JobLogger obj = new JobLogger.JobLogger(true, true, true, false, false, false);
            obj.LogMessage(cadena, true, false, false);
        }

        [TestMethod]
        public void VerifyThatMyDatabaseConnectionStringExists()
        {
            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        }

        [TestMethod]
        public void TestMethod_Log_ToConsole()
        {
            //Solo registro en la consola
            JobLogger.JobLogger obj = new JobLogger.JobLogger(false, true, false, true, true, true);
            Assert.AreEqual<bool>(true, obj.get_logToConsole());
        }

        [TestMethod]
        public void TestMethod_Log_ToDatabase()
        {
            //Solo registro en la base de datos
            JobLogger.JobLogger obj = new JobLogger.JobLogger(false, false, true, true, true, true);
            Assert.AreEqual<bool>(true, obj.get_logToDatabase());
        }

        [TestMethod]
        public void TestMethod_Log_ToFile()
        {
            //Solo registro en archivo
            JobLogger.JobLogger obj = new JobLogger.JobLogger(true, false, false, true, true, true);
            Assert.AreEqual<bool>(true, obj.get_logToFile());
        }

        [TestMethod]
        public void TestMethod_Log_Message()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string cadena = "Hello Message";
                //Solo Mensajes
                JobLogger.JobLogger obj = new JobLogger.JobLogger(true, true, true, true, false, false);
                obj.LogMessage(cadena, true, false, false);

                string expected = DateTime.Now.ToShortDateString() + " " + cadena + "\r\n";

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestMethod_Log_Warning()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string cadena = "Hello Warning";
                //Solo Advertencias
                JobLogger.JobLogger obj = new JobLogger.JobLogger(true, true, true, false, true, false);
                obj.LogMessage(cadena, false, true, false);

                string expected = DateTime.Now.ToShortDateString() + " " + cadena + "\r\n";

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestMethod_Log_Error()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                string cadena = "Hello Error";
                //Solo Errores
                JobLogger.JobLogger obj = new JobLogger.JobLogger(true, true, true, false, false, true);
                obj.LogMessage(cadena, false, false, true);

                string expected = DateTime.Now.ToShortDateString() + " " + cadena + "\r\n";

                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
