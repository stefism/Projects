using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Event Handler
        private async void Button_Click(object sender, RoutedEventArgs e)
        { // Само когато имаме евент хендлър е допустимо асинхронния метод да е void. Иначе се пише Task а не void.
            await ShowImageAsync(Image1, "https://http.cat/100");
            await ShowImageAsync(Image2, "https://http.cat/200");
            //Със await му казваме, че долното нещо е зависимо от горното и ще ще изпълнят последователно. Тоест свалянето на картинка 2 ще започне чак след свалянето на картинка 1. Когато нещата не зависят едно от друго или долната операция не зависи от горната, тогава няма нужда слагаме await от пред;
            ShowImageAsync(Image3, "https://http.cat/204");
            ShowImageAsync(Image4, "https://http.cat/207");
            ShowImageAsync(Image5, "https://http.cat/405");
            ShowImageAsync(Image6, "https://http.cat/408");
            //Казваме направо - почни да работиш. Не чакай нищо. И така още по-бързо се зареждат картинките. Await един вид - изчакай горното да си свърши работата. Паралелно пускаме таскове така.
        }

        private async Task ShowImageAsync(Image image, string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            byte[] imageBytes = await response
                .Content.ReadAsByteArrayAsync();

            image.Source = await Task.Run(() => LoadImage(imageBytes));
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
