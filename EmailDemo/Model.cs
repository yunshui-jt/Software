using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDemo
{
    class Model : INotifyPropertyChanged
    {
        private string _PictureFileName;//图片名字
        public string PictureFileName {
            get => _PictureFileName;
            set
            {
                if (value == _PictureFileName) return;
                _PictureFileName = value;
                OnPropertyChanged(nameof(PictureFileName));
            }
        }

        private string _Content;//内容
        public string Content
        {
            get => _Content;
            set
            {
                if (value == _Content) return;
                _Content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public string ReadFileWithPath(string path)
        {
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));

    }
}
