﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab8a_API.Models
{
    [Table("Phone")]
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string OwnerName { get; set; }

        public Phone(int id, string number, string name)
        {
            Id = id;
            PhoneNumber = number;
            OwnerName = name;
        }

        public Phone() { }

    }
}
