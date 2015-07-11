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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BS.Repositories.Sql;
using BS.Entities;

namespace BS.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();

            SqlProductRepository colRecord = new SqlProductRepository();
            txtColRecord.Text = Convert.ToString(colRecord.CountRecords());
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            AddEditRecord addEditRecord = new AddEditRecord();
            addEditRecord.NumberOperation = 7;
            addEditRecord.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int numRecord = ListRecord.SelectedIndex+1;
            if (numRecord == 0)
            {
                MessageBox.Show("Виберіть рядок для редагування");
            }
            else
            {
                SqlProductRepository idRecord = new SqlProductRepository();
                int _idRecord = idRecord.GetId(numRecord);
                Product product = new Product();
                product = idRecord.GetRowById(_idRecord);
                AddEditRecord addEditRecord = new AddEditRecord();
                addEditRecord.NumberOperation = 4;
                addEditRecord._Id = product.Id;
                addEditRecord.txtName.Text = product.Name;
                addEditRecord.txtArticle.Text = product.Article;
                addEditRecord.txtDescription.Text = product.Description;
                addEditRecord.Show();
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            int numRecord = ListRecord.SelectedIndex + 1;
            if (numRecord == 0)
            {
                MessageBox.Show("Виберіть рядок для операції 'По зразку'");
            }
            else
            {
                SqlProductRepository idRecord = new SqlProductRepository();
                int _idRecord = idRecord.GetId(numRecord);
                Product product = new Product();
                product = idRecord.GetRowById(_idRecord);
                AddEditRecord addEditRecord = new AddEditRecord();
                addEditRecord.NumberOperation = 5;
                addEditRecord._Id = product.Id;
                addEditRecord.txtName.Text = product.Name;
                addEditRecord.txtArticle.Text = product.Article;
                addEditRecord.txtDescription.Text = product.Description;
                addEditRecord.Show();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int numRecord = ListRecord.SelectedIndex + 1;
            if (numRecord == 0)
            {
                MessageBox.Show("Виберіть рядок для операції 'Видалення'");
            }
            else
            {
                SqlProductRepository idRecord = new SqlProductRepository();
                int _idRecord = idRecord.GetId(numRecord);
                Product product = new Product();
                product = idRecord.GetRowById(_idRecord);
                AddEditRecord addEditRecord = new AddEditRecord();
                string __name = product.Name;
                string __article = product.Article;
                string __description = product.Description;
                string message = string.Format("Ви дійсно бажаєте видалити запис? \nНазва: {0} \nАртикул: {1} \nОпис: {2}", __name, __article, __description);
                if (MessageBox.Show(message, "Видалення запису", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    idRecord.DeleteRecord(_idRecord);
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SqlProductRepository listProduct = new SqlProductRepository();
            List<Product> list = new List<Product>();
            list = listProduct.SelectAll();
            this.ListRecord.ItemsSource = list;
            txtColRecord.Text = listProduct.CountRecords().ToString();
        }

        private void ListRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNumRecord.Text = (ListRecord.SelectedIndex + 1).ToString();
        }
    }
}
