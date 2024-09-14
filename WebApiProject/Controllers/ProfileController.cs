using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BtnxProfileApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private static List<PersonProfile> profiles = new List<PersonProfile>();

        [HttpPost]
        [HttpOptions]
        public IActionResult CreateProfile([FromBody] PersonProfile profile)
        {
            if (HttpContext.Request.Method == HttpMethods.Options)
            {
                return HandleOptionsRequest();
            }

            if (profile == null)
            {
                return BadRequest("Profile cannot be null.");
            }

            profile.Id = profiles.Count+1; // Simple ID assignment
            profiles.Add(profile);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        private IActionResult HandleOptionsRequest()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "POST, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            Response.Headers.Add("Access-Control-Max-Age", "86400");
            return Ok();
        }

        // GET api/profile/list
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            // Return all profiles
            return Ok(profiles);
        }

        // PUT api/profile/5
        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, [FromBody] PersonProfile profile)
        {
            if (profile == null || id <= 0)
            {
                return BadRequest("Invalid profile or ID.");
            }

            var existingProfile = profiles.Find(p => p.Id == id);
            if (existingProfile == null)
            {
                return NotFound();
            }

            existingProfile.FirstName = profile.FirstName;
            existingProfile.LastName = profile.LastName;
            existingProfile.Email = profile.Email;
            existingProfile.Phone = profile.Phone;

            return Ok(existingProfile);
        }

        // GET api/profile/5
        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var profile = profiles.Find(p => p.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
    }

    public class PersonProfile
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
