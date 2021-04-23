using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Untilities.Constants;
using WebEnterprise.ViewModels.Catalog.SetTimeSystem;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public class SetTimeSystemApiClient : BaseApiClient, ISetTimeSystemApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IConfiguration _configuration;

        public SetTimeSystemApiClient(IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateTime(SetTimeSystemCreateRequest request)
        {
            var sessions = _httpContextAccessor
                           .HttpContext
                           .Session
                           .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.StartDay.ToString()) ? "" : request.StartDay.ToString()), "StartDay");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.EndDay.ToString()) ? "" : request.EndDay.ToString()), "EndDay");
            var response = await client.PostAsync($"/api/settimesystems/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTime(int id)
        {
            var sessions = _httpContextAccessor
                                       .HttpContext
                                       .Session
                                       .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/settimesystems/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<SetTimeSystemVm>> GetAll(SetTimeSystemPagingRequest request)
        {
            var data = await GetAsync<PagedResult<SetTimeSystemVm>>(
                $"/api/settimesystems/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");

            return data;
        }

        public async Task<SetTimeSystemVm> GetById(int id)
        {
            var data = await GetAsync<SetTimeSystemVm>($"/api/settimesystems/{id}");

            return data;
        }

        public async Task<bool> UpdateTime(SetTimeSystemUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient("BackendApi");
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.StartDay.ToString()) ? "" : request.StartDay.ToString()), "StartDay");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.EndDay.ToString()) ? "" : request.EndDay.ToString()), "EndDay");
            var response = await client.PutAsync($"/api/settimesystems/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}