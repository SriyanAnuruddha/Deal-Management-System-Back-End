﻿using Deal_Management_System.Validations;
using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }


        public string PasswordHash { get; set; }
    }
}
