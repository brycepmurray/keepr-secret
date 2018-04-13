using System.Collections.Generic;

namespace keepr_secret.Models
{
    public class Mine
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
    }
}