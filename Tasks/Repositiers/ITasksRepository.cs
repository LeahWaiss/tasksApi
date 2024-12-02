using Tasks.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Tasks.Repositiers
{
    //    public interface ITasksRepository
    //    {
    //        public IEnumerable<TasksModel> GetAll();
    //        public void Add(TasksModel task);
    //     ///   public void UpDateTask(TasksModel task2);

    ///*        public void Save(TasksModel taskCreat);
    //        void Save();*/
    //    }
    public interface ITaskRepository
    {
        List<TasksModel> GetAllTasks(int Id);

        // List<TasksWithUsers> GetAllTasksWithUsers();
      
        bool CreateTask(TasksModel task);

        void UpdateTask(TasksModel task);

        void DeleteTask(TasksModel task);
        List<TasksModel> GetAllTasksWithUser(int UserId);
         IEnumerable<TasksModel> GetAllTasksByUser(int id);
        List<TasksModel> GetAllTasksWithProject(int projectId);
    }
}
