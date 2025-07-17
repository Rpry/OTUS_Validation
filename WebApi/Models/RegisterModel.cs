using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using WebApi.ValidationAttributes;

namespace WebApi.Models
{
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        //[MinLength(9)]
        public string Password { get; set; }

        //[RegularExpression(@"^\+79\d{9}$")]
        public string Phone { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
    }
}