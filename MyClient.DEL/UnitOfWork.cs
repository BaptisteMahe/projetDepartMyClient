using MyClient.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCLient.DAL.Interfaces;
using MyCLient.DAL.Repositories;
using MyClient.DAL;


/** 
 * Abstraction entre le controlleur et la couche d'accès aux données 
 *  https://docs.microsoft.com/fr-fr/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
 **/
namespace MyClient.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork {
        public Boolean disposed = false;
        public readonly MyClientsContext context;
        IClientRepository clientRepository;


        public UnitOfWork(MyClientsContext context,
            IClientRepository clientRepository)
        {
            this.context = context;
            this.clientRepository = clientRepository;
        }


        public IClientRepository ClientRepository { get { return clientRepository; } set { this.clientRepository = new ClientRepository(context); } }

       
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.Dispose();
            }

            this.disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
        }

        /** Doit être appelée par le service apres CHAQUE MODIFICATION de la base **/
        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
