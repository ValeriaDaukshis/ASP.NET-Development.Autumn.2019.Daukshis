using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
//            int[] array = {0, 1, 2};
//            Dictionary<int, int> dict = new Dictionary<int, int>()
//            {
//                {1, 1},
//                {2, 2}
//            };
//            
//            LinkedList<int> a = new LinkedList<int>(new int[]{0,1,2});
//            Collection<int> b = new Collection<int>(array);
//            List<int> list = new List<int>(array);
//            BindingList<int> c = new BindingList<int>(array);
//            ObservableCollection<int> obs = new ObservableCollection<int>(array);
//            Dictionary<int,int>.KeyCollection keyed = new Dictionary<int, int>.KeyCollection(dict);
//            ReadOnlyCollection<int> f = new ReadOnlyCollection<int>(array);
//            ReadOnlyObservableCollection<int> k = new ReadOnlyObservableCollection<int>(obs);
//            SortedList<int, int> sortedList = new SortedList<int, int>(dict);
//            SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>(dict);
//            ReadOnlyDictionary<int, int> readOnlyDictionary = new ReadOnlyDictionary<int, int>(dict);
//            HashSet<int> hashSet = new HashSet<int>(array);
//            SortedSet<int> sortedSet = new SortedSet<int>(array);
//            Queue<int> queue = new Queue<int>(array);
//            Stack<int> stack = new Stack<int>(array);
//            
//            
//            foreach(var kkk in keyed)
//                Console.WriteLine(kkk);

            string path = @"C:\Users\dauks\Dop Task Epam\File_Cabinet\abcd.xml";
            try
            {
                using (StreamWriter stream = new StreamWriter(path))
                {
                    XmlWriterSettings settings = new XmlWriterSettings() {Indent = true};

                    using (XmlWriter writer = XmlWriter.Create(stream, settings)) 
                    {
                        writer.WriteStartElement("records");
                            writer.WriteStartElement("record");
                                writer.WriteAttributeString( "id",  "1" );
                                    writer.WriteStartElement("name");
                                        writer.WriteAttributeString( "first",  "petr" );
                                        writer.WriteAttributeString( "last",  "semenov" );
                                    writer.WriteEndElement();
                                    writer.WriteElementString("gender", "M");
                                    writer.WriteElementString("dateofbirth", "01/01/1989");
                                    writer.WriteElementString("creditSum", "12");
                                    writer.WriteElementString("duration", "12");
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                        
                        writer.Flush();
                        writer.Close();
                    }  
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}