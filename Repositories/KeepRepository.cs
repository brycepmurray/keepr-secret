using System.Data;

namespace keepr_secret.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;
        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}