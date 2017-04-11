using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Office;
using System.Text.RegularExpressions;

namespace ReadingFolder_App
{
  public class Archive
    {

        public void Extract(FileInfo fileToDecompress)
        {
            using (FileStream originalstream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream DecompressedFileStream = File.Create(newFileName)) 
                {
                    using (GZipStream DecompressionStream = new GZipStream(originalstream, CompressionMode.Decompress)) 
                    {
                        if(fileToDecompress.Extension == "Zip Files| *.zip; *.rar")
                        { 
                             DecompressionStream.CopyTo(DecompressedFileStream);// this is to decompress all the files
                        }


                    }
                }
            }
        }

        public void test()
        {



            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(@"features.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string notUsing = "class";
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //switch (notUsing)
                    //{
                    //    case "class":
                    //        list.Add(line);
                    //        break;
                    //    case "class":
                    //        list.Add(line);
                    //        break;
                    //    case "class":
                    //        list.Add(line);
                    //        break;

                    //    default:
                    //        break;
                    //}
                    list.Add(line);
                }
            }
            lines = list.ToArray();

            //string line = File.ReadLines(@"features.txt").Skip(14).Take(1).First();
           


            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.
            //StreamReader file = new StreamReader(@"features.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    // string strTest = "this is a test of word and character count.";

            //    int iWordCount = line.Split(' ').Length;
            //    int iCharacterCount = line.Length;


            //    Console.WriteLine(line);
            //    counter++;
            //}

            //file.Close();

            //// Suspend the screen.
            //Console.ReadLine();






            //int words;
            //using (var document = WordprocessingDocument.Open(fileName, false))
            //{
            //    words = (int)document.ExtendedFilePropertiesPart.Properties.Words.Text;
            //}
            // string path = @"Features.docx";
            //Path.GetExtension(path);
            //List<string> words =new List<string>();
            //string a;
            //using (var document = WordprocessingDocument.Open(path, false))
            //{
            //    words .Add( a =Convert.ToString(document.ExtendedFilePropertiesPart.Properties.Words.Text));
            //    foreach (String item in words)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //using (WordprocessingDocument document = WordprocessingDocument.Open(path, false))//WordprocessingDocument.Open(Path, false))
            //{
            //    int _wordCount;
            //    if (!int.TryParse(document.ExtendedFilePropertiesPart.Properties.Words.Text, out _wordCount))
            //    {
            //        _wordCount = -1;
            //    }
            //    foreach (Match item in Regex.Matches(document.ExtendedFilePropertiesPart.Properties.Words.Text,"f",RegexOptions.IgnoreCase))
            //    {
            //        _wordCount++;
            //    }
            //    Console.WriteLine(_wordCount);
            //}
        }


        //Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
        //Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();

        //try
        //{
        //    object fileName = @"C:\TT\change.docx";
        //doc = word.Documents.Open(ref fileName,
        //        ref missing, ref missing, ref missing, ref missing,
        //        ref missing, ref missing, ref missing, ref missing,
        //        ref missing, ref missing, ref missing, ref missing,
        //        ref missing, ref missing, ref missing);

        //    doc.Activate();

        //    int count = doc.Characters.Count;
        //int words = doc.Words.Count; ;
        //    int paragraphs = doc.Paragraphs.Count;

        //doc.Save();

        //    doc.Close(ref missing, ref missing, ref missing);
        //    word.Application.Quit(ref missing, ref missing, ref missing);
        //}
        //catch (Exception ex)
        //{
        //    doc.Close(ref missing, ref missing, ref missing);
        //    word.Application.Quit(ref missing, ref missing, ref missing);
        //}  


    }
}
