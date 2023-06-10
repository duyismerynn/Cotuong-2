using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuongLAN.LAN
{
    public class SocketManager
    {
        #region All

        public string IP = "";
        private int Port = 9999;
        private const int buffer = 1024;
        public bool isServer = true;

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }

        public object Receive()
        {
            byte[] receiveData = new byte[buffer];
            bool isOk = ReceiveData(client, receiveData);
            return DeserializeData(receiveData);

        }

        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }

        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        public byte[] SerializeData(Object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, obj);
            return ms.ToArray();
        }

        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        // Hiển thị IPv4 
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        #endregion

        #region Server
        Socket server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), Port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(iep);
            server.Listen(10);

            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
                MessageBox.Show("Người chơi đã kết nối", "Thông báo", MessageBoxButtons.OK);
            })
            {
                IsBackground = true
            };
            acceptClient.Start();
        }
        #endregion

        #region Client
        Socket client;
        public bool ConnectToServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), Port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK);
                return true;
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
        }
        #endregion
    }
}
