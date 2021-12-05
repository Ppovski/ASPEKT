using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Company;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{

    public class CompanyController : BaseController
    { 
 
        [HttpGet]
        public async Task<ActionResult<List<Company>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command{Id=id});
        }

    }
}