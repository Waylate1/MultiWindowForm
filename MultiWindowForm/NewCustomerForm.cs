using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiWindowForm
{
    public partial class NewCustomerForm : Form
    {
        private MainForm _mainForm;
        private int CustomerCount;
        private bool IsEditing;
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount = 1;
            IsEditing = false;
        }
        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;
            _mainForm.EditCustomer(0, new Customer());
        }
        private void CreateCustomer()
        {
            Customer customer = new Customer
            {
                CustomerId = CustomerCount,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            };
            _mainForm.AddCustomer(customer);
            CustomerCount++;
        }
        private void EditCustomer()
        {
            MessageBox.Show("Form is being edited.");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                
                EditCustomer();
            }
            else
            {
              CreateCustomer();
            }


            ClearForm();

            Hide();
        }
        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
        }
        public void LoadCustomer(Customer customer)
        {
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhoneNumber.Text = customer.PhoneNumber;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
           ClearForm();
        }
    }
}
