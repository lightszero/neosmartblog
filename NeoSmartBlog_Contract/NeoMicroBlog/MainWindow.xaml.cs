using System;
using System.Collections.Generic;
using System.Linq;
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

namespace NeoMicroBlog
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetHeight();
        }
        async Task GetHeight()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string pdata = "{" +
                            "\"jsonrpc\": \"2.0\"," +
                            "\"method\": \"getblockcount\"," +
                            "\"params\": []," +
                            "\"id\": 1" +
                            "}";
            try
            {
                //0xe2f141bc432c3026c7ae963bfd9eedc9000473ae
                //ae730400c9ed9efd3b96aec726302c43bc41f1e2
                var http = label01.Content.ToString();
                var back = await wc.UploadDataTaskAsync(http, System.Text.Encoding.UTF8.GetBytes(pdata));
                var backstr = System.Text.Encoding.UTF8.GetString(back);
                Console.WriteLine(backstr);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
        async Task GetContractInfo(string script)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string pdata = "{" +
                            "\"jsonrpc\": \"2.0\"," +
                            "\"method\": \"getcontractstate\"," +
                            "\"params\": ['"+script+"']," +
                            "\"id\": 1" +
                            "}";
            try
            {
                //0xe2f141bc432c3026c7ae963bfd9eedc9000473ae
                //ae730400c9ed9efd3b96aec726302c43bc41f1e2
                //e2f141bc432c3026c7ae963bfd9eedc9000473ae
                var http = label01.Content.ToString();
                var back =await wc.UploadDataTaskAsync(http,System.Text.Encoding.UTF8.GetBytes(pdata));
                var backstr =  System.Text.Encoding.UTF8.GetString(back);
                Console.WriteLine(backstr);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var hy = textScript.Text;
            GetContractInfo(hy);
        }
    }
}
