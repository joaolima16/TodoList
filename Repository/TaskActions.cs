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
    }
}