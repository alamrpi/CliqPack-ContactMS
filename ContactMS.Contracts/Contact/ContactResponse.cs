using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMS.Contracts.Contact
{
   public record ContactResponse(Guid Id, string Name, string Email, string PhoneNumber, string Address);
}
