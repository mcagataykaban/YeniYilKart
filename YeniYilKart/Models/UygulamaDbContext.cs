using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YeniYilKart.Models
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext() : base("name=UygulamaDbContext")
        {

        }
        public DbSet<Kart> Kartlar { get; set; }
    }
}