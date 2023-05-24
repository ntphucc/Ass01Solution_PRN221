using DataAccess.DataAcces;
using DataAccess.Repository;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : Window
    {
        private IMemberRepository _memberRepository;
        private bool InsertOrUpdate;
        private Member Member;
        public CustomerDetails(IMemberRepository memberRepository, bool insertOrUpdate, Member member, string title)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            InsertOrUpdate = insertOrUpdate;
            Member = member;
            Title = title;
        }

        private void CustomerDetailsWindow_Load(object sender, RoutedEventArgs e)
        {
            txtId.IsReadOnly = InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtId.Text = Member.MemberId.ToString();
                txtEmail.Text = Member.Email.ToString();
                txtName.Text = Member.CompanyName.ToString();
                txtCity.Text = Member.City.ToString();
                txtCountry.Text = Member.Country.ToString();
                txtPassword.Text = Member.Password.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var member = new Member
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                if (InsertOrUpdate == false)
                {
                    _memberRepository.InsertMember(member);
                }
                else
                {
                    _memberRepository.UpdateMember(member);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a member" : "Update a member");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
