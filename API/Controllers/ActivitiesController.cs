using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            List<Activity> returnValue = new List<Activity>();

            try
            {
                returnValue = await Mediator.Send(new List.Query());
            }
            catch (Exception ex)
            {
                // TODO: Logger
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }

        [HttpGet("{id}")] //activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            Activity returnValue = null;

            try
            {
                returnValue = await Mediator.Send(new Details.Query(){ Id = id });
            }
            catch (Exception ex)
            {
                // TODO: Log
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}