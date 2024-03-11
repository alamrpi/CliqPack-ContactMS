using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMS.Utility.Errors
{
    public static partial class Errors
    {
        public static class Common
        {
            public static Error InternalServerError = Error.Failure(code: "Interserver Error",
                description: "Something went wrong!");

            public static Error NotFound = Error.NotFound(code: "Not found",
               description: "Data not found!");
        }
    }
}
