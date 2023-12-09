using ClientService.ServiceContext;
using Service;
using Service.Requests;
using System;
using System.Windows.Forms;


namespace View
{
    public partial class Registration : Form
    {
        ServiceContractClient client;
        public Registration(ServiceContractClient _client)
        {
            InitializeComponent();
            client = _client;
        }
        private void Registration_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationRequest request = new RegistrationRequest() { name = textBox1.Text, surname = textBox2.Text, login = textBox4.Text, password = textBox3.Text };
            
            string s = client.Registration(request).errMessage;
            if (s != "Пользователь с таким логином уже имеется!")
            {
                RecordingMenu recordingMenu = new RecordingMenu(client);
                recordingMenu.Show();
            }
            else
            {
                MessageBox.Show(s);
            }
            
        }
    }
}
