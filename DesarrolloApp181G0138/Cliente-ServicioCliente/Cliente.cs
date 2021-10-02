using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Cliente_ServicioCliente
{
    [Serializable]
    public class Cliente
    {
        TcpClient cliente = new TcpClient();

        public ICommand ConectarCommand { get; set; }
        public ICommand EnviarCommand { get; set; }

        private bool conectado = false;

        public bool Conectado
        {
            get { return conectado; }
            set { conectado = value; }
        }
        private void Conectar()
        {
            if (Conectado == false)
            {
                cliente.Connect(new IPEndPoint(IPAddress.Loopback, 2800));
                Task.Delay(10);
                Conectado = cliente.Connected;
            }
        }
        private void Enviar(string encuesta)
        {
            if (conectado == true)
            {
                if (!string.IsNullOrWhiteSpace(encuesta))
                {
                    NetworkStream ns = cliente.GetStream();
                    //se convierte el resultado seleccionado a bytes para enviarlo al servidor y q lo lea
                    var buffer = Encoding.UTF8.GetBytes(encuesta);
                    ns.Write(buffer, 0, buffer.Length);
                }
            }
            else
                MessageBox.Show("El cliente no se ha conectado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public Cliente()
        {
            ConectarCommand = new RelayCommand(Conectar);
            EnviarCommand = new RelayCommand<string>(Enviar);
        }

    }
}
