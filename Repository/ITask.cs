using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist.Models;

namespace todolist.Repository
{
    public interface ITask
    {
        public TaskModel AddTask(TaskModel task);
        public List<TaskModel> ListTasks(int userId);
        public TaskModel UpdateTask(int id, TaskModel new_task);
        public Boolean deleteTask(int id);
    }
}