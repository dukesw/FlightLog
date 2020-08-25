using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        //public bool IsAccountIdOk(HttpContext context, int accountId)
        //{
        //    var accountIdClaim = this.HttpContext.User.FindFirst("accountid");
        //    if (accountId.ToString() != accountIdClaim.Value)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        internal string GetAccountIdClaim()
        {
            var accountIdClaim = this.HttpContext.User.FindFirst("accountid");
            return accountIdClaim.Value;
        }

    }
}