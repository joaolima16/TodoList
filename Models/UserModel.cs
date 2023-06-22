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
        [Required]
        [StringLength(40, MinimumLength =4, ErrorMessage = " O usuário deve ter no minimo 4 caracteres")]

        public string? Username { get; set; }
        [Required]
         [StringLength(30, MinimumLength =6, ErrorMessage = " A senha deve ter no minimo 6 caracteres")]
        public string? Password { get; set; }
        
    }
}