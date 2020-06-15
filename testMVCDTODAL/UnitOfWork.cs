using MyClient.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCLient.DAL.Interfaces;
using MyCLient.DAL.Repositories;

namespace MyClient.DAL
{
    public class UnitOfWork : IDisposable {
        public Boolean disposed = false;
        public readonly MyClientsContext context;
        Lazy<IClientRepository> clientRepository;


        public UnitOfWork(MyClientsContext context,
            Lazy<IClientRepository> clientRepository)
        {
            this.context = context;
            this.clientRepository = clientRepository;
        }


        public IClientRepository ClientRepository { get { return clientRepository.Value; } set { this.clientRepository = new Lazy<IClientRepository>(() => value); } }

        public void Save()
        {
            context.SaveChanges();
        }
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

    }
}
