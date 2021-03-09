using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Contacts;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Catalog.UserImage;

namespace WebEnterprise.BackendApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        //http://localhost:port/contact?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetContactsPagingRequest request)
        {
            var contacts = await _contactsService.GetAllPaging(request);
            return Ok(contacts);
        }

        //http://localhost:port/contact/1
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetById(long contactId)
        {
            var contacts = await _contactsService.GetById(contactId);
            if (contacts == null)
                return BadRequest("Can not find contact");
            return Ok(contacts);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] ContactsCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contactId = await _contactsService.Create(request);
            if (contactId == 0)
                return BadRequest();
            var contact = await _contactsService.GetById(contactId);
            return CreatedAtAction(nameof(GetById), new { id = contactId }, contact);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ContactsUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _contactsService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(int contactId)
        {
            var affectedResult = await _contactsService.Delete(contactId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{contactId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(long contactId, int imageId)
        {
            var image = await _contactsService.GetImageById(imageId);
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
            var imageId = await _contactsService.AddImage(contactId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _contactsService.GetImageById(imageId);

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
            var result = await _contactsService.UpdateImage(imageId, request);
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
            var result = await _contactsService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}