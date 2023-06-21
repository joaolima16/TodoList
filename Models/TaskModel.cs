using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace todolist.Models
{
    public class TaskModel
    {
        [Required]
        public int? Id { get; set; }
        [MaxLength(50)]
        public string? Task { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public UserModel? User {get;set;}
    }
}