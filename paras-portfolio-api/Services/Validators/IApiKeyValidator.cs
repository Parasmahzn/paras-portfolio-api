namespace paras_portfolio_api.Services.Validators;

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}
