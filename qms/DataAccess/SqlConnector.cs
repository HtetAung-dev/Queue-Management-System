using System;
using System.Collections;

namespace qms.DataAccess;

public class SqlConnector {

    private IConfiguration configuration;
    public String conStr = null;
    
    public String GetConnection()
    {
        conStr = this.configuration.GetConnectionString("defaultstr");
        if( conStr != null)
        {
            return conStr;
        }
        else
        {
            return null;
        }
    }
}