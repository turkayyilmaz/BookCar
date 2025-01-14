﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
	public class CreateCarCommand
	{
		public int BrandID { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public string BigImageUrl { get; set; }
		public int Km { get; set; }
		public string Transmission { get; set; } //vites 
		public byte Seat { get; set; } //koltuk
		public byte Luggage { get; set; } //bagaj
		public string Fuel { get; set; }
	}
}
