﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using paras_portfolio_api.Services.Validators;

namespace paras_portfolio_api.AuthFilters;

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private const string ApiKeyHeaderName = "X-API-Key";
    private readonly IApiKeyValidator _apiKeyValidator;

    public ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator) => _apiKeyValidator = apiKeyValidator;
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];
        if (!_apiKeyValidator.IsValid(apiKey))
            context.Result = new UnauthorizedResult();
    }
}