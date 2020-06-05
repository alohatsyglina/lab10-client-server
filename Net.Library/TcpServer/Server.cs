using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeProject.Library.Server
{

    public class Server
    {
        readonly TcpListener serverListener;
        private static int fileCount = 0;
        private static int count = 0;
        private static readonly int maxCount = 10;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Server()
        {
            serverListener = new TcpListener(IPAddress.Loopback, 8081);
        }

        /// <summary>
        /// Функция включения прослушивания соединений
        /// </summary>
        /// <returns>Возвращает fasle, если была ошибка, иначе - true</returns>
        public async Task TurnOnListener()
        {
            try
            {
                if (serverListener != null)
                {
                    serverListener.Start();
                }
                Console.WriteLine("Waiting for connections...");
                ThreadPool.SetMaxThreads(maxCount, maxCount);
                ThreadPool.SetMinThreads(maxCount / 2, maxCount / 2);
                while (true)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(NewConnection), serverListener.AcceptTcpClient());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn on listener: " + e.Message);
            }
        }

        /// <summary>
        /// Функция остановки прослушивания соединений
        /// </summary>
        /// <returns>Возвращает fasle, если была ошибка, иначе - true</returns>
        public bool TurnOffListener()
        {
            try
            {
                if (serverListener != null)
                    serverListener.Stop();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot turn off listener: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Процедура оработки нового подключения
        /// </summary>
        /// <param name="client">Клиент</param>
        static void NewConnection(object client)
        {
            Interlocked.Increment(ref count);
            Console.WriteLine("The current number of connections: " + count);
            OperationResult result = ReceiveHeaderFromClient((TcpClient)client).Result;
            if (result.Result == Result.Fail)
                Console.WriteLine("Unexpected error: " + result.Message);
            else
                Console.WriteLine(result.Message);
            Interlocked.Decrement(ref count);
        }

        /// <summary>
        /// Процедура определения полученных данных
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <returns>Результат операции</returns>
        public async static Task<OperationResult> ReceiveHeaderFromClient(TcpClient client)
        {
            try
            {
                string res = "";
                using (NetworkStream stream = client.GetStream())
                {
                    StringBuilder strb = new StringBuilder();
                    byte[] data = new byte[1];
                    await stream.ReadAsync(data, 0, 1);
                    strb.Append(Encoding.UTF8.GetString(data, 0, 1));
                    string str = strb.ToString();
                    if (data[0] == '1')
                    {
                        res = ReceiveFileFromClient(stream).Message;
                    }
                    else
                    {
                        res = ReceiveMessageFromClient(stream);
                    }
                    SendMessageToClient(stream, res);
                }
                return new OperationResult(Result.OK, res);
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Функция получения сообщения от клиента
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Результат операции</returns>
        private static string ReceiveMessageFromClient(NetworkStream stream)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                byte[] data = new byte[256];
                str.Append("Message: ");
                while (stream.DataAvailable)
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    str.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                return str.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        /// <summary>
        /// Функция получения файла от клиента
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <returns>Результат операции</returns>
        private static OperationResult ReceiveFileFromClient(NetworkStream stream)
        {
            try
            {
                Interlocked.Increment(ref fileCount);
                byte[] data = new byte[4096];
                if (!Directory.Exists(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    Directory.CreateDirectory(DateTime.Now.ToString("yyyy-MM-dd"));
                }
                int bytes = stream.Read(data, 0, data.Length);
                string str = Encoding.Default.GetString(data);
                int index = str.IndexOf('$');
                string type = str.Substring(0, index);
                string path = DateTime.Now.ToString("yyyy-MM-dd") + "\\File" + fileCount + "." + type;
                using (FileStream fstream = new FileStream(path, FileMode.Create))
                {
                    fstream.Write(data, index + 1, bytes - index - 1);
                    while (stream.DataAvailable)
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        fstream.Write(data, 0, bytes);
                    }
                }
                return new OperationResult(Result.OK, "File: " + path);
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
        }

        /// <summary>
        /// Функция для отправки сообщения клиенту
        /// </summary>
        /// <param name="stream">Поток</param>
        /// <param name="message">Сообщение</param>
        /// <returns>Результат операции</returns>
        private static OperationResult SendMessageToClient(NetworkStream stream, string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                return new OperationResult(Result.Fail, e.Message);
            }
            return new OperationResult(Result.OK, "");
        }
    }
}
