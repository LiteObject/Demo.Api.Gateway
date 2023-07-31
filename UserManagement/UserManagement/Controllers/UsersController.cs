using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> Users = new()
        {
            new User { Id = 1, Name = "John Smith", Email = "john.smith@example.com" },
            new User { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com" },
            new User { Id = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com" },
            new User { Id = 4, Name = "Alice Brown", Email = "alice.brown@example.com" }
        };

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult Get()
        {
            List<User> users = Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public IActionResult GetById(int id)
        {
            User? user = Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(User newUser)
        {
            int newId = Users.Max(u => u.Id) + 1;
            newUser.Id = newId;

            Users.Add(newUser);

            return CreatedAtAction(nameof(GetById), new { Id = newUser.Id }, newUser);
        }
    }
}