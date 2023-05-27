using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OfficeManagement.Models
{
    public class OMContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }

    }
}