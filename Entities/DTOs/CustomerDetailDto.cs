using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public string CompanyName { get; set; }
        public string UserName { get; set; }
    }
}