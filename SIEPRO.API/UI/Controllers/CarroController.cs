﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    public class CarroController : BasicCrudController<Carro>
    {
        public CarroController(IRepository<Carro> repository) : base(repository)
        {

        }
    }
}
