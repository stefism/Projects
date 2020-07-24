using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlDemo
{
    [XmlType("doc")] // Казва какъв е root-а във .Xml файла.
    public class Article// Class with Xml attributes
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("abstract")]
        public string Description { get; set; }

        [XmlIgnore]
        public string Url { get; set; }
    }

    public class doc // Class without Xml attributes
    {
        public string title { get; set; }

        public string @abstract { get; set; }

        public string url { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();

            //XDocument xmlDocument = XDocument.Load("BgWiki.xml");

            //SetAndCgangeValues(xmlDocument);

            //xmlDocument.Save("/../../../bgwiki_updated.xml");

            //GetXmlElements(xmlDocument);

            //CreateXmlWithSelect();

            SerializeFromXml();

            //DeserializeXml();
        }

        private static void DeserializeXml()
        {
            //DeserializeXml
            List<doc> docs = new List<doc>
            {
                new doc {title = "Каф сам убавец", @abstract = "Бла бла бла бла", url = "https://nestosi.com"},
                new doc {title = "Верно си е", @abstract = "Тра ла ла ла ла", url = "https://nestosi2.com"}
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<doc>), new XmlRootAttribute("feed"));// Пак можем да му зададем като опция как да се казва root атрибута.
            serializer.Serialize(File.OpenWrite("myDocs.xml"), docs);
        }

        private static void SerializeFromXml()
        {
            //CreateEntitiesFromXml -> Deserialize Xml (Class):
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(doc[]), new XmlRootAttribute("feed")); // Указва се типа към който ще десериализира, в случая масив от Doc и му се подава като втори параметър Root атрибута, който да търси, в случая той е "feed".

            doc[] docs = (doc[])xmlSerializer
                .Deserialize(File.OpenRead("BgWiki.xml")); // Връща object и затова трябва да се кастне.
            var articles = docs.Where(x => x.title.Contains("Уикипедия"))
                .OrderBy(x => x.title);

            foreach (var article in articles)
            {
                Console.WriteLine(article.title);
            }
        }

        private static void SerializeFromXmlWithAttribute()
        {
            //CreateEntitiesFromXml -> Deserialize Xml (Class):
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Article[]), new XmlRootAttribute("feed")); // Указва се типа към който ще десериализира, в случая масив от Doc и му се подава като втори параметър Root атрибута, който да търси, в случая той е "feed".

            Article[] docs = (Article[])xmlSerializer
                .Deserialize(File.OpenRead("BgWiki.xml")); // Връща object и затова трябва да се кастне.
            var articles = docs.Where(x => x.Title.Contains("Уикипедия"))
                .OrderBy(x => x.Title);

            foreach (var article in articles)
            {
                Console.WriteLine(article.Title);
            }
        }

        private static void CreateXmlWithSelect()
        {
            //Create new Xml document:
            XDocument xDocument = new XDocument(new XElement("books")); // В конструктора можем да сложим Root елемент. В случай той ще бъде "books".

            for (int i = 0; i < 100; i++)
            {
                var number = i > 9
                    ? "0" + i
                    : i.ToString();

                XElement bookElement = new XElement("book");
                bookElement.SetAttributeValue("year", 1876 + i);
                bookElement.Add(new XElement("title", $"Tom Soyer, volume {number + 1}"));
                bookElement.Add(new XElement("author", $"Mark Twain ({i})"));
                xDocument.Root.Add(bookElement);
            }

            xDocument.Save("myBooks.xml");
            /* Output:
             <?xml version="1.0" encoding="utf-8"?>
                <books>
                  <book year="1876">
                    <title>Tom Soyer, volume 01</title>
                    <author>Mark Twain (0)</author>
                  </book>
                  <book year="1877">
                    <title>Tom Soyer, volume 11</title>
                    <author>Mark Twain (1)</author>
                  </book>
            ..... ect ...
             */ // И създава Xml документ от 100 книги.
        }

        private static void GetXmlElements(XDocument xmlDocument)
        {
            var articles = xmlDocument.Root.Elements() //<doc> - най предния елемент е Root елемента.
                            .Where(x => x.Element("title").Value.Contains("Уикипедия"))
                            .OrderBy(x => x.Element("title").Value)
                            .Select(x => new
                            {
                                Title = x.Element("title").Value,
                                Description = x.Element("abstract").Value,
                                Url = x.Element("url").Value
                            }); // И тук можем да правим проекция в анонимни обекти.

            foreach (var art in articles)
            {
                Console.WriteLine(art.Title);
                Console.WriteLine(art.Description);
                Console.WriteLine(art.Url);
            }
        }

        private static void SetAndCgangeValues(XDocument xmlDocument)
        {
            foreach (var article in xmlDocument.Root.Elements())
            {
                article.SetAttributeValue("lang", "bg"); // Добавяме атрибут lang и сетваме value = bg. В случая Root.Elements = <doc> и се получава: <doc lang="bg

                article.SetElementValue("lang", null); // пак ще махне елемента.

                article.Element("title").SetAttributeValue("lang", "bg"); // -> <title> -> <title lang="bg">

                article.SetAttributeValue("lang", null); // Ако сетнеме null на даден атрибут, той бива изтрит.
            }
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
