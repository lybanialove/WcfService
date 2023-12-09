using System;
using System.Windows.Forms;
using ClientService.ServiceContext;
using Service.Requests;

namespace View
{
    public partial class Autorization : Form
    {
        ServiceContractClient client;
        public Autorization(ServiceContractClient _client)
        {
            InitializeComponent();
            client = _client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutorizationRequest request = new AutorizationRequest() { login = textBox2.Text, password = textBox2.Text};
            string s = client.Autorization(request).errMessage;
            if(client.Autorization(request).errMessage != "Такой пользователь с данным логином не найден!")
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
