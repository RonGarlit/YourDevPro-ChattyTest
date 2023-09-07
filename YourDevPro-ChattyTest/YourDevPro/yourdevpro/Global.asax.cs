using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BikeShop.Domain;
using Microsoft.AspNet.Identity;

namespace DevProApp
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // IMPORTANT ROUTING NOTE
            // MVC attribute routes registration
            // See: https://blogs.msdn.microsoft.com/webdev/2013/10/17/attribute-routing-in-asp-net-mvc-5/
            // Do BEFORE Registering all areas!!!
            RouteTable.Routes.MapMvcAttributeRoutes();

            // IMPORTANT ROUTING NOTE
            // Then you register all areas after above call to MapMvcAttributeRoutes()
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_BeginRequest()
        {

        }

        //====================================================
        // last resort error logging
        // note: customErrors in web config specifies error page
        //====================================================
        //Important read on customererror on and Application_Error issue for MVC5
        //http://stackoverflow.com/questions/6508415/application-error-not-firing-when-customerrors-on
        //====================================================
        protected void Application_Error(object sender, EventArgs e)
        {
            // get last exception
            var exception = HttpContext.Current.Server.GetLastError();

            if (exception != null)
                LogException(exception);
        }

        // logs an exception with relevant context data to the error table

        void LogException(Exception exception)
        {
            // try-catch because database itself could be down or Request context is unknown.

            try
            {
                //int? userId = null;
                //try { userId = CurrentUser.Id; }
                // Changed to match ASPNET.User ID
                string userId = null;
                try { userId = User.Identity.GetUserId(); }
                //userId = User.Identity.GetUserId().;
                catch { /* do nothing */ }

                // ** Prototype pattern. the Error object has it default values initialized

                var error = new Error(true)
                {
                    UserId = userId,
                    Exception = exception.GetType().FullName,
                    Message = exception.Message,
                    Everything = exception.ToString(),
                    IpAddress = HttpContext.Current.Request.UserHostAddress,
                    UserAgent = HttpContext.Current.Request.UserAgent,
                    PathAndQuery = HttpContext.Current.Request.Url == null ? "" : HttpContext.Current.Request.Url.PathAndQuery,
                    HttpReferer = HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.PathAndQuery
                };

                BikeShopContext.Errors.Insert(error);
            }
            catch { /* do nothing, or send email to webmaster*/}
        }
    }
}
