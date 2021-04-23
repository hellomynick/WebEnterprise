using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Untilities.Constants;
using WebEnterprise.ViewModels.Catalog.Comment;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public class CommentApiClient : BaseApiClient, ICommentApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserApiClient _userApiClient;

        public CommentApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration, IUserApiClient userApiClient)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _userApiClient = userApiClient;
        }

        public async Task<bool> CreateComment(CommentsCreateRequest request)
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
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            requestContent.Add(new StringContent(userId), "userId");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content.ToString()) ? "" : request.Content.ToString()), "Content");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.DocumentID.ToString()) ? "" : request.DocumentID.ToString()), "DocumentID");

            var response = await client.PostAsync($"/api/comments/create", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteComment(int id)
        {
            var sessions = _httpContextAccessor
                           .HttpContext
                           .Session
                           .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/comments/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<CommentsVm> GetById(int id)
        {
            var data = await GetAsync<CommentsVm>($"/api/comments/{id}");

            return data;
        }

        public async Task<PagedResult<CommentsVm>> GetPagings(GetCommentsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<CommentsVm>>(
                $"/api/comments/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<bool> UpdateComment(CommentsUpdateRequest request)
        {
            {
                var sessions = _httpContextAccessor
                    .HttpContext
                    .Session
                    .GetString(SystemConstants.AppSettings.Token);
                var client = _httpClientFactory.CreateClient("BackendApi");
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var requestContent = new MultipartFormDataContent();

                requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Content) ? "" : request.Content), "Content");
                var response = await client.PutAsync($"/api/comments/" + request.ID, requestContent);
                return response.IsSuccessStatusCode;
            }
        }
    }
}