using OrderUpdate.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage respons = client.GetAsync("https://localhost:7090/api/Order/all").Result;
            if (respons.IsSuccessStatusCode )
            {
               var orders = respons.Content.ReadAsAsync<List<OrderDTO>>().Result;
               // List<suborder> suborders = respons1.Content.ReadAsAsync<List<suborder>>().Result;

                // Create two separate BindingList instances
                //var bindingListOrders = new BindingList<OrderDTO>(orders);
                // BindingList<suborder> bindingListSuborders = new BindingList<suborder>(suborders);

                // Bind each BindingList to its own DataGridView
                ultraGrid1.DataSource = orders;
               // dataGridView2.DataSource = bindingListSuborders;
            }
        }
    }
}
