using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using to_do_app.Models;
using Task = to_do_app.Models.Task;

namespace to_do_app.Controllers
{
    public class TaskController : Controller
    {
        public static Dictionary<int, Task> tasks = new Dictionary<int, Task>();
        public static int task_counter = 0;

        public static int subtask_counter = 0;

        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Id = task_counter;
                task_counter++;
                tasks.Add(task.Id, task);
                return View("index", tasks);
            }
            else
            {
                return View(task);
            }
        }

        public IActionResult Done([FromRoute] int id)
        {
            tasks[id].Status = "done";
            return View("index", tasks);
        }

        public IActionResult Delete([FromRoute] int id)
        {
            tasks.Remove(id);
            return View("index", tasks);
        }

        [HttpGet]
        public IActionResult AddSubtask([FromRoute] int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSubtask(Subtask subtask)
        {
            if (ModelState.IsValid)
            {
                subtask.Id = subtask_counter;
                subtask_counter++;
                subtask.Task = tasks[subtask.TaskId];
                tasks[subtask.TaskId].Subtasks.Add(subtask);
                return View("index", tasks);
            }
            else
            {
                return View(subtask);
            }
        }

        public IActionResult DoneSubtask([FromRoute] int subtask_id)
        {
            foreach (var task in tasks.Values)
            {
                foreach (var st in task.Subtasks)
                {
                    if (st.Id == subtask_id)
                    {
                        st.Status = "done";
                    }
                }
            }
            return View("index", tasks);
        }
    }
}