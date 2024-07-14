using CarBook.Application.ViewModels;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingsInterfaces
{
	public interface ICarPricingRepository
	{
		List<CarPricing> GetCarPricingWithCars();
		List<CarPricing> GetCarPricingWithTimePeriod();
		List<CarPricingViewModel> GetCarPricingWithTimePeriod1();
	}
}
