using System.Collections.Generic;
using System.Data;
using Dapper;

namespace keepr_secret.Repositories
{
    public class VaultRepository
    {
        private readonly IDbConnection _db;
        public VaultRepository(IDbConnection db)
        {
            _db = db;
        }

        //GET VAULT BY USER
        public IEnumerable<Vault> GetVaultsByUser(int userId)
        {
            return _db.Query<Vault>($@"
            SELECT * FROM vaults WHERE userId = {userId}
            ");
        }

        //GET VAULT BY ID
        public Vault GetVaultById(int id)
        {
            return _db.QueryFirstOrDefault<Vault>($@"
            SELECT * FROM vaults WHERE id = @id
            ", id);
        }

        //CREATE VAULT
        public Vault CreateVault(Vault vault)
        {
            int id = _db.ExecuteScalar<int>($@"
            INSERT INTO vaults (
              Name,
              ImageUrl,
              Description,
              UserId  
            )" + $@"
            VALUES(
              @Name, 
              @ImageUrl, 
              @Description, 
              @UserId
              ); 
              SELECT LAST_INSERT_ID()", new
            {
                vault.Name,
                vault.ImageUrl,
                vault.Description,
                vault.UserId
            });
            vault.Id = id;
            return vault;
        }
    }
}