﻿using System.ComponentModel.DataAnnotations;

namespace Loren_TPI_Prog3.Data.Models
{
    public class AdminPostDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
