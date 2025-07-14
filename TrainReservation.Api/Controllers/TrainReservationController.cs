using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainReservation.Service.Dtos;
using TrainReservation.Service.Services;

namespace TrainReservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainReservationController(ITrainReservationService reservationService) : ControllerBase
    {
        [HttpPost]
        public IActionResult PostCheckReservation([FromBody] ReservationRequestDto request)
        {
            if (request == null ||
                request.Tren == null ||
                 request.Tren.Vagonlar == null ||
                  !request.Tren.Vagonlar.Any() ||
                   request.RezervasyonYapilacakKisiSayisi <= 0)
            {
                return BadRequest("Geçersiz rezervasyon isteği.");
            }
            var result = reservationService.CheckReservation(request);
            return Ok(result);

        }
    }
}
