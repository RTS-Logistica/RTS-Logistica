using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class BatchCardQuery : IBatchCardQuery 
    {
        private readonly AppDbContext _context;

        public BatchCardQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BatchCard> GetBatchCardById(int id)
        {
            var result = await _context.BatchCard.Where(f => f.BatchId == id)
                                                 .Include(f => f.UserDataCollection)
                                                 .ThenInclude(u => u.AddressNav)
                                                 .Include(f => f.BankFormatNav)
                                                 .FirstOrDefaultAsync();
            return result!;
        }
    }
}
