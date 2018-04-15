using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using keepr_secret.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr_secret.Models;
using System.Linq;


namespace keepr_secret.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepRepository db;
        public KeepsController(KeepsController repo)
        {
            db = repo;
        }
        //GET ALL KEEPS
        [HttpGet]
        public IEnumerable<KeepRepository> Get()
        {
            return db.GetAllKeeps();
        }

        //CREATE KEEP
         [Authorize]
        [HttpPost]
        public Keep Post([FromBody]Keep keep)
        {
            var user = HttpContext.User.Identity.Name;
            int Id;
            int.TryParse( user, out Id);
            keep.UserId = Id;
            return db.CreateKeep(keep);
        }

    }
}