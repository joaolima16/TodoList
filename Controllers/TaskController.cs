using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel task)
        {
            try
            {
                _ITask.AddTask(task);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro com a aplicação: " + ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult listTasks(int id)
        {
            try
            {
                List<TaskModel> tasks = _ITask.ListTasks(id);
                if (tasks != null)
                {
                    return Ok(tasks);
                }
                return BadRequest("Dados não encontrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskModel new_task)
        {
            try
            {
                _ITask.UpdateTask(id, new_task);
                return Ok("Task atualizada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                Boolean delTask = _ITask.deleteTask(id);
                if (delTask == true)
                {
                    return Ok($"Task deletada, id: {id}");
                }
                return BadRequest($"Não foi possível deletar a task de id: {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}