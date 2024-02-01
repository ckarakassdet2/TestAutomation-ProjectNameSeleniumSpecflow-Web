using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationQSightSeleniumSpecflowWeb
{
    class DriverUtility
    {
        public static string GetDriverExe(string browserDriverType)
        {
            string currDir = Environment.CurrentDirectory;
            browserDriverType = string.Empty;

            string pathToDriverFile = string.Empty;
            Console.WriteLine("*** currDir(driver): " + currDir);
            if (currDir.Contains("debug"))
            {
                pathToDriverFile = currDir.Replace("\\bin\\debug\\net6.0", "\\Drivers\\" + browserDriverType);
            }
            if (currDir.Contains("Debug"))
            {
                pathToDriverFile = currDir.Replace("\\bin\\Debug\\net6.0", "\\Drivers\\" + browserDriverType);
            }
            Console.WriteLine($"Path to Driver file: {pathToDriverFile} >> Running on Driver: {browserDriverType}");

            return pathToDriverFile; 
        }
    }
}
