using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HW5.Models;

namespace HW5.DAL
{
    public class FormsContext : DbContext 
    {
        public FormsContext() : base("name=Forms")
        {

        }

        public virtual DbSet<Form> Forms { get; set; }
    }
}