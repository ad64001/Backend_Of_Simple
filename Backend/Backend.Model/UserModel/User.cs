using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
  
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? LastLogin { get; set; }
    }
}
