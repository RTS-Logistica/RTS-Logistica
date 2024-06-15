using Application.DTO.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IBatchCardService
    {
        public Task<BatchCardResponse> GetBatchCardById(int id);
    }
}
