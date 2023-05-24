using DataAccess.DataAcces;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();
        private Member Member;
        public UpdateProfile(Member member)
        {
            InitializeComponent();
            Member = member;
        }

        private void UpdateProfile_Load(object sender, RoutedEventArgs e)
        {
            txtId.Text = Member.MemberId.ToString();
            txtEmail.Text = Member.Email.ToString();
            txtName.Text = Member.CompanyName.ToString();
            txtCity.Text = Member.City.ToString();
            txtCountry.Text = Member.Country.ToString();
            txtPassword.Text = Member.Password.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProfile = new Member
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                _memberRepository.UpdateMember(newProfile);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Profile");
            }
        }
    }
}
