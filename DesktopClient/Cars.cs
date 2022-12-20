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
    public partial class Cars : Form
    {
        ApiClient apiClient;
        Car selectedCar;
        public Cars()
        {
            InitializeComponent();
            apiClient = new("", new HttpClient());
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            var customer = await apiClient.UserAsync(searchBtn.Text);
            if (customer != null)
            {
                var allCars = await apiClient.GetAllUsersCarsAsync(customer.Id);
                if (allCars.Count() > 0)
                {
                    foreach (var car in allCars)
                    {
                        listView1.Items.Add(new ListViewItem($"{car.Brand} {car.Model}")
                        {
                            Tag = car
                        });
                    }
                }
                else
                    MessageBox.Show("No cars found");
            }
        }


        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Tag is Car)
            {
                selectedCar = (Car)e.Item.Tag;
                
                brandTxt.Text= selectedCar.Brand;
                modelTxt.Text = selectedCar.Model;
                descTxt.Text = selectedCar.Description;
                yearTxt.Text = selectedCar.Year.ToString();
                milageTxt.Text = selectedCar.Mileage.ToString();
                carTypeBox.Text = selectedCar.Type.ToString();
                fuelTypeBox.Text = selectedCar.FuelType.ToString();
                doorsTxt.Text = selectedCar.Doors.ToString();
                fuelConTxt.Text = selectedCar.FuelConsumption.ToString();
                elecConTxt.Text = selectedCar.ElectricityConsumption.ToString();
                hkTxt.Text = selectedCar.Hk.ToString();
                gearTypeBox.Text = selectedCar.GearType.ToString();
                regTxt.Text = selectedCar.RegNumber;
                colorTxt.Text = selectedCar.Color;
                
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            selectedCar.Brand = brandTxt.Text;
            selectedCar.Model = modelTxt.Text;
            selectedCar.Description = descTxt.Text;
            selectedCar.Year = Convert.ToInt32(yearTxt.Text);
            selectedCar.Mileage = Convert.ToInt32(milageTxt.Text);
            selectedCar.Type = Enum.Parse<CarType>(carTypeBox.Text);
            selectedCar.FuelType = Enum.Parse<FuelType>(fuelTypeBox.Text);
            selectedCar.Doors = Convert.ToInt32(doorsTxt.Text);
            selectedCar.FuelConsumption = Convert.ToDouble(fuelConTxt.Text);
            selectedCar.ElectricityConsumption = Convert.ToDouble(elecConTxt.Text);
            selectedCar.Hk = Convert.ToInt32(hkTxt.Text);
            selectedCar.GearType = Enum.Parse<GearType>(gearTypeBox.Text);
            selectedCar.RegNumber = regTxt.Text;
            selectedCar.Color = colorTxt.Text;

            await apiClient.UpdateCarAsync(selectedCar);
        }
    }
}
