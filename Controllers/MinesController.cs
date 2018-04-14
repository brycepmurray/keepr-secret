using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr_secret.Models;
using keepr_secret.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_secret.Controllers
{
    [Route("api/[controller]")]
    public class MinesController : Controller
    {
        private readonly MineRepository db;
        public MinesController(MineRepository repo)
        {
            db = repo;
        }

        [HttpGet("{id}")]
        public IEnumerable<Keep> GetKeepsByVault(int id)
        {
            return db.GetAllKeepsByVault(id);
        }

        //CREATE MINE
        [HttpPost]
        public Mine Post([FromBody]Mine mine)
        {
            var user = HttpContext.User.Identity.Name;
            int Id;
            int.TryParse( user, out Id);
            mine.UserId = Id;
            return db.Add(mine);
        }

        //DELETE
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}