using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week6.Academy.MVC.Models
{
    public class UtenteLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public Role Ruolo { get; set; }
    }
    public enum Role
    {
        Ristoratore = 1, //Admin
        Cliente = 2 //user
    }
}
