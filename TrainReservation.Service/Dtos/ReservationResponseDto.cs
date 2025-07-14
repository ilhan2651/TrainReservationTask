using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation.Service.Dtos
{
    public class ReservationResponseDto
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimDto> YerlesimAyrinti { get; set; }
    }
}
