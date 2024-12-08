using Camp6AssignmentProductionSales.Model;
using Camp6AssignmentProductionSales.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Camp6AssignmentProductionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IRepository<Staff> _repository;

        public StaffController(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffs = await _repository.GetAllAsync();
            return Ok(staffs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _repository.GetByIdAsync(id);
            if (staff == null) return NotFound();
            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Staff staff)
        {
            await _repository.AddAsync(staff);
            return CreatedAtAction(nameof(GetById), new { id = staff.StaffId }, staff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Staff staff)
        {
            if (id != staff.StaffId) return BadRequest();
            await _repository.UpdateAsync(staff);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
