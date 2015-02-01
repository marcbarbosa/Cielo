using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Cielo.Helpers
{
    public static class Xml
    {
        public static string ToXml<T>(this T obj)
        {
            return ToXml<T>(obj, UTF8Encoding.UTF8);
        }

        public static string ToXml<T>(this T obj, Encoding encoding)
        {
            if (obj == null)
            {
                return null;
            }

            var xs = new XmlSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                using (var xw = new XmlTextWriter(ms, encoding))
                {
                    xs.Serialize(xw, obj);

                    return encoding.GetString(ms.ToArray());
                }
            }
        }

        public static T ToType<T>(this string strXml)
        {
            return ToType<T>(strXml, UTF8Encoding.UTF8);
        }

        public static T ToType<T>(this string strXml, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(strXml))
            {
                return default(T);
            }

            var xs = new XmlSerializer(typeof(T));

            using (var ms = new MemoryStream(encoding.GetBytes(strXml)))
            {
                using (var xw = new XmlTextReader(ms))
                {
                    return (T)xs.Deserialize(xw);
                }
            }
        }

    }
}
