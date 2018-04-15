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
        public KeepsController(KeepRepository repo)
        {
            db = repo;
        }
        //GET ALL KEEPS
        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return db.GetAllKeeps();
        }

        //FIND KEEP BY USER
        [HttpGet]
        public IEnumerable<Keep> GetKeepsByUser(int userId)
        {
            return db.GetKeepsByUser(userId);
        }

        //CREATE KEEP
        [HttpPost]
        public Keep Post([FromBody]Keep keep)
        {
            var user = HttpContext.User.Identity.Name;
            int Id;
            int.TryParse( user, out Id);
            keep.UserId = Id;
            return db.CreateKeep(keep);
        }

        //UPDATE KEEP
        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return db.UpdateKeep(id, keep);
            }
            return null;
        }

        //DELETE KEEP
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.DeleteKeep(id);
        }
    }
}