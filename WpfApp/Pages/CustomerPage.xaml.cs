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
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private ObservableCollection<CustomerModel> cm;
        public CustomerPage()
        {
            InitializeComponent();
            lv_customers.ItemsSource = cm;
        }

        private async void btn_customer_save_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();

            await client.PostAsJsonAsync("https://localhost:7123/api/customers", new CustomerCreateModel
            {
                Name = tb_customer_name.Text,
                Email = tb_customer_email.Text
            });

            tb_customer_name.Text = string.Empty;
            tb_customer_email.Text = string.Empty;
        }

        private void lv_customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cm = (CustomerModel)lv_customers.SelectedItem!;
                tb_customer_name.Text = cm.Name;
                tb_customer_email.Text = cm.Email;
            }
            catch { }

            btn_customer_save.Visibility = Visibility.Collapsed; 
            if (btn_customer_update.Visibility == Visibility.Collapsed)
            {
                btn_customer_update.Visibility = Visibility.Visible;
            }
        }

        private void btn_customer_update_Click(object sender, RoutedEventArgs e)
        {
            var cm = (CustomerModel)lv_customers.SelectedItem;
            var index = cm.IndexOf();

            ccm[index].LastName = tb_Name.Text;
            CustomerCreateModel[index].Email = tb_Email.Text;

            lv_customers.Items.Refresh();
        }
    }
}
