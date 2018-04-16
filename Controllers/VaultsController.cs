using System.Collections.Generic;
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
        //GET VAULTS BY USER
        [HttpGet("{userId}")]
        public IEnumerable<Vault> GetVaultsByUser(int userId)
        {
            return db.GetVaultsByUser(userId);
        }

        //GET VAULT BY ID
        // [HttpGet("{id}")]
        // public IEnumerable<Vault> GetVaultById(int id)
        // {
        //     return db.GetVaultById(id);
        // }

        //CREATE VAULT
        [HttpPost]
        public Vault CreateVault([FromBody]Vault vault)
        {
            var user = HttpContext.User.Identity.Name;
            int Id;
            int.TryParse(user, out Id);
            vault.UserId = Id;
            return db.CreateVault(vault);
        }

        //UPDATE VAULT 
        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return db.UpdateVault(id, vault);
            }
            return null;
        }

        //DELETE VAULT
        [HttpDelete("{id}")]
            public string Delete(int id)
        {
            return db.DeleteVault(id);
        }
    }
}