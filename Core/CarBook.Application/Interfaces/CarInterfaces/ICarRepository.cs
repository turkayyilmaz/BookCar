using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
	public interface ICarRepository
	{
		List<Car> GetCarListWithBrand();
		List<Car> GetLast5CarsWithBrand();
		int GetCarCount();
	}
}
