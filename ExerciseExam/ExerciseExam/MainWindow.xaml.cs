using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Newtonsoft.Json;

namespace ExerciseExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Personen> allProfiles { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            /*string url = "https://dl.dropboxusercontent.com/u/58011895/so4data.json";
            WebClient wc = new WebClient();
            string jsondata = wc.DownloadString(url);
            */
            StreamReader r = new StreamReader("so4data.json");
            string jsondata = r.ReadToEnd();
            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(jsondata);

            allProfiles = new ObservableCollection<Personen>();
            foreach (var p in data.Personen)
            {
                allProfiles.Add(p);
            }

            Personen temp = new Personen();
            
            if (profileInfo.SelectedIndex >= 0)
            {
                profileInfo.DataContext = allProfiles[profileInfo.SelectedIndex];
            }


        }
    }
}
