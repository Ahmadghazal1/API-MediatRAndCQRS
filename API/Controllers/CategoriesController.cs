using API.Command;
using API.Query;
using Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllCategoriesQuery();

            var result = await _mediator.Send(query); 

            if(result is null)
                return NotFound("No Data Found");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var query = new GetCategoryQuery(id);

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound($"The Category with Id {id} not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryRequestDto categoryRequestDto)
        {
            var command = new CreateCategoryInfoRequest(categoryRequestDto);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryRequestDto categoryRequestDto , [FromRoute] int id)
        {
            var command = new UpdateCategoryInfoRequest(id,categoryRequestDto);
            var result = await _mediator.Send(command);

            if (result is null)
                return NotFound($"The category that should updated not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync( [FromRoute] int id)
        {
            var command = new DeleteCategoryInfoRequest(id);
            var result = await _mediator.Send(command);

            if (result is null)
                return NotFound($"The category that should deleted not found");
            return Ok(result);
        }


    }
}
