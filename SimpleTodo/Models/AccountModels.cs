using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace SimpleTodo.Models
{
    public class LogOnModel : Entity
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long ಠ_ಠ.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Remember me!?")]
        public bool RememberMe { get; set; }
    }

    public class Context : DbContext
    {
        public DbSet<LogOnModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
        }
    }

//    public class RegisterModel
//    {
//        [Required]
//        [Display(Name = "User name")]
//        public string UserName { get; set; }
//
//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }
//
//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }
}
