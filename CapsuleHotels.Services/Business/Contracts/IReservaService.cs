using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Dtos.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business.Contracts
{
    public interface IReservaService
    {
        Task<ReservaDto> GetReservaAsync(int id);
        Task<IEnumerable<ReservaDto>> GetReservasRangoAsync(ReservasSearchResourceParameters reservasSearchResourceParameters);
        Task<ReservaDto> CreateReservaAsync(ReservaForCreationDto reservaForCreationDt);
        Task<bool> DeleteReservaAsync(int id);
    }
}
