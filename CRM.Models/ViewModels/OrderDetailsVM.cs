using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models.ViewModels
{
    public class OrderDetailsVM
    {
        public Order Order { get; set; }
        public List<Detail> Detail { get; set; }
    }
}
