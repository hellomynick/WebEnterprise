using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Documents;
using WebEnterprise.ViewModels.Catalog.Document;

namespace WebEnterprise.BackendApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService _documentsService;

        public DocumentsController(IDocumentsService documentsService)
        {
            _documentsService = documentsService;
        }

        //http://localhost:port/documents?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetDocumentsPagingRequest request)
        {
            var documents = await _documentsService.GetAllPaging(request);
            return Ok(documents);
        }

        [HttpGet("getbyuser")]
        public async Task<IActionResult> GetByUser([FromQuery] GetDocumentsPagingRequest request)
        {
            var documents = await _documentsService.GetAllByUserId(request);
            return Ok(documents);
        }

        //http://localhost:port/contact/1
        [HttpGet("{documentId}")]
        public async Task<IActionResult> GetById(long documentId)
        {
            var contacts = await _documentsService.GetById(documentId);
            if (contacts == null)
                return BadRequest("Can not find document");
            return Ok(contacts);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] DocumentsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var documentId = await _documentsService.Create(request);
            if (documentId == 0)
                return BadRequest();
            var document = await _documentsService.GetById(documentId);
            return CreatedAtAction(nameof(GetById), new { id = documentId }, document);
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromForm] ContactsUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var affectedResult = await _contactsService.Update(request);
        //    if (affectedResult == 0)
        //        return BadRequest();
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _documentsService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}