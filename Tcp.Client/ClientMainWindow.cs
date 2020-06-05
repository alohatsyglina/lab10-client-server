using System;
using System.Windows.Forms;
using SomeProject.Library.Client;
using SomeProject.Library;

namespace SomeProject.TcpClient
{
    public partial class ClientMainWindow : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ClientMainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку отправки сообщения
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void OnMsgBtnClick(object sender, EventArgs e)
        {
            Client client = new Client();
            Result res = client.SendMessageToServer(textBox.Text).Result;
            if(res == Result.OK)
            {
                textBox.Text = "";
                labelRes.Text = "Message was sent succefully!";
            }
            else
            {
                labelRes.Text = "Cannot send the message to the server.";
            }
            timer.Interval = 2000;
            timer.Start();
        }

        /// <summary>
        /// Очистка поля поля вывода результата операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            labelRes.Text = "";
            serverResponseLabel.Text = "";
            timer.Stop();
        }

        /// <summary>
        /// Обработка нажатия на кнопку отправки файла
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void SendFileBtn_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            Result result = client.SendFileToServer(fileNameBox.Text).Result;
            if (result == Result.OK)
                serverResponseLabel.Text = "File was sent succesfully!";
            else
                serverResponseLabel.Text = "Cannot send file to the server.";
            timer.Interval = 2000;
            timer.Start();
        }

        /// <summary>
        /// Обработка кнопки выбора файла
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void ChooseFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            fileNameBox.Text = fileDialog.FileName;
        }
    }
}
