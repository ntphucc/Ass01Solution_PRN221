using DataAccess.Repository;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ManageMembers.xaml
    /// </summary>
    public partial class ManageMembers : Window
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();

        public ManageMembers()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            lvCustomers.ItemsSource = _memberRepository.GetMembers();
            message.Text = "";
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomer();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
                
        }
    }
}
