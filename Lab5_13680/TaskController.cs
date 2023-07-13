using Microsoft.AspNetCore.Mvc;
using lab5_13680;
using System.Collections.Generic;

namespace lab5_13680
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _taskManager;

        public TaskController()
        {
            _taskManager = new TaskManager();
        }

        // GET: api/Task
        [HttpGet]
        public ActionResult<List<Task>> GetAllTasks()
        {
            return _taskManager.GetTasks();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = _taskManager.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        // POST: api/Task
        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            _taskManager.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var wasUpdated = _taskManager.UpdateTask(id, task);

            if (!wasUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var wasDeleted = _taskManager.DeleteTask(id);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
