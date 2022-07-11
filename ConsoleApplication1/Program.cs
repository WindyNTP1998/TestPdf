using System;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inputString = "Nguyễn Thanh Phong Phĩ Phõ, 你好，我是帅哥 ";

            Document doc = new Document(PageSize.LETTER);

            using (var fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"),
                       FileMode.Create, FileAccess.Write, FileShare.Read)) 
            {
                PdfWriter writer = PdfWriter.GetInstance(doc,fs);
                doc.Open();
                doc.NewPage();
                var arial =
                    Path.Combine(@"D:\Fonts", "ARIALUNI.TTF");

                BaseFont bf = BaseFont.CreateFont(arial,BaseFont.IDENTITY_H,BaseFont.NOT_EMBEDDED);

                Font f = new Font(bf, 12, Font.NORMAL);
                doc.Add(new Phrase(inputString, f));
                doc.Close();
            }

            var stringto64 = ToBase64(inputString);
            Console.WriteLine("To Base 64: " + stringto64);
            Console.WriteLine("From Base 64: " + FromBase64(stringto64));
        }
        public static string ToBase64(string value)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
             return Encoding.UTF7.GetString(value);
            //return Convert.ToBase64String(bytes);
            
        }

        public static string FromBase64(string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.Default.GetString(bytes);
        }
    }
}