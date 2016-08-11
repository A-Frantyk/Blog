using Blog_Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace Blog_API.App_Start
{
    //public class CustomAuthentificationFilterAttribute : Attribute, IAuthenticationFilter
    //{
    //    private IUnitOfWork _unit;

    //    public CustomAuthentificationFilterAttribute(IUnitOfWork unit)
    //    {
    //        _unit = unit;
    //    }

    //    public bool AllowMultiple
    //    {
    //        get
    //        {
    //            return false;
    //        }
    //    }

    //    public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    //    {
    //        context.Principal = null;

    //        AuthenticationHeaderValue authentication = context.Request.Headers.Authorization;

    //        if(authentication != null && authentication.Scheme == "Basic")
    //        {
    //            string[] authData = Encoding.ASCII.GetString(Convert.FromBase64String(authentication.Parameter)).Split(':');
    //            var itemRoles = _unit.RolesItemRepository.Get().Result;
    //            IEnumerable<string> roles = itemRoles.ToList().Select(a => a.RoleName);

    //            string login = authData[0];
    //            context.Principal = new GenericPrincipal(new GenericIdentity(login), roles.ToArray());
    //        }

    //        if(context.Principal == null)
    //        {
    //            context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[] { new AuthenticationHeaderValue("Basic") }, context.Request);
    //        }

    //        return Task.FromResult<object>(null);
    //    }

    //    public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    //    {
    //        return Task.FromResult<object>(null);
    //    }
    //}
}