using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MultiWindowForm
{
    //Sorry I couldnt figure out how to make it not close the new customer form when it checks validity
    public partial class NewCustomerForm : Form
    {
        private MainForm _mainForm;
        private int CustomerCount;
        private bool IsEditing;
        private int CurrentSelectionId;
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount = 1;
            IsEditing = false;
            CurrentSelectionId = -1;
        }
        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;
        }
        private void CreateCustomer()
        {
            if (!CheckValidity())
            {
                return;
            }
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

        private bool CheckValidity()
        {
            if (Validators.IsTextEmpty(txtName))
            {
                MessageBox.Show("Name is empty, Please enter a name");
                return false;
            }

            if (Validators.IsTextEmpty(txtPhoneNumber))
            {
                MessageBox.Show("Phone number is empty, Please enter a phone number");
                return false;
            }

            if (Validators.IsTextEmpty(txtEmail))
            {
                MessageBox.Show("Email is empty, Please enter an email");
                return false;
            }

            if (Validators.IsTextNull(txtName))
            {
                MessageBox.Show("Please create a name");
                return false;
            }

            if (Validators.IsTextNull(txtPhoneNumber))
            {
                MessageBox.Show("Please create a phone number");
                return false;
            }

            if (Validators.IsTextNull(txtEmail))
            {
                MessageBox.Show("Please create an email");
                return false;
            }
            bool validity = true;
            return validity;
        }
        private void EditCustomer()
        {
            if (!CheckValidity())
            {
                return;
            }
            MessageBox.Show("Form is being edited.");
            _mainForm.EditCustomer(CurrentSelectionId, new Customer
            {
                CustomerId = CurrentSelectionId,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            });
            CurrentSelectionId = -1;
            ToggleEdit(false);
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
            CurrentSelectionId = customer.CustomerId;
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
