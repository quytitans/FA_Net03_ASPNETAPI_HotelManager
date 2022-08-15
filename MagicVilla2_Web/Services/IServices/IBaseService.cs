using MagicVilla2_Web.Models;

namespace MagicVilla2_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest aPIRequest);
    }
}
