﻿using System.Web;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Extensions;

namespace Glimpse.Core.Handlers
{
    [GlimpseHandler]
    public class Popup : IGlimpseHandler
    {
        public string ResourceName
        {
            get { return "Popup"; }
        }

        public void ProcessRequest(HttpContextBase context)
        {
            var response = context.Response;

            var path = context.GlimpseResourcePath("");
            var requestId = context.GetGlimpseRequestId();

            response.Write("<!DOCTYPE html><html><head><title>Glimpse - Popup</title>");
            response.Write("<style type='text/css'>html{color:#000;background:#FFF;} body{margin:0;padding:0;} .glimpse-holder { position:relative !important; display: block !important; } .glimpse-popout, .glimpse-close, .glimpse-terminate, .glimpse-open { display:none !important; } .glimpse-panel { overflow:visible !important; }</style>");
            response.Write("</head><body>");
            response.Write(string.Format(@"<script type='text/javascript' id='glimpseData' data-glimpse-requestID='{1}'>var glimpse, glimpsePath = '{0}'</script>", path, requestId));
            response.Write("<script type='text/javascript' id='glimpseClient' src='" + context.GlimpseResourcePath("client.js") + "'></script>");
            response.Write("</body></html>");
        }
    }
}