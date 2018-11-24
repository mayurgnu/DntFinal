using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DntAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        public UserController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
    }
}