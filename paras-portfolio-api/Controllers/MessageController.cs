﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using paras_portfolio_api.AuthFilters;
using paras_portfolio_api.Services;
using System.ComponentModel.DataAnnotations;

namespace paras_portfolio_api.Controllers;

[ApiKey]
[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IPortfolioMessageService _portfolioMessageService;

    public MessageController(IPortfolioMessageService portfolioMessageService) =>
        _portfolioMessageService = portfolioMessageService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PortfolioMessage>))]
    public async Task<IActionResult> GetMessages()
    {
        try
        {
            var messages = await _portfolioMessageService.GetPortFolioMessageAsync();
            if (messages == null || messages.Count <= 0)
                return NotFound("No messages found");

            var apiResponse = messages.Adapt<List<PortfolioMessage>>();
            return Ok(apiResponse);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpGet("{emailAddress?}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioMessage))]
    public async Task<IActionResult> GetMessage([EmailAddress] string emailAddress)
    {
        try
        {
            var messages = await _portfolioMessageService.GetPortFolioMessageAsync(emailAddress);
            if (messages == null)
                return NotFound("No messages found for the provided email address.");

            var apiResp = messages.Adapt<PortfolioMessage>();

            return Ok(apiResp);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateMessages([FromBody] PortfolioMessage message)
    {
        try
        {
            var apiRequest = message.Adapt<PortfolioMessageDto>();

            await _portfolioMessageService.CreatePortFolioMessageAsync(apiRequest);
            return StatusCode(StatusCodes.Status201Created, "Resource Created Successfully");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
        }
    }
}