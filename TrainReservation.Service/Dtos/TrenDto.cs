using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation.Service.Dtos
{
    public class TrainDto
    {
        public string Ad { get; set; }=string.Empty;
        public List<VagonDto> Vagonlar { get; set; }
    }

}
