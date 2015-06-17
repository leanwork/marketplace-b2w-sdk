using Marketplace.B2W.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.B2W.SDK.Services
{
    public interface IProducts
    {
        ProductsResult Get(int offset = 1, int limit = 50);
    }
}
