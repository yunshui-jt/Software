using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadContent
{
    public class Model1 : INotifyPropertyChanged
    {
        public static string ContentwithLoad = string.Empty;
        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                if (value == _content) return;
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private string _txtpath;
        public string txtpath
        {
            get => _txtpath;
            set
            {
                if (value == _txtpath) return;
                _txtpath = value;
                OnPropertyChanged(nameof(txtpath));
            }
        }

        
        private static Encoding[] _Encodings = new Encoding[] { Encoding.Default, Encoding.ASCII, Encoding.UTF8, Encoding.Unicode, Encoding.UTF7, Encoding.UTF32, Encoding.BigEndianUnicode };
        public Encoding[] Encodings { get { return _Encodings; } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));

        public string ReadFile(string path,Encoding encoding)
        {
            StreamReader sr = new StreamReader(path, encoding);
            return sr.ReadToEnd();
        }
    }
}
