using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminal.Helper
{
    /// <summary>
    /// this is error mapping class that return error message of the system
    /// it can later use localization for supporting multi language
    /// </summary>
    public class MappingError
    {
        //the following error is used for validation user input
        public const string Err01 = @"No Paramters entered, Please fill at least one paramters and search again";
        public const string Err02 = @"Age to must be greater than or equal age from, fix that and seach again";
        public const string Err03 = @"height to must be greater than or equal height from, fix that and seach again";
        public const string Err04 = @"weight to must be greater than or equal weight from, fix that and seach again";
        public const string Err99 = @"Unknown Error";


        public static string getErrorMessage(string ErrorCode)
        {
            switch (ErrorCode)
            {
                case ("01"):
                    return Err01;
                case ("02"):
                    return Err02;
                case ("03"):
                    return Err03;
                case ("04"):
                    return Err04;
                default:
                    return Err99;
            }
        }
    }
}
