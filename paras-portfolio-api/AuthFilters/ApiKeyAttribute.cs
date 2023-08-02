using Microsoft.AspNetCore.Mvc;

namespace paras_portfolio_api.AuthFilters;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter)) { }
}