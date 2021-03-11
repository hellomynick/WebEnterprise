using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Untilities.Constants;
using WebEnterprise.ViewModels.Catalog.Positions;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public class PositionApiClient : BaseApiClient, IPositionApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserApiClient _userApiClient;

        public PositionApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration, IUserApiClient userApiClient)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _userApiClient = userApiClient;
        }

        public async Task<bool> CreatePosition(PositionsCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name), "Name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.FacultyID.ToString()) ? "" : request.FacultyID.ToString()), "FacultyID");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.UserID.ToString()) ? "" : request.UserID.ToString()), "UserID");

            var response = await client.PostAsync($"/api/positions/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<PositionsVm>> GetByUserID(GetPositionsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<PositionsVm>>(
                $"/api/positions/getbyuser?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<PositionsVm> GetById(int id)
        {
            var data = await GetAsync<PositionsVm>($"/api/positions/{id}");

            return data;
        }

        public async Task<PagedResult<PositionsVm>> GetPagings(GetPositionsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<PositionsVm>>(
                $"/api/positions/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&userName={request.UserName}");

            return data;
        }

        public async Task<bool> UpdatePosition(PositionsUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.FacultyID.ToString()) ? "" : request.FacultyID.ToString()), "FacultyID");
            var response = await client.PutAsync($"/api/positions/" + request.ID, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}