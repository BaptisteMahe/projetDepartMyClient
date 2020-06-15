using MyCLient.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClient.DAL.Interfaces
{
    interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; set; }

        void save();

        Task SaveAsync();
    }
}
