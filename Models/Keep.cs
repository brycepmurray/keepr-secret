using System.Collections.Generic;

namespace keepr_secret.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int Views { get; set; }
        public int Saves { get; set; }
    }
}