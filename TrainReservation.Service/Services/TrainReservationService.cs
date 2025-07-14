using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservation.Service.Dtos;

namespace TrainReservation.Service.Services
{
    public class TrainReservationService : ITrainReservationService
    {
        public ReservationResponseDto CheckReservation(ReservationRequestDto request)
        {
            int kisiSayisi= request.RezervasyonYapilacakKisiSayisi;
            bool farkliVagon=request.KisilerFarkliVagonlaraYerlestirilebilir;

            var yerlesimListesi = new List<YerlesimDto>();

            if (farkliVagon)
            {
                int kalan = kisiSayisi;
                foreach(var vagon in request.Tren.Vagonlar)
                {
                    int maxKapasite= (int)(vagon.Kapasite*0.7);
                    int bosKoltuk=maxKapasite - vagon.DoluKoltukAdet;

                    if (bosKoltuk <= 0)
                        continue;

                    int yerleşenKisiSayisi= Math.Min(bosKoltuk, kalan);
                    if (yerleşenKisiSayisi > 0)
                        yerlesimListesi.Add(new YerlesimDto
                        {
                            VagonAdi = vagon.Ad,
                            KisiSayisi = yerleşenKisiSayisi
                        });
                    kalan -= yerleşenKisiSayisi;
                    if (kalan==0)
                        break;
                   
                }
                if (kalan > 0)
                {
                    return new ReservationResponseDto
                    {
                        RezervasyonYapilabilir = false,
                        YerlesimAyrinti = new List<YerlesimDto>()
                    };
                }
                else
                {
                    return new ReservationResponseDto
                    {
                        RezervasyonYapilabilir = true,
                        YerlesimAyrinti = yerlesimListesi,
                    };
                }
            }
            else
            {
                foreach(var vagon in request.Tren.Vagonlar)
                {
                    int maxKapasite = (int)(vagon.Kapasite * 0.7);
                    int bosKoltuk = maxKapasite - vagon.DoluKoltukAdet;
                    if (bosKoltuk >= kisiSayisi)
                    {
                        yerlesimListesi.Add(new YerlesimDto
                        {
                            VagonAdi = vagon.Ad,
                            KisiSayisi = kisiSayisi
                        });
                        return new ReservationResponseDto
                        {
                            RezervasyonYapilabilir = true,
                            YerlesimAyrinti = yerlesimListesi,
                        };
                    }
                   
                }
                return new ReservationResponseDto
                {
                    RezervasyonYapilabilir = false,
                    YerlesimAyrinti = new List<YerlesimDto>()
                };
            }
        }
    }
}
