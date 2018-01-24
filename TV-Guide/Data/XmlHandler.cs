using TV_Guide.Interfaces;
using System.IO;
using System;
using System.Xml.Linq;
using TV_Guide.Models;
using System.Collections.Generic;
using System.Linq;

namespace TV_Guide.Data
{
    public class XmlHandler : IXmlHandler
    {
        private const string FOLDERNAME = "XML";        
        private const string SLASH = "\\";
        private const string CHANNELS = "Channels.xml";
    
        public void FindFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + FOLDERNAME;
          
            if (!File.Exists(path + SLASH + CHANNELS))
            {
                path = new Uri(path).LocalPath;

                try
                {
                    DirectoryInfo directory = Directory.CreateDirectory(path);
                    CreateFile(path);

                }
                catch (Exception ex)
                {
                    string errormessage = ex.Message;
                }
            }     
        }

        public void CreateFile(string path)
        {                       
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", "no"), new XElement("Channels", ""));
            
            xdoc.Save(path + SLASH + CHANNELS);

            xdoc = XDocument.Load(path + SLASH + CHANNELS);

            foreach (string file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + FOLDERNAME).Select(Path.GetFileName).ToArray())
            {
                if (CHANNELS != file)
                {
                    XDocument xmlfile = XDocument.Load(path + SLASH + file);
                    xdoc.Element("Channels").Add(new XElement(xmlfile.Element("tv")));
                    xdoc.Save(path + SLASH + CHANNELS);
                }              
            }
        }

       public List<Program> GetPrograms()
       {
            XDocument xdoc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + FOLDERNAME + SLASH + CHANNELS);

            List<Program> list = new List<Program>();

            foreach (XElement node in xdoc.Descendants("programme"))
            {
                string temptid1 = node.Attribute("start").Value.Remove(0, 8);
                string temptid2 = temptid1.Remove(temptid1.Length -8, 8);
                string temptid3 = temptid2.Insert(2, ":");

                string temptid4 = node.Attribute("stop").Value.Remove(0, 8);
                string temptid5 = temptid4.Remove(temptid4.Length -8, 8);
                string temptid6 = temptid5.Insert(2, ":");

                Program program = new Program();
                program.Title = node.Element("title").Value;
                if (node.Element("desc") != null)
                {
                    program.Description = node.Element("desc").Value;
                }            
                program.Start = temptid3;
                program.Stop = temptid6;
                TV tv = new TV();
                tv.Channel = node.Attribute("channel").Value;
                program.Tv = tv;
                list.Add(program);
            }
            return list;
       }
    }
}