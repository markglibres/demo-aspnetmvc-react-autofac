using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ReactASPNetMVCDemo
{
    public class DemoConnectionProvider : IConnectionProvider
    {
        public string ConnectionString { get; set; }


        public DemoConnectionProvider(string key= "demoDb")
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        
    }
}
