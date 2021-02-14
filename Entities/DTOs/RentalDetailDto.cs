using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ModelName { get; set; }
        public string CompanyName { get; set; }
    }
}