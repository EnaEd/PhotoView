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
using System.IO;

namespace FotoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string path;
        string[] imageArr ;//array for list image
        int count = 0;//counter of position in list
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string fileName) {//reload constructor for work of directory file
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName)) {//testing of exist wrong data
                try
                {
                    int indexl = fileName.LastIndexOf('\\');//index for remove
                    imageArr = Directory.GetFiles(fileName.Substring(0, indexl));//get directory file
                    foreach (var item in imageArr)
                    {
                        if (!item.Equals(fileName))
                            count++;
                        else
                            break;
                    }
                   
                    image1.Source = new BitmapImage(new Uri(fileName));
                    sldImage.Maximum = imageArr.Length-1;//set maximum size slider
                    sldImage.Value = count;
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try{                       
            btnNext.IsEnabled = true;//refresh button
            if (count >0 ){//checking overflow
                count--;
                image1.Source = new BitmapImage(new Uri(imageArr[count]));
                    sldImage.Value = count;
                    
            }
            else{
                btnPrev.IsEnabled = false;
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Non support file\n"+ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try{
            btnPrev.IsEnabled = true;//refresh button
            if (count < imageArr.Length-1) {//checking overflow
                count++;
                image1.Source = new BitmapImage(new Uri(imageArr[count]));
                    sldImage.Value = count;
            }
            else {
                btnNext.IsEnabled = false;
            }
                        }
            catch (Exception ex)
            {

                MessageBox.Show("Non support file\n" + ex.Message);
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e) { }

        private void sldImage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            image1.Source = new BitmapImage(new Uri(imageArr[(int)sldImage.Value]));//change image if changed slider
            count =(int)sldImage.Value;//refresh value for correct button work
        }

        private void rB5_Checked(object sender, RoutedEventArgs e)
        {
            
            Image img = new Image();
            BitmapImage btmp = new BitmapImage();
            btmp.BeginInit();
            btmp.UriSource = new Uri(@"C:\Users\djazi\OneDrive\Документы\Visual Studio 2017\Projects\FotoViewer\FotoViewer\imageFun\fine.jpg");
            btmp.EndInit();
            img.Source = btmp;
            img.Height = 20;
            img.Width = 20;
            rB5.Content = img;
            rB3.Content = 3;
            rB1.Content = 1;
            rB2.Content = 2;
            rB4.Content = 4;


        }
        private void rB3_Checked(object sender, RoutedEventArgs e)
        {
            Image imgXm = new Image();
            imgXm.Source = new BitmapImage(new Uri(@"C:\Users\djazi\OneDrive\Документы\Visual Studio 2017\Projects\FotoViewer\FotoViewer\imageFun\Xm.jpg"));
            imgXm.Height = 20;
            imgXm.Width = 20;
            rB3.Content = imgXm;
            rB1.Content = 1;
            rB2.Content = 2;
            rB4.Content = 4;
            rB5.Content = 5;
        }
        private void rB1_Checked(object sender, RoutedEventArgs e)
        {
            Image imgBd = new Image();
            imgBd.Source = new BitmapImage(new Uri(@"C:\Users\djazi\OneDrive\Документы\Visual Studio 2017\Projects\FotoViewer\FotoViewer\imageFun\bad.jpg"));
            imgBd.Height = 21;
            imgBd.Width = 21;
            rB1.Content = imgBd;
            rB2.Content = 2;
            rB3.Content = 3;
            rB4.Content = 4;
            rB5.Content = 5;
        }
        private void rB2_Checked(object sender, RoutedEventArgs e) {
            rB1.Content = 1;
            rB3.Content = 3;
            rB4.Content = 4;
            rB5.Content = 5;
        }
        private void rB4_Checked(object sender, RoutedEventArgs e)
        {
            rB1.Content = 1;
            rB3.Content = 3;
            rB2.Content = 2;
            rB5.Content = 5;
        }
    }
}
