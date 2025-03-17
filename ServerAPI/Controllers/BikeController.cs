using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

using Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/bike")]
    public class BikeController : ControllerBase
    {

        private IBikeRepository bikeRepo;

        public BikeController(IBikeRepository bikeRepo) {
            this.bikeRepo = bikeRepo;
        }

        [HttpGet]
        public IEnumerable<BEBike> Get()
        {
            return bikeRepo.GetAll();
        }
        

        [HttpPost]
        public void Add(BEBike bike) {
            bikeRepo.Add(bike);
        }
        



    }
}

