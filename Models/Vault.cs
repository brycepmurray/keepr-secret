using System.Collections.Generic;

namespace keepr_secret
{
    public class Vault
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }

}