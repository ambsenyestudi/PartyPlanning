using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace PartyPlanning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> logger;

        public EventsController(ILogger<EventsController> logger)
        {
            this.logger = logger;
        }
        // GET: api/Events
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogDebug($"Events gotten at {DateTime.UtcNow.ToShortTimeString()}");
            return new string[] { "value1", "value2" };
        }

        // GET: api/Events/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Events
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
