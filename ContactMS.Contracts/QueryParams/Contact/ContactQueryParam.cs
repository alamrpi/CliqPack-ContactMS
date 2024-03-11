using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMS.Contracts.QueryParams.Contact
{
    public class ContactQueryParam : QueryParams
    {
        public string? SearchTerm { get; set; }
    }
}
