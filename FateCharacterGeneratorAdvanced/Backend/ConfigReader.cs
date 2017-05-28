using System;
using System.IO;
using System.Xml;

namespace FateCharacterGeneratorAdvanced.Backend
{
    public enum ConfigFileTypes
    {
        femaleforenames,
        maleforenames,
        surnames,
        skills
    }

    class ConfigReader
    {
        private static string path = Environment.CurrentDirectory + @"\config\";

        public static string[] readConfigFiles(ConfigFileTypes file)
        {
            string fileName = Enum.GetName(file.GetType(), file);
            string fullpath = string.Format("{0}{1}.xml", ConfigReader.path, fileName);
            if (!File.Exists(fullpath))
            {
                throw new FileNotFoundException(string.Format("file not found: {0}", fullpath));
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fullpath);
            XmlNode node = xDoc.FirstChild.NextSibling;
            string names = trimXmlResult(node.InnerText);
            string[] result = names.Split(',');
            Array.Sort(result);
            return result;
        }

        private static string trimXmlResult(string names)
        {
            names = names.Replace("\t", "");
            names = names.Replace("\r", "");
            names = names.Replace("\n", "");
            names = names.Replace(" ", "");
            return names;
        }
    }
}
