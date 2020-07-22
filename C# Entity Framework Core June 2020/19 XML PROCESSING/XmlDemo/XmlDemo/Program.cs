using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            XDocument xmlDocument = XDocument.Load("bgwiki-20200701-abstract.xml");

            foreach (var article in xmlDocument.Root.Elements())
            {
                article.SetAttributeValue("lang", "bg"); // Добавяме атрибут lang и сетваме value = bg. В случая Root.Elements = <doc> и се получава: <doc lang="bg

                article.SetElementValue("lang", null); // пак ще махне елемента.

                article.Element("title").SetAttributeValue("lang", "bg"); // -> <title> -> <title lang="bg">

                article.SetAttributeValue("lang", null); // Ако сетнеме null на даден атрибут, той бива изтрит.
            }

            xmlDocument.Save("/../../../bgwiki_updated.xml");
        }

        private static void Demo1()
        {
            var xml = File.ReadAllText("Planes.xml");

            //XDocument xmlDocument = XDocument.Parse(xml);
            //or
            XDocument xmlDocLoad = XDocument.Load("Planes.xml");

            string version = xmlDocLoad.Declaration.Version; //1.0
            string encoding = xmlDocLoad.Declaration.Encoding; //utf-8
            int elementsCount = xmlDocLoad.Root.Elements().Count(); // 4. -> We have 4 planes.

            XElement element = xmlDocLoad.Root.Elements()
                .FirstOrDefault(x => x.Element("color").Value == "Blue");
            /* <plane>
                  <year>1956</year>
                  <make>Piper</make>
                  <model>Tripacer</model>
                  <color>Blue</color>
                </plane> 
            */

            string element2 = xmlDocLoad.Root.Elements()
                .FirstOrDefault(x => x.Element("color").Value == "Blue")
                .Element("year").Value; // 1956

            Console.WriteLine(element2);
        }
    }
}
