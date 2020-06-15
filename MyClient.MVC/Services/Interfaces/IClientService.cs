using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClient.Dto;
namespace MyClient.MVC.Services.Interfaces
{
    public interface IClientService
    {
        Client GetClient(int id);

        Client AddClient(Client c);


        Client UpdateClient(Client c);
    }
}
