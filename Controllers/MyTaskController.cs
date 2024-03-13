using DotnetTask.Model;
using DotnetTask.Services;
using DotnetTask.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        private ITask taskservice;
        public MyTaskController(ITask taskservice) 
        {
            this.taskservice=taskservice;
        }
        [Route("CreateTask")]
        [HttpPost]
        public async ActionResult CreateTask(MyTaskVM myTaskVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MyTask newtask = new MyTask()
                    {
                        Title = myTaskVM.TitleVM,
                        Description = myTaskVM.DescriptionVM,
                        GetStatus = Enum.Parse<Status>(myTaskVM.GetStatusVM),

                    };
                }
            }
            catch (Exception ex)
            {

            }
        }

        [Route("GetAllTasks")]
        [HttpGet]
        public async Task<ActionResult> GetAllTasks() 
        {
           try
            {
                var tasks=taskservice.GetAlltasks();
                return Ok(tasks);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }
        }

        public 
    }
}
