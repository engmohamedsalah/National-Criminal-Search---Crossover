using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NationalCriminal.WCF
{

    /// <summary>
    /// this is class return the response of the service, 
    /// check the parameters
    /// </summary>

    public class ResultResponse
    {
        //if 
        public bool hasError { get; set; }
        public string ErrorCode  { get; set; }
  
    }
}