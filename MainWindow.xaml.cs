using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace DksImager_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static PdfDocument pdf = new PdfDocument();
        public string FullPage = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"temp\FullPage.bmp");
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenPdf(object sender, RoutedEventArgs e)
        {

            
            
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "PDF";
            dialog.DefaultExt = ".pdf";
            dialog.Filter = "PDF файлы (.pdf)|*.pdf";
            

            if(dialog.ShowDialog() == true) { 
            string filename = dialog.FileName;
            pdf = new PdfDocument();
            pdf.LoadFromFile(filename);
            Image image = pdf.SaveAsImage(0, PdfImageType.Metafile, 144, 144);

            image.Save(@"temp\FullPage.bmp", ImageFormat.Bmp);
            pdf.Close();
            pdf.Dispose();
            image.Dispose();

                var bitmap = new BitmapImage();
                using (var stream = new FileStream(FullPage, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    PdfView.Source = bitmap;
                    
                }

            }

            


        }

        private void SaveImage(object sender, RoutedEventArgs e)
        {

            


        }

        private void StartSettings(object sender, RoutedEventArgs e)
        {



        }
    }
}
