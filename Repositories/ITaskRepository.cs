using task_api.Models;

namespace task_api.Repositories;

public interface ITaskRepository
{
    IEnumerable<Tasks> GetAllTasks();
    Tasks GetTaskById(int taskId);
    Tasks CreateTask(Tasks newTask);
    Tasks UpdateTask(Tasks updatedTask);
    void DeleteTaskById(int taskId);
}