using BS.Entities;
using BS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DesktopUI.ViewModels
{
    public class ProductViewModel
    {
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
