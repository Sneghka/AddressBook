using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using addressbook_web_tests.Model;
using addressbook_web_tests.Tests;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //кол-во тестовых данных, которые хотим сгенерировать
            var filename = args[1];
            var format = args[2];
            var groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            if (format == "excel")
            {
                WriteGroupsToExelFile(groups, filename);
                return;
            }

            using (var writer = new StreamWriter(filename)) // название файла
            {
                switch (format)
                {
                    case "csv":
                        WriteGroupsToCsvFile(groups, writer);
                        break;
                    case "xml":
                        WriteGroupsToXmlFile(groups, writer);
                        break;
                    case "json":
                        WriteGroupsToJsonFile(groups, writer);
                        break;
                    default:
                        Console.WriteLine("Invalide file format" + format);
                        break;
                }
            }
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteLine("{0},{1},{2}",
                    group.Name,
                    group.Header,
                    group.Footer);
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }

        static void WriteGroupsToExelFile(List<GroupData> groups, string filename)
        {
            var app = new Excel.Application();
            app.Visible = true;
            var wb = app.Workbooks.Add();
            var sheet = wb.ActiveSheet;

            var row = 1;
            foreach (var group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);
            wb.Close();
            app.Quit();

        }

    }
}
