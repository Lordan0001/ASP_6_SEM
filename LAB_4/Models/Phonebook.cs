using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB_2.Models
{
    public class Phonebook 
    {
        [Required(ErrorMessage ="Enter id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Number")]
        [RegularExpression(@"\+[0-9]{10,12}", ErrorMessage = "wrong number format,correct is [+375][**][1111111]")]
        public string Number { get; set; }
    }
}