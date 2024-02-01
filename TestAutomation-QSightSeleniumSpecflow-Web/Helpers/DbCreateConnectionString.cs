
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace TestAutomationQSightSeleniumSpecflowWeb

{

    public class DbCreateConnectionString 
    {

        public DbCreateConnectionString() { }   

        private string _baseUrl = string.Empty; 
        public void DbCreateConnectionString_Setup()
        {           
            string _dbPasswordClearText = string.Empty;
            string _dbPasswordHashed = string.Empty;
            string DBConnString = string.Empty;
            string _tempString = string.Empty;
            string _environment = string.Empty;
            // string _baseUrl = Manager.Settings.Web.BaseUrl;
            
            // Log.WriteLine("Manager.Settings.Web.BaseUrl: " + _baseUrl);
            
           if(_baseUrl.ToUpper().Contains("QDEV"))
            {
                _environment = "dev";
            }
            else
            {
                if(_baseUrl.ToUpper().Contains("TEST"))
                {
                    _environment = "test";
                }
                else
                {
                    if(_baseUrl.ToUpper().Contains("QSTAGE"))
                    {
                        _environment = "stage";
                    }
                    else
                    {
                        if(_baseUrl.ToUpper().Contains("LOGIN"))
                        {
                            _environment = "prod";
                        }
                    }
                }
            }
            Console.WriteLine("*** *** *** _environment: " + _environment + " *** *** ***");
            
            switch(_environment)
            {
                case "dev":
                    //_dbPasswordHashed = Data["DB-Dev-Password"].ToString();
                    Console.WriteLine("DB-Dev-Password: " + _dbPasswordHashed);
                    //_dbPasswordClearText = SymmetricDecryptor.DecryptToString(_dbPasswordHashed);
                    Console.WriteLine("_dbPasswordClearText: " + _dbPasswordClearText);
                    //_tempString = "data source=" + Data["DB-Dev-Server"].ToString() + ";initial catalog=" + Data["DB-Dev-Catalog"].ToString() + ";persist security info=True;user id=" + Data["DB-Dev-Username"].ToString() + ";password=" + _dbPasswordClearText + ";";
                    Console.WriteLine("Database conn string: " + _tempString);

                    // SetExtractedValue("DBConnString", _tempString);
                    break;
                case "test":
                    //_dbPasswordHashed = Data["DB-Test-Password"].ToString();
                    //_dbPasswordClearText = SymmetricDecryptor.DecryptToString(_dbPasswordHashed);
                    //_tempString = "data source=" + Data["DB-Test-Server"].ToString() + ";initial catalog=" + Data["DB-Test-Catalog"].ToString() + ";persist security info=True;user id=" + Data["DB-Test-Username"].ToString() + ";password=" + _dbPasswordClearText + ";";
                    Console.WriteLine("Database conn string: " + _tempString);
                    // SetExtractedValue("DBConnString", _tempString);
                    break;
                case "stage":
                    //_dbPasswordHashed = Data["DB-Stage-Password"].ToString();
                    Console.WriteLine("DB-Stage-Password: " + _dbPasswordHashed);
                    _dbPasswordClearText = SymmetricDecryptor.DecryptToString(_dbPasswordHashed);
                    Console.WriteLine("_dbPasswordClearText: " + _dbPasswordClearText);
                    //_tempString = "data source=" + Data["DB-Stage-Server"].ToString() + ";initial catalog=" + Data["DB-Stage-Catalog"].ToString() + ";persist security info=True;user id=" + Data["DB-Stage-Username"].ToString() + ";password=" + _dbPasswordClearText + ";";
                    Console.WriteLine("Database conn string: " + _tempString);
                    // SetExtractedValue("DBConnString", _tempString);
                    break;
                case "prod":
                    //_dbPasswordHashed = Data["DB-Prod-Password"].ToString();
                    Console.WriteLine("DB-Prod-Password: " + _dbPasswordHashed);
                    _dbPasswordClearText = SymmetricDecryptor.DecryptToString(_dbPasswordHashed);
                    Console.WriteLine("_dbPasswordClearText: " + _dbPasswordClearText);
                    //_tempString = "data source=" + Data["DB-Prod-Server"].ToString() + ";initial catalog=" + Data["DB-Prod-Catalog"].ToString() + ";persist security info=True;user id=" + Data["DB-Prod-Username"].ToString() + ";password=" + _dbPasswordClearText + ";";
                    Console.WriteLine("Database conn string: " + _tempString);

                    // SetExtractedValue("DBConnString", _tempString);
                    break;
            }            
        }
    }
}
