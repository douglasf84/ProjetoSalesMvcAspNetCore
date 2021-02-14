using SalesWebMvc.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(100.0, 5000000.0, ErrorMessage = "{0} must be from {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required (ErrorMessage = "{0} requered")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "{0} requered")]
        public SaleStatus Status { get; set; }

        public int StatusId { get; set; }

        public Seller Seller { get; set; }

        public int SellerId { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
