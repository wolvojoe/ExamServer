using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


 [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {



    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    


    [WebMethod]
    public Machine ValidateClient(string strMachineAuthCode)
    {
        var Machine = new Machine();

        Machine.MachineAuthCode = strMachineAuthCode;
        Machine.SelectMachineByCode();


        return Machine;

    }
}
