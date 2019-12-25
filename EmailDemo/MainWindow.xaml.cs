using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using LoadContent;

namespace EmailDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model myData;
        public MainWindow()
        {
            InitializeComponent();
            myData = new Model();
            this.DataContext = myData; 
        }

        private void loadcontent(object sender, RoutedEventArgs e)
        {
            Loaddown w = new Loaddown();
            w.ShowDialog();
            if(Model1.ContentwithLoad!=string.Empty)
                myData.Content = Model1.ContentwithLoad;

        }

        public string FindFileDialog(string filter)
        {
            
            string localFilePath = "";
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = filter;// "txt files(*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;
                bool? result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    
                    return localFilePath = openFileDialog.FileName.ToString();
                }
                return localFilePath;

            }
            catch (Exception ex)
            {
                MessageBox.Show("上传文件不正确，请重新选！");
                return localFilePath;
            }
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            string path = FindFileDialog("jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|jepg files(*.jepg)|*.jepg");
            myData.PictureFileName = path;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnOK_executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("成功执行！");
        }

        private void OnOK_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            string pattern = "^[_a-z0-9-]+(/.[_a-z0-9-]+)*@[a-z0-9-]+(/.[a-z0-9-]+)*$";
            Regex r = new Regex(pattern);
            Match m = r.Match(tb_email.Text);
            e.CanExecute = !string.IsNullOrEmpty(tb_email.Text) && 
                m.Success && 
                !string.IsNullOrEmpty(tb_Content.Text) && 
                !string.IsNullOrEmpty(tb_PicPath.Text);
        }

    }
}
