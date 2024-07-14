using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
	public class CarFeature
	{
		//car sınıfındaki bir aracın feature sınıfndaki hangi özellikleri true veya fasle aldığını halldeceğiz
		public int CarFeatureID { get; set; }
		public int CarID { get; set; }
		public Car Car { get; set; }
		public int FeatureID { get; set; }
		public Feature Feature { get; set; }
		public bool Available { get; set; } //bu özellik var mı yok mu


	}
}
