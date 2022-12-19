using WebApi;

namespace DesktopClient
{
    public partial class Main : Form
    {
        ApiClient apiClient;
        public Main()
        {
            InitializeComponent();
            apiClient = new(@"https://localhost:7124/", new HttpClient());
        }

        private void carsBtn_click(object sender, EventArgs e)
        {
            Cars cars = new Cars();
            cars.Show();
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            UsersForm users = new UsersForm();
            users.Show();
        }
    }
}