using keepr_secret.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr_secret.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultRepository db;
        public VaultsController(VaultRepository repo)
        {
            db = repo;
        }
    }
}