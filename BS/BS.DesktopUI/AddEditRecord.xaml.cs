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
using BS.DesktopUI.Views;

namespace BS.DesktopUI
{
    /// <summary>
    /// Interaction logic for AddEditRecord.xaml
    /// </summary>
    public partial class AddEditRecord : Window
    {
        private int numberOperation = 0;
        public int NumberOperation
        {
            get { return this.numberOperation; }
            set { this.numberOperation = value; }
        }

        private int id;
        private string name;
        private string article;
        private string description;

        public int _Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string _Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string _Article
        {
            get { return this.article; }
            set { this.article = value; }
        }
        public string _Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public AddEditRecord()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            SqlProductRepository sqlProductRepository = new SqlProductRepository();

            if (NumberOperation == 7)
            {
                _Name = txtName.Text;
                _Article = txtArticle.Text;
                _Description = txtDescription.Text;

                Product newProduct = new Product();
                newProduct.Name = _Name;
                newProduct.Article = _Article;
                newProduct.Description = _Description;

                sqlProductRepository.AddRecord(newProduct);
            }
            if (NumberOperation == 4)
            {
                Product editProduct = new Product();
                _Name = txtName.Text;
                _Article = txtArticle.Text;
                _Description = txtDescription.Text;
                editProduct.Id = _Id;
                editProduct.Name = _Name;
                editProduct.Article = _Article;
                editProduct.Description = _Description;

                sqlProductRepository.EditRecord(editProduct);
            }

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
