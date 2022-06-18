using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            List<Activity> returnValue = new List<Activity>();

            try
            {
                returnValue = await this._context.Activities.ToListAsync();
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
                returnValue = await this._context.Activities.FindAsync(id);
            }
            catch (Exception ex)
            {
                // TODO: Log
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }
    }
}