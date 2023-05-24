using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            ManageMembers manageMembers = new ManageMembers();
            manageMembers.Show();
        }

        private void btnFlower_Click(object sender, RoutedEventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            ManageOrder manageOrder = new ManageOrder();
            manageOrder.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.Show();
        }
    }
}
