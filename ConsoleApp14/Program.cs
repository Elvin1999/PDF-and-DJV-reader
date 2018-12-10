using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    interface IPageInterface
    {
        string PageContent { get; set; }
    }
    class PDFPage : IPageInterface
    {
        public string Content { get; set; }
        public PDFPage(string content)
        {
            Content = content;
        }
        public string PageContent
        {
            get
            {
                return Content;
            }
            set
            {
                Content = value;
            }
        }
    }
    class DJVPage : IPageInterface
    {
        public string Content { get; set; }
        public DJVPage(string content)
        {
            Content = content;
        }

        public string PageContent
        {
            get
            {
                return Content;
            }
            set
            {
                Content = value;
            }
        }
    }
    interface IBookInterface
    {
        string author();
        string getPageContent(int num);
        int getPagesCount();
        void ShowBookPages();
    }
    class PDFBook : IBookInterface
    {
        List<PDFPage> pdfpages = new List<PDFPage>();
        public string Author { get; set; }
        public PDFBook(string author)
        {
            Author = author;
        }
        public void AddPage(PDFPage page)
        {
            pdfpages.Add(page);
        }

        public string author()
        {
            return Author;
        }

        public string getPageContent(int num)
        {
            string content = string.Empty;
            if (num >= 1 && num <= getPagesCount())
            {
                content = pdfpages[num - 1].Content;
            }
            else
            {
                Console.WriteLine($"Please write page number between 1 and {pdfpages.Count}");
            }
            return content;
        }

        public int getPagesCount()
        {
            var count = pdfpages.Count;
            return count;
        }

        public void ShowBookPages()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine($" Author {Author} "); int count = 0;
            foreach (var item in pdfpages)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($" {item.Content} ");
                Console.WriteLine($" Page {++count}");
                Console.WriteLine("==========================");
            }
        }
    }
    class DjVuBook : IBookInterface
    {
        List<DJVPage> dJVPages = new List<DJVPage>();
        public string Author { get; set; }
        public DjVuBook(string author)
        {
            Author = author;
        }
        public string author()
        {
            return Author;
        }
        public string getPageContent(int num)
        {
            string content = string.Empty;
            if (num >= 1 && num <= getPagesCount())
            {
                content = dJVPages[num - 1].Content;
            }
            else
            {
                Console.WriteLine($"Please write page number between 1 and {dJVPages.Count}");
            }
            return content;
        }
        public int getPagesCount()
        {
            var count = dJVPages.Count;
            return count;
        }
        public void AddPage(DJVPage page)
        {
            dJVPages.Add(page);
        }

        public void ShowBookPages()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine($" Author {Author} "); int count = 0;
            foreach (var item in dJVPages)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($" {item.Content} ");
                Console.WriteLine($" Page {++count}");
                Console.WriteLine("==========================");
            }
        }
    }
    class PDFReader
    {
        public void PDFPageToString(PDFPage page)
        {
            Console.WriteLine(page.Content);
        }
    }
    class DJVReader
    {
        public void DJVPageToString(DJVPage page)
        {
            Console.WriteLine(page.Content);
        }
    }
    class Controller
    {
        public void Run()
        {
            PDFPage pDF1 = new PDFPage("First PDF Content"); PDFPage pDF2 = new PDFPage("Second PDF Content");
            PDFPage pDF3 = new PDFPage("Third PDF Content");
            DJVPage dJV1 = new DJVPage("First DJV Content"); DJVPage dJV2 = new DJVPage("Second DJV Content");
            DJVPage dJV3 = new DJVPage("Third DJV Content");
            DjVuBook djVuBook = new DjVuBook("Elvin"); PDFBook pDFBook = new PDFBook("John");
            djVuBook.AddPage(dJV1); djVuBook.AddPage(dJV2); djVuBook.AddPage(dJV3);
            pDFBook.AddPage(pDF1); pDFBook.AddPage(pDF2); pDFBook.AddPage(pDF3);
            //Console.WriteLine(pDFBook.getPageContent(3));
            //Console.WriteLine(djVuBook.getPageContent(2));
            pDFBook.ShowBookPages();
            djVuBook.ShowBookPages();
            PDFReader pDFReader = new PDFReader();
            //pDFReader.PDFPageToString(pDF1);
            DJVReader dJVReader = new DJVReader();
            //dJVReader.DJVPageToString(dJV1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Run();
        }
    }
}
