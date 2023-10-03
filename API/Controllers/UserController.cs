using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
        private readonly IUserRespository _userRepository;
        private readonly IMapper _mapper;

    public UsersController(IUserRespository userRepository, IMapper mapper)
    {
            _userRepository = userRepository;
            _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetUserAsync();
        var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(usersToReturn);
    }

    [HttpGet("{username}")] //api/users/3
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username);
        return _mapper.Map<MemberDto>(user);

    }
}