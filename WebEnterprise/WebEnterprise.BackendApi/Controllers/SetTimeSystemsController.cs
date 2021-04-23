using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.SetTimeSystems;
using WebEnterprise.ViewModels.Catalog.SetTimeSystem;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.BackendApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class SetTimeSystemsController : ControllerBase
    {
        private readonly ISetTimeSystemService _setTimeSystemService;

        public SetTimeSystemsController(ISetTimeSystemService setTimeSystemService)
        {
            _setTimeSystemService = setTimeSystemService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contacts = await _setTimeSystemService.GetById(id);
            if (contacts == null)
                return BadRequest("Can not find document");
            return Ok(contacts);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SetTimeSystemCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var settimeid = await _setTimeSystemService.Create(request);
            if (settimeid == 0)
                return BadRequest();
            var time = await _setTimeSystemService.GetById(settimeid);
            return CreatedAtAction(nameof(GetById), new { id = settimeid }, time);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] SetTimeSystemUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = id;
            var affectedResult = await _setTimeSystemService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _setTimeSystemService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] SetTimeSystemPagingRequest request)
        {
            var documents = await _setTimeSystemService.GetAllPaging(request);
            return Ok(documents);
        }
    }
}