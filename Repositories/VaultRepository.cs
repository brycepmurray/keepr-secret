using System.Data;

namespace keepr_secret.Repositories
{
    public class VaultRepository
    {
        private readonly IDbConnection _db;
        public VaultRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}