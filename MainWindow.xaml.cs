using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft;
using Newtonsoft.Json;

namespace FactTest1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nameInput.Text = "what";

            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=assagor&api_key=68756739debfbd093852caf2363e25ec&format=json&limit=1");
            
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";

            System.IO.StreamWriter requestWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream());
            //requestWriter.Write(URLQueryString);
            requestWriter.Close();
            System.IO.StreamReader responseReader = new System.IO.StreamReader(httpWebRequest.GetResponse().GetResponseStream());
            
            var response = responseReader.ReadToEnd();
            var account = JsonConvert.DeserializeObject(response);
            nameInput.Text = account.ToString();

        }
    }
}
