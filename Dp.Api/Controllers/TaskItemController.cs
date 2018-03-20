using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using Dp.Models.Database;
using Dp.Services;

namespace DP.Api.Controllers
{
    [Route("api/tasks")]
    public class TaskItemController : ApiController
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _taskItemService.DeleteAsync(id: id);
            return StatusCode(status: HttpStatusCode.NoContent);
        }


        // GET api/values
        // GET api/values/5
        [HttpGet]
        
        public async Task<IHttpActionResult> Get(int? id = null)
        {
            if (id == null)
            {
                var tasks = await _taskItemService.GetAllAsync();
                return Ok(content: tasks);

            }
            var task = await _taskItemService.GetByIdAsync(id: id.Value);
            return Ok(content: task);
        }

        /// <response code="201">Task Item created</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] TaskItem taskItem)
        {
            int id = await _taskItemService.CreateAsync(taskItem: taskItem);

            return CreatedAtRoute("GetTaskItem", routeValues: new {id}, content: taskItem);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] TaskItem taskItem)
        {
            if (taskItem == null || taskItem.Id != id) return BadRequest();

            await _taskItemService.UpdateAsync(taskItem: taskItem);

            return StatusCode(status: HttpStatusCode.NoContent);
        }
    }
}