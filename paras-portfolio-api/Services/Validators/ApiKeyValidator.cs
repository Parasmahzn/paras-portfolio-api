using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace paras_portfolio_api.Services.Validators;

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IConfiguration _configuration;

    public ApiKeyValidator(IConfiguration configuration) => this._configuration = configuration;
    public bool IsValid(string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey)) return false;

        var apiKeyFromSecrets = _configuration.GetValue<string>("ApiKey");
        // Convert the apiKey and apiKeyFromSecrets to byte arrays
        var apiKeySpan = MemoryMarshal.Cast<char, byte>(apiKey.AsSpan());
        var apiKeyFromSecretsSpan = MemoryMarshal.Cast<char, byte>(apiKeyFromSecrets.AsSpan());
        // Compare the byte arrays using CryptographicOperations.FixedTimeEquals
        // This method ensures a constant time comparison to prevent timing attacks.
        return CryptographicOperations.FixedTimeEquals(apiKeySpan, apiKeyFromSecretsSpan);
    }
}