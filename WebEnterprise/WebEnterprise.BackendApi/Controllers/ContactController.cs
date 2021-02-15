using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Contacts;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Catalog.UserImage;

namespace WebEnterprise.BackendApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IPuclicContactsService _puclicContactsService;
        private readonly IManageContactsService _manageContactsService;

        public ContactController(IPuclicContactsService puclicContactsService, IManageContactsService manageContactsService)
        {
            _puclicContactsService = puclicContactsService;
            _manageContactsService = manageContactsService;
        }

        //http://localhost:port/contact?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("request")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetPublicContactsPagingRequest request)
        {
            var contacts = await _puclicContactsService.GetAllByUserId(request);
            return Ok(contacts);
        }

        //http://localhost:port/contact/1
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetById(long contactId)
        {
            var contacts = await _manageContactsService.GetById(contactId);
            if (contacts == null)
                return BadRequest("Can not find contact");
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ContactsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contactId = await _manageContactsService.Create(request);
            if (contactId == 0)
                return BadRequest();
            var contact = await _manageContactsService.GetById(contactId);
            return CreatedAtAction(nameof(GetById), new { id = contactId }, contact);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContactsUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _manageContactsService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            var affectedResult = await _manageContactsService.Delete(contactId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{contactId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(long contactId, int imageId)
        {
            var image = await _manageContactsService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find contact");
            return Ok(image);
        }

        //Image
        [HttpPost("{contactId}/images")]
        public async Task<IActionResult> CreateImage(int contactId, [FromForm] UserImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageContactsService.AddImage(contactId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _manageContactsService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{contactId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] UserImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageContactsService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{contactId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageContactsService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}