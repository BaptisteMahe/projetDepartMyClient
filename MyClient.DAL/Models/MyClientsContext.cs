using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCLient.DAL.Models;

/** Contexte de la base de donnée **/

namespace MyClient.DAL.Models
{
    public partial class MyClientsContext : DbContext
    {
        public MyClientsContext(DbContextOptions<MyClientsContext> options) : base(options)
        { }

        /** Un DbSet par table de la base que l'on récupère **/
        public DbSet<Client> Clients { get; set; }     
    }
}
