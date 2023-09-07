using System.Web.Mvc;

namespace DevProApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //====================================================
            //Commented out this added filter see
            //Important read on customererror on and Application_Error issue for MVC5
            //http://stackoverflow.com/questions/6508415/application-error-not-firing-when-customerrors-on
            //====================================================
            //filters.Add(new HandleErrorAttribute());
            //====================================================
        }
    }
}
