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

        private Customer customer;
        
        public UsersForm()
        {
            InitializeComponent();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            ApiClient apiClient = new("", new HttpClient());
            var res = await apiClient.UserAsync(@"");
            if (res != null)
                customer = res;
        }
    }
}
