using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodeCompilerServiceManager.Logic
{
    public class ConnectionManagerClient : IMeesageHandling
    {
        Socket client;
        byte[] _buffer = new byte[512];

        public ConnectionManagerClient()
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
                int port = 3055;

                client.BeginConnect(ipAdress, port, new AsyncCallback(ConnectCallback), client);

                client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), client);
            }
            catch (Exception ex)
            {

            }
        }

        private void ConnectCallback(IAsyncResult asyncResult)
        {
            try
            {
                byte[] infoConnected = Encoding.UTF8.GetBytes("Manager connected!");
                client.BeginSend(infoConnected, 0, infoConnected.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);

                Socket socket = asyncResult.AsyncState as Socket;
                socket.EndConnect(asyncResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SendCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket socket = asyncResult.AsyncState as Socket;
                socket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {

            }
        }

        void ReciveCallback(IAsyncResult asyncResult)
        {
            Socket socket = asyncResult.AsyncState as Socket;
            try
            {
                int recived = client.EndReceive(asyncResult);
                byte[] dataBuf = new byte[recived];
                Array.Copy(_buffer, dataBuf, recived);

                string message = Encoding.UTF8.GetString(dataBuf);

                if (message.Length > 0)
                {
                    OnMessage(message, MessageHandlingLevel.ServiceInfo);
                }

                client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReciveCallback), client);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #region IMeesageHandling

        public event EventHandler<MessageHandlingArgs> GetMessage;
        protected virtual void OnMessage(string message, MessageHandlingLevel level)
        {
            GetMessage?.Invoke(this, new MessageHandlingArgs(message, level));
        }
        #endregion
    }
}
