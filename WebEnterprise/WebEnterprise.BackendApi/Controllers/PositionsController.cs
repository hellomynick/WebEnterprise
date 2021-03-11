using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Positions;
using WebEnterprise.ViewModels.Catalog.Positions;

namespace WebEnterprise.BackendApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class PositionsController : Controller
    {
        private readonly IPositionsService _positionsService;

        public PositionsController(IPositionsService positionsService)
        {
            _positionsService = positionsService;
        }

        //http://localhost:port/documents?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetPositionsPagingRequest request)
        {
            var positions = await _positionsService.GetAllPaging(request);
            return Ok(positions);
        }

        [HttpGet("getbyuser")]
        public async Task<IActionResult> GetByUser([FromQuery] GetPositionsPagingRequest request)
        {
            var documents = await _positionsService.GetAllByUserId(request);
            return Ok(documents);
        }

        //http://localhost:port/contact/1
        [HttpGet("{positionId}")]
        public async Task<IActionResult> GetById(int positionId)
        {
            var contacts = await _positionsService.GetById(positionId);
            if (contacts == null)
                return BadRequest("Can not find position");
            return Ok(contacts);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] PositionsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var positionId = await _positionsService.Create(request);
            if (positionId == 0)
                return BadRequest();
            var document = await _positionsService.GetById(positionId);
            return CreatedAtAction(nameof(GetById), new { id = positionId }, document);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] PositionsUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _positionsService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _positionsService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}