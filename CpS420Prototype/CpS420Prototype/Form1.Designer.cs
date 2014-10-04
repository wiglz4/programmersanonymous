namespace CpS420Prototype
{
    partial class Prototype
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cashier = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.store = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.amnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.route = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.acc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.zip = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.TextBox();
            this.st = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.addressEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.anonDataSet = new CpS420Prototype.anonDataSet();
            this.anonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.anonTableAdapter = new CpS420Prototype.anonDataSetTableAdapters.anonTableAdapter();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routingNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streetAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashierNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.addressEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 594);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 575);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Cashier #:";
            // 
            // cashier
            // 
            this.cashier.Location = new System.Drawing.Point(382, 568);
            this.cashier.Name = "cashier";
            this.cashier.Size = new System.Drawing.Size(147, 20);
            this.cashier.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Store #:";
            // 
            // store
            // 
            this.store.Location = new System.Drawing.Point(382, 542);
            this.store.Name = "store";
            this.store.Size = new System.Drawing.Size(147, 20);
            this.store.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Check #:";
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(382, 490);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(147, 20);
            this.check.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Date:";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(382, 464);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(147, 20);
            this.date.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Amount:";
            // 
            // amnt
            // 
            this.amnt.Location = new System.Drawing.Point(382, 438);
            this.amnt.Name = "amnt";
            this.amnt.Size = new System.Drawing.Size(147, 20);
            this.amnt.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Routing #:";
            // 
            // route
            // 
            this.route.Location = new System.Drawing.Point(382, 412);
            this.route.Name = "route";
            this.route.Size = new System.Drawing.Size(147, 20);
            this.route.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Account #:";
            // 
            // acc
            // 
            this.acc.Location = new System.Drawing.Point(382, 386);
            this.acc.Name = "acc";
            this.acc.Size = new System.Drawing.Size(147, 20);
            this.acc.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "ID#:";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(78, 490);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(147, 20);
            this.id.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 471);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Phone #:";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(78, 464);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(147, 20);
            this.phone.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 445);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Email:";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(78, 438);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(147, 20);
            this.email.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 419);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Last Name:";
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(78, 412);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(147, 20);
            this.lastName.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 393);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "First Name:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(78, 386);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(147, 20);
            this.firstName.TabIndex = 60;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(166, 547);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 75;
            this.label13.Text = "ST:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 575);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "Zip:";
            // 
            // zip
            // 
            this.zip.Location = new System.Drawing.Point(74, 569);
            this.zip.Name = "zip";
            this.zip.Size = new System.Drawing.Size(151, 20);
            this.zip.TabIndex = 72;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 549);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 71;
            this.label15.Text = "City:";
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(74, 543);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(84, 20);
            this.city.TabIndex = 70;
            // 
            // st
            // 
            this.st.Location = new System.Drawing.Point(192, 542);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(33, 20);
            this.st.TabIndex = 74;
            // 
            // street
            // 
            this.street.Location = new System.Drawing.Point(74, 595);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(151, 20);
            this.street.TabIndex = 76;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 602);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 77;
            this.label16.Text = "Street #:";
            // 
            // addressEntryBindingSource
            // 
            this.addressEntryBindingSource.DataMember = "addressEntry";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.emailAddressDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.iDNumberDataGridViewTextBoxColumn,
            this.accountNumberDataGridViewTextBoxColumn,
            this.routingNumberDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.checkDateDataGridViewTextBoxColumn,
            this.checkNumberDataGridViewTextBoxColumn,
            this.streetAddressDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.zipDataGridViewTextBoxColumn,
            this.storeNumberDataGridViewTextBoxColumn,
            this.cashierNumberDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.anonBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(516, 355);
            this.dataGridView1.TabIndex = 78;
            // 
            // anonDataSet
            // 
            this.anonDataSet.DataSetName = "anonDataSet";
            this.anonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // anonBindingSource
            // 
            this.anonBindingSource.DataMember = "anon";
            this.anonBindingSource.DataSource = this.anonDataSet;
            // 
            // anonTableAdapter
            // 
            this.anonTableAdapter.ClearBeforeFill = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "firstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "firstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "lastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "lastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // emailAddressDataGridViewTextBoxColumn
            // 
            this.emailAddressDataGridViewTextBoxColumn.DataPropertyName = "emailAddress";
            this.emailAddressDataGridViewTextBoxColumn.HeaderText = "emailAddress";
            this.emailAddressDataGridViewTextBoxColumn.Name = "emailAddressDataGridViewTextBoxColumn";
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "phoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "phoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            // 
            // iDNumberDataGridViewTextBoxColumn
            // 
            this.iDNumberDataGridViewTextBoxColumn.DataPropertyName = "IDNumber";
            this.iDNumberDataGridViewTextBoxColumn.HeaderText = "IDNumber";
            this.iDNumberDataGridViewTextBoxColumn.Name = "iDNumberDataGridViewTextBoxColumn";
            // 
            // accountNumberDataGridViewTextBoxColumn
            // 
            this.accountNumberDataGridViewTextBoxColumn.DataPropertyName = "accountNumber";
            this.accountNumberDataGridViewTextBoxColumn.HeaderText = "accountNumber";
            this.accountNumberDataGridViewTextBoxColumn.Name = "accountNumberDataGridViewTextBoxColumn";
            // 
            // routingNumberDataGridViewTextBoxColumn
            // 
            this.routingNumberDataGridViewTextBoxColumn.DataPropertyName = "routingNumber";
            this.routingNumberDataGridViewTextBoxColumn.HeaderText = "routingNumber";
            this.routingNumberDataGridViewTextBoxColumn.Name = "routingNumberDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // checkDateDataGridViewTextBoxColumn
            // 
            this.checkDateDataGridViewTextBoxColumn.DataPropertyName = "checkDate";
            this.checkDateDataGridViewTextBoxColumn.HeaderText = "checkDate";
            this.checkDateDataGridViewTextBoxColumn.Name = "checkDateDataGridViewTextBoxColumn";
            // 
            // checkNumberDataGridViewTextBoxColumn
            // 
            this.checkNumberDataGridViewTextBoxColumn.DataPropertyName = "checkNumber";
            this.checkNumberDataGridViewTextBoxColumn.HeaderText = "checkNumber";
            this.checkNumberDataGridViewTextBoxColumn.Name = "checkNumberDataGridViewTextBoxColumn";
            // 
            // streetAddressDataGridViewTextBoxColumn
            // 
            this.streetAddressDataGridViewTextBoxColumn.DataPropertyName = "streetAddress";
            this.streetAddressDataGridViewTextBoxColumn.HeaderText = "streetAddress";
            this.streetAddressDataGridViewTextBoxColumn.Name = "streetAddressDataGridViewTextBoxColumn";
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "city";
            this.cityDataGridViewTextBoxColumn.HeaderText = "city";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            // 
            // zipDataGridViewTextBoxColumn
            // 
            this.zipDataGridViewTextBoxColumn.DataPropertyName = "zip";
            this.zipDataGridViewTextBoxColumn.HeaderText = "zip";
            this.zipDataGridViewTextBoxColumn.Name = "zipDataGridViewTextBoxColumn";
            // 
            // storeNumberDataGridViewTextBoxColumn
            // 
            this.storeNumberDataGridViewTextBoxColumn.DataPropertyName = "storeNumber";
            this.storeNumberDataGridViewTextBoxColumn.HeaderText = "storeNumber";
            this.storeNumberDataGridViewTextBoxColumn.Name = "storeNumberDataGridViewTextBoxColumn";
            // 
            // cashierNumberDataGridViewTextBoxColumn
            // 
            this.cashierNumberDataGridViewTextBoxColumn.DataPropertyName = "cashierNumber";
            this.cashierNumberDataGridViewTextBoxColumn.HeaderText = "cashierNumber";
            this.cashierNumberDataGridViewTextBoxColumn.Name = "cashierNumberDataGridViewTextBoxColumn";
            // 
            // Prototype
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 623);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.street);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.st);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.zip);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.city);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cashier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.store);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.check);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.route);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.acc);
            this.Name = "Prototype";
            this.Text = "Prototype";
            this.Load += new System.EventHandler(this.Prototype_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addressEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anonBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cashier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox store;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox check;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox amnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox route;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox acc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox zip;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox st;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.BindingSource addressEntryBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private anonDataSet anonDataSet;
        private System.Windows.Forms.BindingSource anonBindingSource;
        private anonDataSetTableAdapters.anonTableAdapter anonTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routingNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn streetAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashierNumberDataGridViewTextBoxColumn;
       }
}

