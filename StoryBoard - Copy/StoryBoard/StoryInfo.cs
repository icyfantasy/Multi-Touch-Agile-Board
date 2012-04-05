using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;


namespace StoryBoard
{
    public class StoryInfo
    {
        private string label;
        private string fileName;
        private string groupName;
        private BitmapImage bitmap;

        public StoryInfo(string fileName, string label, string groupName)
        {
            this.fileName = fileName;
            this.label = label;
            this.groupName = groupName;
            this.bitmap = new BitmapImage(new Uri(fileName, UriKind.Absolute));
        }

        public string Label
        {
            get { return label; }
        }
        public string FileName
        {
            get { return fileName; }
        }

        public string GroupName
        {
            get { return groupName; }
        }

        public BitmapSource Bitmap
        {
            get { return bitmap; }
        }

    }
}
