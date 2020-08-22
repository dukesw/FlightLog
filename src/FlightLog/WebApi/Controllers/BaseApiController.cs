using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        public bool IsAccountIdOk(HttpContext context, int accountId)
        {
            var accountIdClaim = this.HttpContext.User.FindFirst("accountid");
            if (accountId.ToString() != accountIdClaim.Value)
            {
                return false;
            }
            return true;
        }
    }
}