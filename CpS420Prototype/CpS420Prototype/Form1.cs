using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CpS420Prototype
{
    public partial class Prototype : Form
    {
        public Prototype()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter myTracer = File.AppendText("trace.log");
            myTracer.AutoFlush = true;
            myTracer.WriteLine("First Name: " + this.firstName.Text);
            
            DataRow dr = this.anonDataSet.anon.NewRow();
            dr["firstName"] = this.firstName.Text;
            dr["lastName"] = this.lastName.Text;
            dr["emailAddress"] = this.email.Text;
            dr["phoneNumber"] = this.phone.Text;
            dr["IDNumber"] = this.id.Text;
            dr["accountNumber"] = this.acc.Text;
            dr["routingNumber"] = this.route.Text;
            dr["amount"] = this.amnt.Text;
            dr["checkDate"] = this.date.Text;
            dr["checkNumber"] = this.check.Text;
            dr["streetAddress"] = this.street.Text;
            dr["city"] = this.city.Text;
            dr["State"] = this.st.Text;
            dr["zip"] = this.zip.Text;
            dr["storeNumber"] = this.store.Text;
            dr["cashierNumber"] = this.cashier.Text;
            this.anonDataSet.anon.Rows.Add(dr);
            

            myTracer.WriteLine("Last Name: " + this.lastName.Text);
            myTracer.WriteLine("Email: " + this.email.Text);
            myTracer.WriteLine("Phone: " + this.phone.Text);
            myTracer.WriteLine("ID: " + this.id.Text);
            myTracer.WriteLine("City: " + this.city.Text);
            myTracer.WriteLine("State: " + this.st.Text);
            myTracer.WriteLine("Zip: " + this.zip.Text);
            myTracer.WriteLine("Street: " + this.street.Text);
            myTracer.WriteLine("Account: " + this.acc.Text);
            myTracer.WriteLine("Routing: " + this.route.Text);
            myTracer.WriteLine("Amount: " + this.amnt.Text);
            myTracer.WriteLine("Date: " + this.date.Text);
            myTracer.WriteLine("Check: " + this.check.Text);
            myTracer.WriteLine("Store: " + this.store.Text);
            myTracer.WriteLine("Cashier: " + this.cashier.Text);
            myTracer.Close();
            MessageBox.Show("Success.");
        }

        private void Prototype_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'anonDataSet.anon' table. You can move, or remove it, as needed.
            this.anonTableAdapter.Fill(this.anonDataSet.anon);

        }
    }
}
