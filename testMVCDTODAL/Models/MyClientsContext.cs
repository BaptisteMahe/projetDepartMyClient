using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCLient.DAL.Models;

namespace MyClient.DAL.Models
{
    public class MyClientsContext : DbContext
    {
        public MyClientsContext(DbContextOptions<MyClientsContext> options) : base(options)
        { }
        public DbSet<Client> Clients { get; set; }     
    }
}
