using WebApi;

namespace DesktopClient
{
    public partial class Form1 : Form
    {
        ApiClient apiClient;
        public Form1()
        {
            InitializeComponent();
            apiClient = new(@"https://localhost:7124/", new HttpClient());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var allCars = await apiClient.GetAllCarsAsync();
        }
    }
}