using MagicVilla2_Utility;
using MagicVilla2_Web.Models;
using MagicVilla2_Web.Models.Dto;
using MagicVilla2_Web.Services.IServices;

namespace MagicVilla2_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly  IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _clientFactory = httpClient;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/VillaNumberAPI/"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/VillaNumberAPI/" + id
            });
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/VillaNumberAPI"
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/VillaNumberAPI/" + dto.VillaNo
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaUrl + "/api/VillaNumberAPI/" + id
            });
        }
    }
}
