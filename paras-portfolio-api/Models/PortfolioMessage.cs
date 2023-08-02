using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace paras_portfolio_api.Models;

public class PortfolioMessage
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Email address is not valid")]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Message { get; set; } = string.Empty;
}

public class PortfolioMessageDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}