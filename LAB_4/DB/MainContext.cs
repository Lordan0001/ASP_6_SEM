using LAB_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LAB_2.DB
{
    public class MainContext : DbContext
    {

        public MainContext():base("MyConnection1") { } 

        public DbSet<Phonebook> numbers { get; set; }
    }
}