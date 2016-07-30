using System.Web;
using System.Web.Mvc;

public class AdminAuthorizeAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        var authorized = base.AuthorizeCore(httpContext);
        if (!authorized)
        {
            return false;
        }

        return System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true && HttpContext.Current.Session["FacebookID"].ToString() == "997874320260010";
    }
}