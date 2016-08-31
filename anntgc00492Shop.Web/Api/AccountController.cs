using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using anntgc00492Shop.Web.App_Start;
using Microsoft.AspNet.Identity.Owin;

namespace anntgc00492Shop.Web.Api
{
        [RoutePrefix("api/account")]
        public class AccountController : ApiController
        {
            private IdentityConfig.ApplicationSignInManager _signInManager;
            private IdentityConfig.ApplicationUserManager _userManager;

            public AccountController()
            {
            }

            public AccountController(IdentityConfig.ApplicationUserManager userManager, IdentityConfig.ApplicationSignInManager signInManager)
            {
                UserManager = userManager;
                SignInManager = signInManager;
            }

            public IdentityConfig.ApplicationSignInManager SignInManager
            {
                get
                {
                    return _signInManager ?? HttpContext.Current.GetOwinContext().Get<IdentityConfig.ApplicationSignInManager>();
                }
                private set
                {
                    _signInManager = value;
                }
            }

            public IdentityConfig.ApplicationUserManager UserManager
            {
                get
                {
                    return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<IdentityConfig.ApplicationUserManager>();
                }
                private set
                {
                    _userManager = value;
                }
            }

            [HttpPost]
            [AllowAnonymous]
            [Route("login")]
            public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password, bool rememberMe)
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
                return request.CreateResponse(HttpStatusCode.OK, result);
            }


        }

}