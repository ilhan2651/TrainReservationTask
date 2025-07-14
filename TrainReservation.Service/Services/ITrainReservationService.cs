using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservation.Service.Dtos;

namespace TrainReservation.Service.Services
{
    public interface ITrainReservationService
    {
        ReservationResponseDto CheckReservation(ReservationRequestDto request);
    }
}
