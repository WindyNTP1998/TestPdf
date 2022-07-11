using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace TestPDF;

public class PdfService
{
    public string GeneratorPdf()
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
                 Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");

             BaseFont bf = BaseFont.CreateFont(arial,BaseFont.IDENTITY_H,BaseFont.NOT_EMBEDDED);

             Font f = new Font(bf, 12, Font.NORMAL);
             doc.Add(new Phrase(inputString, f));
             doc.Close();
        }

        
        return "";
        
    }
}