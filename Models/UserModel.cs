using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
       
        public string? Username { get; set; }
        public string? Password { get; set; }
        
    }
}