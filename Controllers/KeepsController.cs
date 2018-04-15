using Microsoft.AspNetCore.Mvc;

namespace keepr_secret.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepRepository db;
        public KeepsController(KeepsController Repository repo)
        {
            db = repo;
        }
    }
}