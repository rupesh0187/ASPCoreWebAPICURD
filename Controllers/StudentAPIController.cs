using ASPCoreWebAPICURD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentAPIController(StudentDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<StudentAPI>>> GetStudents()
        {
            var data = await context.StudentAPIS.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAPI>> GetStudentById(int id)
        {
            var student = await context.StudentAPIS.FindAsync(id);
            if (student == null) 
            {
                return NotFound();
            }
            return student;
        }
        [HttpPost]
        public async Task<ActionResult<StudentAPI>> CreateStudent(StudentAPI student)
        {
            await context.StudentAPIS.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentAPI>> UpdateStudent(int id,StudentAPI std)
        {
            if(id != std.Id) 
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentAPI>> DeleteStudent(int id)
        {
            var std = await context.StudentAPIS.FindAsync(id);
            if(std == null)
            {
                return NotFound();

            }
            context.StudentAPIS.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
    }
}
