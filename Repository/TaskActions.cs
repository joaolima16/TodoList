using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using todolist.Context;
using todolist.Models;

namespace todolist.Repository
{
    public class TaskActions : ITask
    {
        private DataContext _DataContext;
        public TaskActions(DataContext data) => _DataContext = data;

        public TaskModel AddTask(TaskModel task)
        {
            try
            {
                UserModel user = _DataContext.User.Find(task.UserId);
                task.User = user;
                _DataContext.Task.Add(task);
                _DataContext.SaveChanges();
                return task;
            }

            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Boolean deleteTask(int id)
        {
           try{
              
                if(_DataContext.Task.Where(p => p.Id == id).Any()){
                        TaskModel task = _DataContext.Task.Where(p => p.Id == id).First();
                        _DataContext.Task.Remove(task);
                        _DataContext.SaveChanges();
                        return true;
                }
                return false;

           }
           catch(DbException ex){
                Console.WriteLine(ex.Message);
                return false;
           }
        }

        public List<TaskModel> ListTasks(int userId)
        {
            List<TaskModel> tasks = new List<TaskModel>();
            try
            {
                if(_DataContext.Task.Where(p => p.UserId == userId).Any()){
                    tasks = _DataContext.Task.Where(p => p.UserId == userId).ToList();

                    return tasks;
                }
                return null;
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public TaskModel UpdateTask(int id,TaskModel new_task)
        {

            try{
                TaskModel task = _DataContext.Task.Where(p => p.Id == id).First();
                task.Task = new_task.Task;
                task.Description = new_task.Description;
                _DataContext.SaveChanges();
                return task;
            }
            catch(DbException ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}