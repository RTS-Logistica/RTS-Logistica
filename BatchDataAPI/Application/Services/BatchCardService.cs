using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.Services
{
    public class BatchCardService : IBatchCardService
    {
        private readonly IBatchCardQuery _query;

        public BatchCardService(IBatchCardQuery query)
        {
            _query = query;
        }
        public async Task<BatchCardResponse> GetBatchCardById(int id)
        {
            var result = await _query.GetBatchCardById(id);
            return new BatchCardResponse(result, result.UserDataCollection);
        }
    }
}
