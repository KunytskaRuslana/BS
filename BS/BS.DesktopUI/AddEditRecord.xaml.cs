using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BS.Entities;
using BS.Repositories.Sql;

namespace BS.DesktopUI
{
    /// <summary>
    /// Interaction logic for AddEditRecord.xaml
    /// </summary>
    public partial class AddEditRecord : Window
    {
        public AddEditRecord()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string article = txtArticle.Text;
            string description = txtDescription.Text;

            Product newProduct = new Product();
            newProduct.Name = name;
            newProduct.Article = article;
            newProduct.Description = description;

            SqlProductRepository sqlProductRepository = new SqlProductRepository();
            sqlProductRepository.AddRecord(newProduct);

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
