using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ДемОчка.Context;
using ДемОчка.Models;

namespace ДемОчка
{
    public partial class Form1 : Form
    {
        private AZSContext context;
        public Form1()
        {
            InitializeComponent();
            context = new AZSContext();
            Text = ConfigurationManager.AppSettings.Get("loh");
            Fill();
        }

        private async void Fill()
        {
            label1.Text = "";
            var stations = await context.Stations.ToListAsync();

            foreach (Station station in stations)
                label1.Text += station.Address.ToString() + ',';

            dataGridView1.DataSource = stations;
            /*Gas newGas = new Gas()
            {
                AmountOfFuel = 69,
                Price = 1,
                GasTypeId = 1,
                StationId = 1
            };
            context.Gas.Add(newGas);
            await context.SaveChangesAsytnc();*/
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Station station = await context.Stations.FirstAsync(s => s.IdStation == (int)dataGridView1.SelectedRows[0].Cells[0].Value);
            station.Address = textBox1.Text;
            context.Stations.Update(station);
            await context.SaveChangesAsync();
            Fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}