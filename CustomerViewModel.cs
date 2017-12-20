using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CricketData.Models.Entities;
using CricketData.HashingAndSalting;

namespace CricketData.Models.ViewModels
{
    public class CustomerViewModel
    {

        static PasswordManager pwdManager = new PasswordManager();

        public int Id { get; set; }
       
        [Required(ErrorMessage = "Please enter your first name")]
        [RegularExpression(@"([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [RegularExpression(@"([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@".+\@.+\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }/// <summary>
        
        // </summary>

        [Required(ErrorMessage = "Please enter your password")]
        [RegularExpression(@"([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of Last Name")]
        public string Password { get; set; }
        public int PrivilegeId { get; set; }

        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public void GeneratePasswordHash()
        {
            string salt = null;
            this.PasswordHash = pwdManager.GeneratePasswordHash(Password, out salt);
            this.Salt = salt;
        }

        public Customer Customer
        {
              get
            {
                Customer tempCustomer = new Customer() { CustomerId = this.Id, PasswordHash = this.PasswordHash, Salt = this.Salt, Password = this.Password, FirstName = this.FirstName, LastName = this.LastName, Email = this.Email, };
                return tempCustomer;
            }
        }


        public CustomerViewModel(Customer customer)
        {

            this.Id = customer.CustomerId;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.Email = customer.Email;
            this.Password = customer.Password;
            this.Salt = customer.Salt;
            this.PasswordHash = customer.PasswordHash;
            this.PrivilegeId = customer.PrivilegeId;
        }

        public CustomerViewModel()
        {

        }
    }
}