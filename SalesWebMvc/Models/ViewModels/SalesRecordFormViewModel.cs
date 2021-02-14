using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SalesRecordFormViewModel
    {
        public ICollection<Seller> Sellers { get; set; }
        public IEnumerable<SaleStatus> SaleStatus { get; set; }
        public SalesRecord SalesRecord { get; set; }
        public Seller Seller { get; set; }
    }
}
