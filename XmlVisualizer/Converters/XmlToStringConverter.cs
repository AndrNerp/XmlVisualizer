using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Xml;
using System.Xml.Linq;

namespace XmlVisualizer.Converters
{
    class XmlToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StringBuilder sb = new StringBuilder();

            System.IO.TextWriter tr = new System.IO.StringWriter(sb);

            XmlTextWriter wr = new XmlTextWriter(tr) { Formatting = Formatting.Indented };

            ((XDocument)value)?.Save(wr);

            wr.Close();

            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
