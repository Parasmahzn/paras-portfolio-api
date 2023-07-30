namespace paras_portfolio_api.Services;

public interface IPortfolioMessageService
{
    Task<List<PortfolioMessageDto>> GetPortFolioMessageAsync();
    Task<PortfolioMessageDto?> GetPortFolioMessageAsync(string email);
    Task CreatePortFolioMessageAsync(PortfolioMessageDto portfolioMessage);
}