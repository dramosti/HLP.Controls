using HLP.Controls.Repository.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Controls.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "dbFunctionsToComponents" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select dbFunctionsToComponents.svc or dbFunctionsToComponents.svc.cs at the Solution Explorer and start debugging.
    public class dbFunctionsToComponents : IdbFunctionsToComponents
    {
        public dbFunctionsToComponents()
        {

        }

        public DataTable GetData(string sSelect)
        {
            return HlpDbFuncoes.qrySeekRet(sExpressao: sSelect);
        }
    }
}
