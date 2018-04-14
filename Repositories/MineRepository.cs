using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using keepr_secret.Models;
using System.Data;
using System.Linq;
using Dapper;

namespace keepr_secret.Repositories
{
    public class MineRepository
    {
        private readonly IDbConnection _db;

        public MineRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Keep> GetAllKeepsByVault(int id)
        {
            return _db.Query<Keep>($@"
            SELECT * FROM mines mine
            INNER JOIN keeps k ON k.id = mine.keepId
            WHERE (vaultId = {id})", id);
        }

        public Mine Create(Mine mine)
        {
            int id = _db.ExecuteScalar<int>($@"
            INSERT INTO mines (
                VaultId,
                 KeepId,
                  UserId
                  ) VALUES(@VaultId, @KeepId, @UserId)", mine);
            mine.Id = id;
            return mine;
        }

        public string FindByIdAndRemove(int keepId)
        {
            var success = _db.Execute($@"
                DELETE FROM mines WHERE KeepId = {keepId}
            ", keepId);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}