using System.Collections.Generic;

namespace Undersoft.IDP.Admin.BusinessLogic.Dtos.Configuration
{
	public class ClientsDto
	{
		public ClientsDto()
		{
			Clients = new List<ClientDto>();
		}

		public List<ClientDto> Clients { get; set; }

		public int TotalCount { get; set; }		

		public int PageSize { get; set; }
	}
}
