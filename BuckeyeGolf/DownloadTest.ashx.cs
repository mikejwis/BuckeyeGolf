using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf
{
    /// <summary>
    /// Summary description for DownloadTest
    /// </summary>
    public class DownloadTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.AddHeader("Content-Disposition","attachment;filename=idcard.gif");
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "image/gif";
            context.Response.WriteFile("/Content/Buckeye.gif");
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}