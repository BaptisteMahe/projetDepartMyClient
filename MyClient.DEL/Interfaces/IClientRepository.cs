using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClient.Dto;

namespace MyCLient.DAL.Interfaces
{
    public interface IClientRepository
    {
        Client getById(int clientId);
        Task<Client> getByIdAsync(int clientId);
        void createClient(Client cl);
        void updateClient(Client cl);

    }
}
