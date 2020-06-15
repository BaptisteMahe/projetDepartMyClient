using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MyClient.DAL.Models;
using MyClient.DAL;
using MyClient.Dto;
using MyCLient.DAL.Interfaces;


/** Gère les appels à la BD **/

namespace MyCLient.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly MyClientsContext db;
        public ClientRepository(MyClientsContext db) {
            this.db = db;
        }

        public List<Client> getClients()
        {
            List<DAL.Models.Client> listeClientsDAL = db.Clients.ToList();
            List<Client> listeDto = new List<Client>();
            foreach(DAL.Models.Client cDal in listeClientsDAL)
            {
                listeDto.Add(ToDto(cDal));
            }
            return listeDto;

        }
        public void createClient(Client cl)
        {
            Models.Client clientToAdd = new Models.Client
            {
                Name = cl.Name,
                Email = cl.Email,
                NbConnections = cl.NbConnections
            };
            db.Clients.Add(clientToAdd);
        }

        public Client getById(int clientId)
        {
            var Client = db.Clients.Find(clientId);
            Console.WriteLine(this.db.Clients);
            return ToDto(Client);
        }

        public async Task<Client> getByIdAsync(int clientId)
        {
            Models.Client found = await db.Clients.FindAsync(clientId);
            return ToDto(found);
        }

        public void updateClient(Client cl)
        {
            var client = getById(cl.Id);
            client.Name = cl.Name;
            client.Email = cl.Email;
            client.NbConnections = cl.NbConnections;
        }

        private static MyClient.Dto.Client ToDto(Models.Client client)
        {
            return (client != null) ? new MyClient.Dto.Client
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                NbConnections = client.NbConnections
            } : null;
        }
        
    }
}
