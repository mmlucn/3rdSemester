using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi;


namespace DesktopClient
{
    public partial class UsersForm : Form
    {

        private Customer _customer;
        private ApiClient _apiClient;

        public UsersForm()
        {
            InitializeComponent();
            _apiClient = new("", new HttpClient());
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            var res = await _apiClient.UserAsync(label1.Text);
            if (res != null && res.Id > 0)
            {
                _customer = res;

                firstNameTxt.Text = _customer.Firstname;
                lastNameTxt.Text = _customer.Lastname;
                addressTxt.Text = _customer.Address;
                emailTxt.Text = _customer.EMail;
                phoneTxt.Text = _customer.PhoneNumber;
                birthdayPicker.Value = _customer.DateOfBirth;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
