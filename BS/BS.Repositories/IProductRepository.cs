using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Entities;

namespace BS.Repositories
{
    public interface IProductRepository
    {
        List<Product> SelectAll();
        int CountRecords();
    }
}
