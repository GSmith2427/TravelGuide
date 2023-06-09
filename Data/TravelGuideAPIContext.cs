using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelGuideAPI.Models;

namespace TravelGuideAPI.Data
{
    public class TravelGuideApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Filename=./TravelGuideApi.db");
        }
    }
}
