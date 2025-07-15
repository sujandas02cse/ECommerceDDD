using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace ECommerce.Application.DTOs
{
    public class AddressDTO
    {
        [Required, MaxLength(250)]
        public string Street { get; set; } = null!;
        [Required, MaxLength(100)]
        public string City { get; set; } = null!;
        [Required, MaxLength(100)]
        public string State { get; set; } = null!;
        [Required, MaxLength(20)]
        public string PostalCode { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Country { get; set; } = null!;
    }
}