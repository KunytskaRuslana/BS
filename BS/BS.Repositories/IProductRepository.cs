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
        Product AddRecord(Product product);
        void EditRecord(Product product);
        void DeleteRecord(int prodId);
        int CountRecords();
        int GetId(int numRecord);
        Product GetRowById(int id);
    }
}
