using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TagCloudsDto
{
	public class GetByBlodIdTagCloudDto
	{
		public int TagCloudId { get; set; }
		public string Title { get; set; }
		public int BlogId { get; set; }
	}
}
