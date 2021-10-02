using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Threading;
using System.Net;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Xml;
using System.Xml.Serialization;

namespace Servidor_ServicioCliente
{
    public class Servidor : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        //lista de clientes q se van conectando
        List<TcpClient> clientes = new List<TcpClient>();
        //lista de resultados de encuesta
        List<string> encuestas = new List<string>();
        TcpListener listener;
        
        Dispatcher dispatcher;

        public ICommand IniciarCommand { get; set; }
        public ICommand DetenerCommand { get; set; }

        private string conexion;
        public string Conexion
        {
            get { return conexion; }
            set 
            { 
                conexion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Conexion"));
            }
        }

        //estadísticas
        public int TotalEncuestas { get { return encuestas.Count; } }
        public float PorcBueno
        {
            get 
            {
                int tb = encuestas.Where(x => x == "Bueno").Count();
                if (encuestas.Count > 0)
                    return tb * 100 / encuestas.Count;
                else
                    return 0;
            }
        }
        public float PorcExcelente
        {
            get
            {
                int te = encuestas.Where(x => x == "Excelente").Count();
                if (encuestas.Count > 0)
                    return te * 100 / encuestas.Count;
                else
                    return 0;
            }
        }
        public float PorcRegular
        {
            get
            {
                int tr = encuestas.Where(x => x == "Regular").Count();
                if (encuestas.Count > 0)
                    return tr * 100 / encuestas.Count;
                else
                    return 0;
            }
        }
        public float PorcMalo
        {
            get
            {
                int tm = encuestas.Where(x => x == "Malo").Count();
                if (encuestas.Count > 0)
                    return tm * 100 / encuestas.Count;
                else
                    return 0;
            }
        }
        public float PorcPesimo
        {
            get
            {
                int tp = encuestas.Where(x => x == "Pésimo").Count();
                if (encuestas.Count > 0)
                    return tp * 100 / encuestas.Count;
                else
                    return 0;
            }
        }

        //métodos para que funcione servidor
        public void IniciarServidor()
        {
            if (listener == null)
            {
                Task.Run(() =>
                {
                    try
                    {
                        IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 2800);
                        listener = new TcpListener(endPoint);
                        listener.Start();

                        while (listener != null)
                        {
                            TcpClient tcp = listener.AcceptTcpClient();
                            clientes.Add(tcp);
                            Recibir(tcp);
                        }
                    }
                    catch (Exception) { }
                });
                conexion = "Servidor conectado";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }
        public void Recibir(TcpClient cliente)
        {
            Task.Run(() =>
            {
                NetworkStream ns = cliente.GetStream();

                while (cliente.Connected)
                {
                    //hay q verificar que se reciban datos
                    if (cliente.Available > 0)
                    {
                        byte[] buffer = new byte[cliente.Available];
                        ns.Read(buffer, 0, buffer.Length);

                        string encuesta = Encoding.UTF8.GetString(buffer);

                        dispatcher.Invoke(() =>
                        {
                            encuestas.Add(encuesta);

                            Save();
                        });
                    }
                    Task.Delay(50);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            });
        }
        public void DetenerServidor()
        {
            if (listener != null)
            {
                listener.Stop();
                listener = null;

                foreach (var cliente in clientes)
                {
                    cliente.Close();
                }
                clientes.Clear();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                conexion = "Servidor desconectado";
            }
        }
        public Servidor()
        {
            Load();
            dispatcher = Dispatcher.CurrentDispatcher;
            IniciarCommand = new RelayCommand(IniciarServidor);
            DetenerCommand = new RelayCommand(DetenerServidor);
        }

        //serialización
        private void Load()
        {
            try
            {
                XmlReader archivo = XmlReader.Create("estadisticas.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                encuestas = (List<string>)serializer.Deserialize(archivo);
                archivo.Close();
            }
            catch (Exception)
            {
                encuestas = new List<string>();
            }
        }
        private void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            XmlWriter archivo = XmlWriter.Create("estadisticas.xml");

            serializer.Serialize(archivo, encuestas);
            archivo.Close();
        }
    }
}
