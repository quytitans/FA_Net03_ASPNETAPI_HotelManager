using MagicVilla2_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using MagicVilla2_Web.Models.Dto;
using MagicVilla2_Web.Services.IServices;
using Newtonsoft.Json;

namespace MagicVilla2_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public HomeController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDto> list = new();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}