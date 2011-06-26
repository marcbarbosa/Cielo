using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Cielo.Helpers
{
    public static class Xml
    {
        /// <summary>
        /// Serializa um objeto do tipo T
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="obj">Objeto a ser serializado</param>
        /// <returns>String XML com o objeto serializado</returns>
        public static string ToXml<T>(this T obj)
        {
            return ToXml<T>(obj, UTF8Encoding.UTF8);
        }

        /// <summary>
        /// Serializa um objeto do tipo T
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="obj">Objeto a ser serializado</param>
        /// <param name="encoding">Encoding</param>
        /// <returns>String XML com o objeto serializado</returns>
        public static string ToXml<T>(this T obj, Encoding encoding)
        {
            string ret = string.Empty;

            try
            {
                var xs = new XmlSerializer(typeof(T));
                var ms = new MemoryStream();
                var xw = new XmlTextWriter(ms, encoding);

                xs.Serialize(xw, obj);

                ms.Close();
                xw.Close();

                ret = encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        /// <summary>
        /// Deserializa uma string XML para um objeto do tipo T
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="strXml">String XML</param>
        /// <returns></returns>
        public static T ToType<T>(this string strXml)
        {
            return ToType<T>(strXml, UTF8Encoding.UTF8);
        }

        /// <summary>
        /// Deserializa uma string XML para um objeto do tipo T
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="strXml">String XML</param>
        /// <param name="encoding">Encoding</param>
        /// <returns></returns>
        public static T ToType<T>(this string strXml, Encoding encoding)
        {
            var ret = Activator.CreateInstance<T>();

            try
            {
                var xs = new XmlSerializer(typeof(T));
                var ms = new MemoryStream(encoding.GetBytes(strXml));
                var xw = new XmlTextReader(ms);

                ret = (T)xs.Deserialize(xw);

                ms.Close();
                xw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

    }
}
