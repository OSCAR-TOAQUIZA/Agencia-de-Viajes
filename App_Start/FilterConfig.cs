using System.Web;
using System.Web.Mvc;

namespace Pry_Agencia_Viajes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
