using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Domain;
using TodoApi.Service.Interfaces;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return  _todoService.All();
        }

        [HttpPost]
        public ActionResult<ToDoItem> Post([FromBody] ToDoItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _todoService.Insert(item);
            return item;
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoService.Delete(id);

            return Ok();
        }

    }
}