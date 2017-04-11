using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingFolder_App
{
    class ReadFromFile
    {
        String line;
        int counter = 0;
        List<string> temp_word_splited_list = new List<string>();
        List<Tuple<string, int>> wordCounted_splited = new List<Tuple<string, int>>();

        
        
        public  void Read_fileread()
        {
            var temp_store = new KeyValuePair<string, int>();
            
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"file_to_read.txt");
                //StreamReader sr = new StreamReader(@"C:\Users\Beheerders\Desktop\Plagiarisme\ReadingFiles\ReadingFolder_App\ReadingFolder_App");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                    if (line != null) { 
                        line.Split();

                    foreach (string w in line.Split())
                    {
                        if (!temp_word_splited_list.Contains(w))
                        {
                              

                            temp_word_splited_list.Add(w);
                                
                            counter=1;
                               
                                wordCounted_splited.Add(new Tuple<string, int>(w,counter));


                            }
                        else if (temp_word_splited_list.Contains(w))
                        {
                                for (int i = 0; i < wordCounted_splited.Count(); i++)
                                {
                                    if (wordCounted_splited[i].Item1.Equals(w))
                                    {

                                        counter = wordCounted_splited[i].Item2;
                                        counter++;
                                        wordCounted_splited.RemoveAt(i);
                                        temp_store = new KeyValuePair<string, int>(w, counter);
                                        wordCounted_splited.Add(new Tuple<string, int>(temp_store.Key, temp_store.Value));
                                       
                                        break;
                                    }
                                }
                                
                            }
                            

                         
                        }
                    }
                  

                }
               
                sr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                try
                {

                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(@"file_to_save.txt");

                    for (int i = 0; i < wordCounted_splited.Count(); i++)
                    {
                         sw.WriteLine(wordCounted_splited[i]);

                        //File.AppendAllText("features.txt", sw.WriteLine(wordCounted_splited[i]) + Environment.NewLine);

                    }
                    //Write a line of text
                  // sw.WriteLine("Hello World!!");

                    //Write a second line of text
                   // sw.WriteLine("From the StreamWriter class");

                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }

            }
        }


        public List<string> ReadFeatures()
        {

            String line;
            List<string> features = new List<string>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"features.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    foreach (string item in line.Split())
                    {
                        features.Add(item);
                    }
                    //Console.WriteLine(line);
                    //Read the next line
                    
                }
               
                //close the file
                sr.Close();
                
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return features;
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");

            //}
        }



    }
}
