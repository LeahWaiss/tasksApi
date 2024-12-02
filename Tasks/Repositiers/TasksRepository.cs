using Microsoft.EntityFrameworkCore;
using Tasks.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Tasks.Repositiers
{
    //public class TasksRepository :ITasksRepository
    //{

    //    private readonly TasksDbContext _context;

    //    public TasksRepository(TasksDbContext context)
    //    {
    //        _context = context;
    //    }

    //    
    //    /*       public void Save(TasksModel taskCreat)
    //           {
    //               _context.Tasks.Add(taskCreat);
    //               _context.SaveChanges();
    //           }*/

    //    public void Add(TasksModel task)
    //    {
    //        _context.TasksModel.Add(task);
    //        _context.SaveChanges();
    //    }
    //    //public void UpDateTask(TasksModel task2)
    //    //{
    //    //        _context.TasksModel.Update(task2);
    //    //        _context.SaveChanges();
    //    //}

    //}
    public class TasksRepository : ITaskRepository
    {
        private readonly TasksDbContext _tasksDbContext;

        public TasksRepository(TasksDbContext tasksDbContext)
        {
            _tasksDbContext = tasksDbContext;
        }

        public void CreateTask(TasksModel task)
        {
              

            var user = _tasksDbContext.Users.Where(x => x.id == task.id);
            if (user.Count() > 0)
            {
                _tasksDbContext.Tasks.Add(task);
                _tasksDbContext.SaveChanges();
              
            }
        }

      
        public void DeleteTask(TasksModel task)
        {
            _tasksDbContext.Tasks.Remove(task);
            _tasksDbContext.SaveChanges();

        }

        public List<TasksModel> GetAllTasks(int Id)
        {
            return _tasksDbContext.Tasks.Where(x => x.id == Id).ToList();
        }
        List<TasksModel> GetAllTasksWithUser(int UserId)  
       {
            return _tasksDbContext.Tasks.Where(x => x.UserId == UserId).ToList();

        }



        public void UpdateTask(TasksModel task)
        {
            _tasksDbContext.Tasks.Update(task);
            _tasksDbContext.SaveChanges();
        }

        public List<TasksModel> GetTasks()
        {
            var tasks = _tasksDbContext.Tasks.FromSqlRaw("EXEC Tasks_GetAll").ToList();
            return tasks;
        }

        public IEnumerable<TasksModel> GetAllTasksByUser()
        {
            return _tasksDbContext.Tasks.ToList();
        }
        public List<TasksModel> GetAllTasksWithProject(int projectId)
        {
            return _tasksDbContext.Tasks.ToList();
        }

        //public List<TasksModel> GetAllTasksWithUsers()
        //{
        //    var tasksWithUsers = _tasksDbContext.Tasks
        //                                .Include(t => t.UserId)
        //                                .Select(t => new TasksModel
        //                                {
        //                                    id = t.id,
        //                                    TaskName = t.TaskName,
        //                                    TaskNumber = t.TaskNumber,
        //                                })
        //                                .ToList();

        //    return tasksWithUsers;

        //}


    }
}
