using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQlite
{
    
    public interface ISQLite
    {
       string GetDatabasePath(string filename);
    }
}
