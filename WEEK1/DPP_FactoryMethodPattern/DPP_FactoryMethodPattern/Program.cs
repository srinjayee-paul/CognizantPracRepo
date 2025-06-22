using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPP_FactoryMethodPattern
{
    public interface Document
    {
        void display();
    }
    public class WordDocument : Document
    {
        public void display()
        {
            Console.WriteLine("This is a Word document\n");
        }
    }
    public class ExcelDocument : Document
    {
        public void display()
        {
            Console.WriteLine("This is an Excel document\n");
        }
    }
    public class PDFDocument : Document
    {
        public void display()
        {
            Console.WriteLine("This is the PDF document\n");
        }
    }
    public abstract class DocumentFactory
    {
        public abstract Document CreateDocument();
    }
    public class WordFactory : DocumentFactory
    {
        public override Document CreateDocument()
        {
            Console.WriteLine("Creating a Word document... ");
            return new WordDocument();
        }
    }
    public class ExcelFactory : DocumentFactory
    {
        public override Document CreateDocument()
        {
            Console.WriteLine("Creating a Excel document... ");
            return new ExcelDocument();
        }
    }
    public class PDFFactory : DocumentFactory
    {
        public override Document CreateDocument()
        {
            Console.WriteLine("Creating a PDF document... ");
            return new PDFDocument();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DocumentFactory wFac = new WordFactory();
            Document wDoc = wFac.CreateDocument();
            wDoc.display();

            DocumentFactory pdfFac = new PDFFactory();
            Document pdfDoc = pdfFac.CreateDocument();
            pdfDoc.display();

            DocumentFactory excelFac = new ExcelFactory();
            Document excelDoc = excelFac.CreateDocument();
            excelDoc.display();
        }
    }
}
