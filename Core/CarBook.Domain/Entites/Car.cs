using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
	public class Car
	{
		public int CarID { get; set; }
		public int BrandID { get; set; }
		public Brand Brand { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
		public int Km {  get; set; }
		public string Transmission { get; set; } //vites 
        public byte Seat { get; set; } //koltuk
		public byte Luggage { get; set; } //bagaj
        public string Fuel { get; set; }
		public List<CarFeature> CarFeatures { get; set; }
		public List<CarDescription> CarDescriptions { get; set; }
		public List<CarPricing> CarPricings { get; set; }
		public List<RentACar> RentACars { get; set; }
		public List<RentACarProcess> RentACarsProcess { get; set; }
		public List<Reservation> Reservations{ get; set; }

    }
}
