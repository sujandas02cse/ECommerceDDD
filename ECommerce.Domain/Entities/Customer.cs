﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    [Index(nameof(Email), Name = "Index_RegistrationNumber", IsUnique = true)]
    public class Customer
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; private set; }



        [Required, MaxLength(100)]

        public string FirstName { get; private set; } = null!;



        [MaxLength(100)]

        public string? LastName { get; private set; }



        [Required, EmailAddress]

        public string Email { get; private set; } = null!;



        public Address Address { get; private set; } = null!;



        // Navigation property for Orders of this Customer 

        public ICollection<Order> Orders { get; private set; } = new List<Order>();



        private Customer() { }



        public Customer(string firstName, string lastName, string email, Address address)

        {

            FirstName = firstName;

            LastName = lastName;

            Email = email;

            Address = address;

        }


    }
}
