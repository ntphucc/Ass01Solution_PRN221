using DataAccess.DataAcces;
using DataAccess.Repository;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();
        private int memberId;
        public Profile(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
            LoadMember();
        }

        private void LoadMember()
        {
            var member = _memberRepository.GetMemberByID(memberId);
            txtId.Text = member.MemberId.ToString();
            txtEmail.Text = member.Email.ToString();
            txtName.Text = member.CompanyName.ToString();
            txtCity.Text = member.City.ToString();
            txtCountry.Text = member.Country.ToString();
            txtPassword.Text = member.Password.ToString();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadMember();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
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
                UpdateProfile updateProfile = new UpdateProfile(newProfile);
                updateProfile.Show();
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Profile");
            }
        }
    }
}
