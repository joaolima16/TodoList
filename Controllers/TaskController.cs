using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolist.Models;
using todolist.Repository;
namespace todolist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ITask _ITask;

        public TaskController(ITask iTask) => _ITask = iTask;

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel task){
            try{
                _ITask.AddTask(task);
                return Ok(task);
            }
            catch(Exception ex){
                return BadRequest("Ocorreu um erro com a aplicação: " + ex.Message);
            }
        }
    }
}