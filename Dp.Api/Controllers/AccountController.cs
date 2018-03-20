using System.Threading.Tasks;
using System.Web.Http;
using Dp.Models.Security;
using Microsoft.AspNet.Identity;

namespace Dp.Api.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly AuthRepository _repo;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _repo.Dispose();

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    foreach (string error in result.Errors)
                        ModelState.AddModelError("", error);

                if (ModelState.IsValid) return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _repo.RegisterUser(userModel);

            var errorResult = GetErrorResult(result);

            if (errorResult != null) return errorResult;

            return Ok();
        }
    }
}