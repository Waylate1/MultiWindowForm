namespace MultiWindowForm
{
    public partial class MainForm : Form
    {
        private NewCustomerForm _customerForm;
        private List<Customer> _customerList;
        public MainForm()
        {
            InitializeComponent();
            _customerForm = new NewCustomerForm(this);
            _customerList = new List<Customer>();

            _customerList.Add(new Customer
            {
                Name = "Oliver",
                Email = "Ryu@gmail.com",
                PhoneNumber = "(560)-654-0972"
            });
            ReloadDateGrid();
        }
        private void ReloadDateGrid()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = _customerList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _customerForm.ShowDialog();
        }

        public void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
            ReloadDateGrid();
        }
        public void EditCustomer(int id, Customer updatedCustomer)
        {
            MessageBox.Show("Mainform  is editing the customer now.");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            Customer cust;

            var index = dgvCustomers.SelectedRows[0].Index;

            cust = _customerList[index];
            
            _customerForm.LoadCustomer(cust);

            _customerForm.ToggleEdit(true);

            _customerForm.Show();
        }
    }
}
