using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClient.Dto;
using MyClient.MVC.Services;
using MyClient.MVC.Services.Interfaces;

namespace MyClient.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }


        [HttpGet("{id}")]
        public Client GetClient(int id)
        {
            var userId = id;
            var user = service.GetClient(userId);
            return user;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return service.getClients();
        }


        [HttpPost]
        public Client AddOrUpdateClient(int id,Client c)
        {
            if(service.GetClient(c.Id) != null)
            {
                return service.UpdateClient(c);
            }
            return service.AddClient(c);
        }


    }
}
