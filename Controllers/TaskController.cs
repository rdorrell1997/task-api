using Microsoft.AspNetCore.Mvc;
using task_api.Models;
using task_api.Repositories;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController: ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskRepository _taskRepository;

    public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _taskRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tasks>> GetTasks()
    {
        return Ok(_taskRepository.GetAllTasks());
    }

    [HttpPost]
    public ActionResult<Tasks> CreateTask(Tasks task)
    {
        if(!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }

        var newTask = _taskRepository.CreateTask(task);
        return newTask;
    }

    [HttpPut]
    [Route("{taskId:int}")]
    public ActionResult<Tasks> UpdateTask(Tasks task)
    {
        if(!ModelState.IsValid || task == null)
        {
            return BadRequest();
        }

        return Ok(_taskRepository.UpdateTask(task));
    }

    [HttpDelete]
    [Route("{taskId:int}")]
    public ActionResult<Tasks> DeleteTask(int taskId)
    {
        _taskRepository.DeleteTaskById(taskId);
        return NoContent();
    }

    [HttpGet]
    [Route("{taskId:int}")]
    public ActionResult<Tasks> GetTaskById(int taskId)
    {
        var task = _taskRepository.GetTaskById(taskId);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
}