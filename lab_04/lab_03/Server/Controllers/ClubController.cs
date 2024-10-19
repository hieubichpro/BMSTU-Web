using AutoMapper;
using lab_03.BL.Exceptions;
using lab_03.BL.Models;
using lab_03.BL.Services;
using lab_03.DA.Entities;
using lab_03.Server.DTO;
using Microsoft.AspNetCore.Mvc;

namespace lab_03.Server.Controllers
{
    [ApiController]
    [Route("api/v1/clubs")]
    public class ClubController : ControllerBase
    {
        private ILogger<ClubController> _logger;
        private IMapper _mapper;
        private ClubService _clubService;
        public ClubController(ILogger<ClubController> logger, IMapper mapper, ClubService clubService)
        {
            _logger = logger;
            _mapper = mapper;
            _clubService = clubService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] RawClubDto rawclubDto)
        {
            try
            {
                _clubService.InsertClub(_mapper.Map<RawClubDto, Club>(rawclubDto));
                return Ok();
            }
            catch (ClubExistException ex)
            {
                _logger.LogError("club exists");
                return Conflict();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            var clubs = _clubService.GetAll();
            return Ok(clubs.Select(c => _mapper.Map<Club, ClubDto>(c)).ToList());
        }
        [HttpDelete("idleague")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete([FromQuery]int id)
        {
            try
            {
                _clubService.DeleteClub(id);
                return Ok();
            }
            catch (ClubNotFoundException ex)
            {
                _logger.LogError("club not exists");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Update(ClubDto clubDto)
        {
            try
            {
                _clubService.ModifyClub(_mapper.Map<ClubDto, Club>(clubDto));
                return Ok();
            }
            catch (ClubNotFoundException ex)
            {
                _logger.LogError("club not found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpGet("idclub")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                var club = _clubService.GetById(id);
                return Ok(club);
            }
            catch (ClubNotFoundException ex)
            {
                _logger.LogError("club not found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
    }
}
