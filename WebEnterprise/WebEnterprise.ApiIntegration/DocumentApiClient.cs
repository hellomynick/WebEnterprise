﻿using Microsoft.AspNetCore.Http;
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
using WebEnterprise.ViewModels.Catalog.Comment;
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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Caption.ToString()) ? "" : request.Caption.ToString()), "Caption");
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

        public async Task<PagedResult<DocumentsVm>> GetTotal(GetDocumentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<DocumentsVm>>(
                $"/api/documents/getbytotal?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<PagedResult<DocumentsVm>> GetForManager(GetDocumentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<DocumentsVm>>(
                $"/api/documents/getformanager?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<PagedResult<DocumentsVm>> GetForGuest(GetDocumentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<DocumentsVm>>(
                $"/api/documents/getforguest?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<bool> UpdateDocument(DocumentsUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

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
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content), "Content");
            var response = await client.PutAsync($"/api/documents/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<DocumentsVm> GetById(long id)
        {
            var data = await GetAsync<DocumentsVm>($"/api/documents/{id}");

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

        public async Task<PagedResult<DocumentsVm>> GetByFaculty(GetDocumentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<DocumentsVm>>(
                $"/api/documents/getbyfaculty?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<bool> PostDocument(DocumentsPostRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Status.ToString()) ? "" : request.Status.ToString()), "Status");

            var response = await client.PutAsync($"/api/documents/post/" + request.ID, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}