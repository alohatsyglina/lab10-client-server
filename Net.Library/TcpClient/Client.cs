using System;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;
using System.IO;

namespace SomeProject.Library.Client
{
    public class Client
    {
        public TcpClient tcpClient;

        /// <summary>
        /// Функция получения сообщения от сервера
        /// </summary>
        /// <returns>Результат операции</returns>
        public OperationResult ReceiveMessageFromServer()
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 8080);
                StringBuilder recievedMessage = new StringBuilder();
                byte[] data = new byte[256];
                NetworkStream stream = tcpClient.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    recievedMessage.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                stream.Close();
                tcpClient.Close();

                return new OperationResult(Result.OK, recievedMessage.ToString());
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.ToString());
            }
        }

        /// <summary>
        /// Функция отправки сообщения серверу
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Результат операции</returns>
        public OperationResult SendMessageToServer(string message)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                stream.Close();
                tcpClient.Close();
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Функция отправки файла на сервер
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public OperationResult SendFileToServer(string filePath)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 8080);
                NetworkStream stream = tcpClient.GetStream();
                List<byte> Arr = new List<byte>();
                Arr.AddRange(System.Text.Encoding.UTF8.GetBytes(Path.GetExtension(filePath)));
                Arr.AddRange(File.ReadAllBytes(filePath));
                byte[] data = Arr.ToArray();
                stream.WriteByte(Convert.ToByte(0));
                stream.WriteByte(1);
                stream.WriteByte(Convert.ToByte(System.Text.Encoding.UTF8.GetBytes(Path.GetExtension(filePath)).Length));
                stream.Write(data, 0, data.Length);
                stream.Close();
                tcpClient.Close();
                return new OperationResult(Result.OK, "");
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }
    }
}


