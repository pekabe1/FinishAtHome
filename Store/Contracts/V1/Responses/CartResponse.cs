using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Contracts.V1.Responses
{
    public class CartResponse
    {
        public Guid CartGuid { get; set; }
        public string UserId { get; set; }

    }
}
