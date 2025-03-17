﻿using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

using Core;

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

