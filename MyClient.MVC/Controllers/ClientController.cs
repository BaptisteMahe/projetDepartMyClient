using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        public IActionResult GetClient(int id)
        {
            var userId = id;
            var user = service.GetClient(userId);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            List<Client> allClients = service.getClients();
            if(allClients.Count > 0)
            {
                return Ok(allClients);
            }
            return Ok("No Clients on database");
        }


        [HttpPost]
        public IActionResult AddOrUpdateClient(int id,Client c)
        {
            if(service.GetClient(c.Id) != null)
            {
                return Ok(service.UpdateClient(c));
            }
            return Ok(service.AddClient(c));
        }


    }
}
