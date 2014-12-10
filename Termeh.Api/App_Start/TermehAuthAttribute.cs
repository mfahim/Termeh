using System.Web.Http;

namespace JobTrack.Api
{
    public class TermehAuthAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return true;
        }
    }
}