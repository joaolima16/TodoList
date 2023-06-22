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
    public class UserController : ControllerBase
    {

        private IUser _IUser;
        public UserController(IUser iUser) => _IUser = iUser;

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserModel user)
        {
            try
            {
                _IUser.addUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult LoginUser([FromBody] UserModel user)
        {
            var _user = _IUser.LoginUser(user);
            try
            {
                if (_user == true)
                {
                    return Ok("Usuário Logado!");
                }
                return BadRequest("Usuário ou senha incorretos");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro com aplicação" + ex.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            try
            {
                var _user = _IUser.updateUser(id, user);
                if(_user == null){
                    return BadRequest($"Usuário com id: {id} não encontrado");
                }
                return Ok(_user);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id){
            try{
                _IUser.deleteUser(id);
                return Ok($"Usuário com id: {id} deletado");
            }
            catch(Exception ex){
                return BadRequest("Ocorreu um erro ao deletar o usuário: " + ex.Message);
            }
        }
    }
}