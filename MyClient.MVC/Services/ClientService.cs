using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClient.Dto;
using MyClient.DAL;


namespace MyClient.MVC.Services
{
    //Ou est initialisé UnitOfWork
    public class ClientService : Interfaces.IClientService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public MyClient.Dto.Client GetClient(int clientId)
        {
            return unitOfWork.ClientRepository.getById(clientId);
        }

        public Client AddClient(Client c)
        {
            unitOfWork.ClientRepository.createClient(c);
            unitOfWork.Save();

            return unitOfWork.ClientRepository.getById(c.Id);
        }

        public Client UpdateClient(Client c)
        {
            unitOfWork.ClientRepository.updateClient(c);
            unitOfWork.Save();

            return unitOfWork.ClientRepository.getById(c.Id);
        }
    }
}
