using AutoMapper;
using lab_03.BL.Exceptions;
using lab_03.BL.Models;
using lab_03.BL.Services;
using lab_03.Server.DTO;
using Microsoft.AspNetCore.Mvc;

namespace lab_03.Server.Controllers
{
    [ApiController]
    [Route("api/v1/leagues")]
    public class LeagueController : ControllerBase
    {
        private ILogger<LeagueController> logger;
        private IMapper mapper;
        private LeagueService leagueService;
        public LeagueController(ILogger<LeagueController> logger, IMapper mapper, LeagueService leagueService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.leagueService = leagueService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] RawLeagueDto rawleagueDto)
        {
            try
            {
                leagueService.InsertLeague(mapper.Map<RawLeagueDto, League>(rawleagueDto));
                return Ok();
            }
            catch (LeagueExistException ex)
            {
                logger.LogError("league have been exists");
                return Conflict();
            }
            catch (Exception ex)
            {
                logger.LogError("server error");
                throw;
            }
        }
        [HttpGet]
        public IActionResult Get([FromQuery] int idUser)
        {
            var leagues = leagueService.GetByUser(idUser);
            return Ok(leagues.Select(l => mapper.Map<League, LeagueDto>(l)).ToList());
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Update([FromBody] LeagueDto leagueDto)
        {
            try
            {
                leagueService.ModifyLeague(mapper.Map<LeagueDto, League>(leagueDto));
                return Ok();
            }
            catch (LeagueNotFoundException ex)
            {
                logger.LogError("server error");
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError("server error");
                throw;
            }
        }
        [HttpGet("idleague")]
        public IActionResult GetLeague(int id)
        {
            try
            {
                var league = leagueService.GetLeague(id);
                return Ok(league);
            }
            catch (LeagueNotFoundException ex)
            {
                logger.LogError("league not exists");
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError("server error");
                throw;
            }
        }
        [HttpDelete("idleague")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Detele(int id)
        {
            try
            {
                leagueService.DeleteLeague(id);
                return Ok();
            }
            catch (LeagueNotFoundException ex)
            {
                logger.LogError("league not found");
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError("server error");
                throw;
            }
        }

    }
}
