using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.UseCases.Auctions.GetCurrent;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly TheAuctionDbContext _dbContext;

    public AuctionRepository(TheAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext.Auctions.Include(auction => auction.Items)
       .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
