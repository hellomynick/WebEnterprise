using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Comments;
using WebEnterprise.ViewModels.Catalog.Comment;

namespace WebEnterprise.BackendApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCommentsPagingRequest request)
        {
            var documents = await _commentsService.GetAllPaging(request);
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contacts = await _commentsService.GetById(id);
            if (contacts == null)
                return BadRequest("Can not find document");
            return Ok(contacts);
        }

        [HttpPost("{create}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] CommentsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var documentId = await _commentsService.Create(request);
            if (documentId == 0)
                return BadRequest();
            var document = await _commentsService.GetById(documentId);
            return CreatedAtAction(nameof(GetById), new { id = documentId }, document);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] CommentsUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.ID = id;
            var affectedResult = await _commentsService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _commentsService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}