using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendAssessment.Models;

namespace BackendAssessment.ConnectionProvider
{
    public class ApplicationConnection : DbContext
    {
        public ApplicationConnection(DbContextOptions<ApplicationConnection> options) : base(options)
        {
        }
        public DbSet<Orders> orders { get; set; }
    }
}