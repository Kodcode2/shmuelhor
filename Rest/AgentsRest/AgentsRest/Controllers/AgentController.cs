﻿using AgentsRest.Dto;
using AgentsRest.Models;
using AgentsRest.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentsRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController(IAgentService agentService) : ControllerBase
    {
        [HttpPost("CreateAgent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] AgentDto agentDto)
        {
            try
            {
                await agentService.CreateNewAgentAsync(agentDto);
                return Created("new user", agentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }



        [HttpGet("AllAgent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  async Task<ActionResult> GetAllAgent() =>
            Ok(await agentService.GetAllAgentAsync());
    }
}
