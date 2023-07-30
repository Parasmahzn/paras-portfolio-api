using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace paras_portfolio_api.Services;

public class PortfolioMessageService : IPortfolioMessageService
{
    private readonly IMongoCollection<PortfolioMessageDto> _porfolioMessagesCollection;
    public PortfolioMessageService(IOptions<PortfolioDatabaseSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        _porfolioMessagesCollection = mongoClient
            .GetDatabase(options.Value.DatabaseName)
            .GetCollection<PortfolioMessageDto>(options.Value.CollectionName);
    }

    public async Task CreatePortFolioMessageAsync(PortfolioMessageDto portfolioMessage) =>
        await _porfolioMessagesCollection.InsertOneAsync(portfolioMessage);

    public async Task<List<PortfolioMessageDto>> GetPortFolioMessageAsync() =>
        await _porfolioMessagesCollection.Find(_ => true).ToListAsync();

    public async Task<PortfolioMessageDto?> GetPortFolioMessageAsync(string email) =>
        await _porfolioMessagesCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
}