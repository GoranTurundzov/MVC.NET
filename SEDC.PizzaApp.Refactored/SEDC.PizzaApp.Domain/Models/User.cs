﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SEDC.PizzaApp.Domain.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public long Phone { get; set; }

        public List<Order> Orders { get; set; }
        
    }
}
