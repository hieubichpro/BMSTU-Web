﻿using AutoMapper;
using lab_03.BL.Exceptions;
using lab_03.BL.Models;
using lab_03.BL.Services;
using lab_03.Server.DTO;
using Microsoft.AspNetCore.Mvc;

namespace lab_03.Server.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private IMapper _mapper;
        private UserService _userService;
        public UserController(IMapper mapper, ILogger<UserController> logger, UserService userService)
        {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }
        [HttpGet("sign-in")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult SignIn([FromQuery] RawUserDto rawUser)
        {
            try
            {
                var user = _userService.SignIn(_mapper.Map<RawUserDto, User>(rawUser));
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError("user not found");
                return NotFound();
            }
            catch (UserNotMatchPasswordException ex)
            {
                _logger.LogError("password invalid");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetById(int userId)
        {
            try
            {
                var user = _userService.GetById(userId);
                return Ok(user);
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError("user not found");
                return NotFound();
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
            try
            {
                var users = _userService.GetAll();
                var result = users.Select(u => _mapper.Map<User, UserDto>(u)).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult SignUp([FromBody] UserDto userDto)
        {
            try
            {
                _userService.SignUp(_mapper.Map<UserDto, User>(userDto));
                return Ok();
            }
            catch (UserExistException ex)
            {
                _logger.LogError("user have been exists");
                return Conflict();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Update([FromBody] UserDto userDto)
        {
            try
            {
                _userService.UpdateUser(_mapper.Map<UserDto, User>(userDto));
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError("user not exists");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError("user not exists");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("server error");
                throw;
            }
        }
        [HttpPatch("change-password")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult ChangePassword([FromQuery]RawUserDto userDto)
        {
            try
            {
                _userService.ChangePassword(_mapper.Map<RawUserDto, User>(userDto));
                return Ok();
            }
            catch (UserNotFoundException ex)
            {
                _logger.LogError("user not found");
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
