using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FateCharacterGeneratorAdvanced.Backend
{
    class Serializer
    {
        public static T ReadBinary<T>(string path)
        {
            T value;
            try
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                using (FileStream stream = new FileStream(path, FileMode.Open))
                using (var reader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max))
                    value = (T)ser.ReadObject(reader);
                return value;
            }
            catch
            {
                return default(T);
            }
        }

        public static bool WriteBinary<T>(string path, T value)
        {
            try
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(new FileStream(path, FileMode.Create), null, null, true))
                    ser.WriteObject(writer, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T ReadJson<T>(string path)
        {
            T value;
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            //using (FileStream stream = new FileStream(path, FileMode.Open))
            //    value = (T)ser.ReadObject(stream);
            //return value;


            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                using (FileStream stream = new FileStream(path, FileMode.Open))
                    value = (T)ser.ReadObject(stream);
                return value;
            }
            catch
            {
                return default(T);
            }
        }

        public static bool WriteJson<T>(string path, T value, bool formatted = true)
        {
            try
            {
                if (formatted)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, false))
                            ser.WriteObject(writer, value);
                        stream.Position = 0;
                        File.WriteAllText(path, prettyJsonPrinter(new StreamReader(stream).ReadToEnd()));
                    }
                }
                else
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                    using (var writer = JsonReaderWriterFactory.CreateJsonWriter(new FileStream(path, FileMode.Create), Encoding.UTF8, true))
                        ser.WriteObject(writer, value);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string prettyJsonPrinter(string text, string indentChars = "\t")
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0, deep = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '[' || c == '{')
                    deep++;
                else if (c == ']' || c == '}')
                    deep--;
                if (c == '[' || c == '{' || c == ',' || c == ']' || c == '}')
                {
                    builder.Clear();
                    builder.Append("\r\n");
                    for (int d = 0; d < deep; d++)
                        builder.Append(indentChars);
                    text = text.Insert(i + (c == '[' || c == '{' || c == ',' ? 1 : 0), builder.ToString());
                    i += builder.Length;
                }
                else if (c == ':')
                {
                    text = text.Insert(i + 1, " ");
                    i++;
                }
            }
            return text;
        }

        public static T ReadXml<T>(string path)
        {
            T value;
            try
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                using (FileStream stream = new FileStream(path, FileMode.Open))
                    value = (T)ser.ReadObject(stream);
                return value;
            }
            catch
            {
                return default(T);
            }
        }

        public static bool WriteXml<T>(string path, T value, bool formatted = true)
        {
            try
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                using (XmlWriter writer = XmlWriter.Create(new FileStream(path, FileMode.Create), new XmlWriterSettings() { CloseOutput = true, Indent = formatted, IndentChars = "\t" }))
                    ser.WriteObject(writer, value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string[] ReadFileNamesFromDirectory(string path, string filter)
        {
            return Directory.GetFiles(path, filter);
        }
    }
}
