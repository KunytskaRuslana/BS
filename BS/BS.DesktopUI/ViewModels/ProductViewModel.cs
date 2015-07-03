using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Entities;
using BS.Repositories;

namespace BS.DesktopUI.ViewModels
{
    public class ProductViewModel
    {
        #region Queries

        //string querySelect = "SELECT [Id],[Name],[Article],[ProducerId],[Description],[ProductGroupId] FROM [dbo].[tblProduct]";

        #endregion

        #region Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductViewModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #endregion

        #region Binding Properties

        public List<Product> Products
        {
            get
            {
                return this._productRepository.SelectAll();
            }
        }

        #endregion
    }
}
