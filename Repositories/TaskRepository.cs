using task_api.Migrations;
using task_api.Models;

namespace task_api.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public Tasks CreateTask(Tasks newTask)
    {
        _context.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public void DeleteTaskById(int taskId)
    {
        var task = _context.Tasks.Find(taskId);
        if(task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Tasks> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }

    public Tasks GetTaskById(int taskId)
    {
        return _context.Tasks.SingleOrDefault(t => t.Id == taskId);
    }

    public Tasks UpdateTask(Tasks task)
    {
        var updatedTask = _context.Tasks.Find(task.Id);
        if(updatedTask != null)
        {
            updatedTask.Title = task.Title;
            updatedTask.Completed = task.Completed;
            _context.SaveChanges();
        }
        return updatedTask;
    }
}