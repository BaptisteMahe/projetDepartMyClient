using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using MyClient.DAL.Models;
using MyClient.Dto;
using MyCLient.DAL.Interfaces;

namespace MyCLient.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        //public ClientRepository
        private MyClientsContext db = new MyClientsContext(new DbContextOptionsBuilder<MyClientsContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options);

        public void createClient(Client cl)
        {
            Models.Client clientToAdd = new Models.Client
            {
                Name = cl.Name,
                Email = cl.Email,
                NbConnections = cl.NbConnections
            };
            this.db.Add(clientToAdd);
        }

        public Client getById(int clientId)
        {
            var Client = db.Clients.Find(clientId);

            return ToDto(Client);

        }

        public Task<Client> getByIdAsync(int clientId)
        {
            return null;

        }

        public void updateClient(Client cl)
        {

        }

        private static MyClient.Dto.Client ToDto(Models.Client client)
        {
            return new MyClient.Dto.Client
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                NbConnections = client.NbConnections
            };
        }
        
    }
}
