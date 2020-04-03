using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
namespace Axle_Load_Control.Models
{
    public class Config
    {
        public readonly ODATASERVICE.NAV nav = new ODATASERVICE.NAV(new Uri(ConfigurationManager.AppSettings["baseUrl"]))

        {

            Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                       ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"])

        };


        public static AxleCodeunit.AxleLoadCodeunit ObjNav
        {
            get
            {
                var ws = new AxleCodeunit.AxleLoadCodeunit();

                try
                {
                    var credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                        ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                    ws.Credentials = credentials;
                    ws.PreAuthenticate = true;
                    ws.Timeout = -1;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return ws;
            }
        }

        //public static NavExtender.NavXtender Extend
        //{
        //    get
        //    {
        //        var ex = new NavExtender.NavXtender();

        //        try
        //        {
        //            var credential = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
        //                ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
        //            ex.Credentials = credential;
        //            ex.PreAuthenticate = true;
        //            ex.Timeout = -1;

        //        }
        //        catch (Exception e)
        //        {
        //            e.Data.Clear();

        //        }
        //        return ex;
        //    }
        //}


    }
}



