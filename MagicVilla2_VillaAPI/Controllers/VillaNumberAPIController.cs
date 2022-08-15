using System.Net;
using AutoMapper;
using MagicVilla2_VillaAPI.Data;
using MagicVilla2_VillaAPI.Models;
using MagicVilla2_VillaAPI.Models.Dto;
using MagicVilla2_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla2_VillaAPI.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _dbVilaNumber;
        private readonly IVillaRepository _dbVila;
        private readonly IMapper _mapper;

        public VillaNumberAPIController(IVillaNumberRepository villaNumberRepository, IMapper mapper, IVillaRepository dbVila)
        {
            _dbVilaNumber = villaNumberRepository;
            _mapper = mapper;
            this._response = new();
            _dbVila = dbVila;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillasNumber()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumberList = await _dbVilaNumber.GetAllAsync(includeProperties:"Villa");
                _response.Result = _mapper.Map<List<VillaNumberDto>>(villaNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villaNumber = await _dbVilaNumber.GetAsync(s => s.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto createNumberDto)
        {
            try
            {
                if (await _dbVilaNumber.GetAsync(u => u.VillaNo == createNumberDto.VillaNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "VillaNumber already exists !");
                    return BadRequest(ModelState);
                }

                if (await _dbVila.GetAsync(u => u.Id == createNumberDto.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "VillaID Invalid");
                    return BadRequest(ModelState);
                }

                if (createNumberDto == null)
                {
                    return BadRequest(createNumberDto);
                }

                VillaNumber villaNumber = _mapper.Map<VillaNumber>(createNumberDto);

                await _dbVilaNumber.CreateAsync(villaNumber);
                _response.Result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaNumber", new { id = villaNumber.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var villaNumber = await _dbVilaNumber.GetAsync(x => x.VillaNo == id);
                if (villaNumber == null)
                {
                    return NotFound();
                }

                await _dbVilaNumber.RemoveAsync(villaNumber);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDto updateNumberDto)
        {
            try
            {
                if (updateNumberDto == null || id != updateNumberDto.VillaNo)
                {
                    return BadRequest();
                }

                if (await _dbVila.GetAsync(u => u.Id == updateNumberDto.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "VillaID Invalid");
                    return BadRequest(ModelState);
                }

                VillaNumber model = _mapper.Map<VillaNumber>(updateNumberDto);

                await _dbVilaNumber.UpdateAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
