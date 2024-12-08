using Camp6AssignmentProductionSales.Model;
using Camp6AssignmentProductionSales.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Camp6AssignmentProductionSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IRepository<Store> _repository;

        public StoreController(IRepository<Store> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stores = await _repository.GetAllAsync();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var store = await _repository.GetByIdAsync(id);
            if (store == null) return NotFound();
            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Store store)
        {
            await _repository.AddAsync(store);
            return CreatedAtAction(nameof(GetById), new { id = store.StoreId }, store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Store store)
        {
            if (id != store.StoreId) return BadRequest();
            await _repository.UpdateAsync(store);
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
