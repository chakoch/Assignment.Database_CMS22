using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            PoplateProductCustomers().ConfigureAwait(false);
        }

        public async Task PoplateProductCustomers()
        {
            var collection = new ObservableCollection<KeyValuePair<string, int>>();
            using var client = new HttpClient();

            foreach (var cutomer in await client.GetFromJsonAsync<IEnumerable<CustomerModel>>("https://localhost:7123/api/customerview"))
                collection.Add(new KeyValuePair<string, int>(cutomer.Name, cutomer.Id));

            cb_product_customer.ItemsSource = collection;
        }

        private async void btn_product_save_Click(object sender, RoutedEventArgs e)
        {
            var customer = (KeyValuePair<string, int>)cb_product_customer.SelectedItem;
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7123/api/products", new ProductCreateModel 
            { 
                Name = tb_product_name.Text, 
                Description = tb_product_description.Text, 
                Price = decimal.Parse(tb_product_price.Text), 
                CustomerId = customer.Value 
            });

            tb_product_name.Text = string.Empty;
            tb_product_description.Text = string.Empty;
            tb_product_price.Text = string.Empty;
            cb_product_customer.SelectedIndex = -1;
        }

    }
}
