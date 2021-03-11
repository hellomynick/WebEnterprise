using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Untilities.Constants;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public class DocumentApiClient : BaseApiClient, IDocumentApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserApiClient _userApiClient;

        public DocumentApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration, IUserApiClient userApiClient)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _userApiClient = userApiClient;
        }

        public async Task<bool> CreateDocument(DocumentsCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            var claimsIdentity = this._httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            if (request.DocumentFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.DocumentFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.DocumentFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "documentFile", request.DocumentFile.FileName);
            }
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            requestContent.Add(new StringContent(userId), "userId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.FalcultyOfDocumentID.ToString()) ? "" : request.FalcultyOfDocumentID.ToString()), "FalcultyOfDocumentID");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.MagazineID.ToString()) ? "" : request.MagazineID.ToString()), "MagazineID");

            var response = await client.PostAsync($"/api/documents/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<DocumentsVm>> GetByUserID(GetDocumentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<DocumentsVm>>(
                $"/api/documents/getbyuser?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<bool> DeleteDocument(long id)
        {
            var sessions = _httpContextAccessor
                           .HttpContext
                           .Session
                           .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/documents/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<DocumentsVm>> GetPagings(GetDocumentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<DocumentsVm>>(
                $"/api/documents/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }
    }
}