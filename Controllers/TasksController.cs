using DotnetTask.Model;
using DotnetTask.Services;
using DotnetTask.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITask taskservice;
        public TasksController(ITask taskservice)
        {
            this.taskservice = taskservice;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(MyTaskVM myTaskVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MyTask task = new MyTask();
                    task.TaskId = myTaskVM.TaskId;
                    task.Title = myTaskVM.Title;
                    task.Description = myTaskVM.Description;
                    task.Status = myTaskVM.Status;
                    MyTask createdtask =  await taskservice.CreateTask(task);
                    return Ok(createdtask);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await taskservice.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            try
            {
                var task = await taskservice.GetTask(id);
                if(task==null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error Occured"+ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(MyTaskVM myTaskVM,int Id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var updatetask = await taskservice.GetTask(Id);
                    updatetask.Title = myTaskVM.Title;  
                    updatetask.Description = myTaskVM.Description;
                    updatetask.Status = myTaskVM.Status;
                    taskservice.UpdateTask(updatetask);
                    return Ok(updatetask);
                }
                else
                {
                    return BadRequest(ModelState);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
              string message= await taskservice.DeleteTask(id);
                return Ok(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

    }
}
