using System;
using System.Collections;
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
        private String line;
        private int counter = 0;
        private List<string> temp_word_splited_list = new List<string>();
        private List<Tuple<string, int>> wordCounted_splited = new List<Tuple<string, int>>();
        private List<string> features = new List<string>();




        public void Read_fileread()
        {
            var temp_store = new KeyValuePair<string, int>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"Francky_C_Cofeeshop.txt");
                

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        line.Split();

                        foreach (string w in line.Split())
                        {
                            if (!temp_word_splited_list.Contains(w))
                            {


                                temp_word_splited_list.Add(w);

                                counter = 1;

                                wordCounted_splited.Add(new Tuple<string, int>(w, counter));


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
                    StreamWriter sw = new StreamWriter(@"file_to_save_C.txt");

                    for (int i = 0; i < wordCounted_splited.Count(); i++)
                    {
                        sw.WriteLine(wordCounted_splited[i]);

                       

                    }
                   

                    //Close the file
                    sw.Close();
                    Insert_Features_Value(wordCounted_splited);
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
                    foreach (string item in line.Split(','))
                    {
                        features.Add(item);
                    }
                    break;
                   

                }

                //close the file
                sr.Close();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return features;

        }


        public void Insert_Features_Value(List<Tuple<string, int>> counted_features)
        {
           

            try
            {
                List<Tuple<string, int>> c = new List<Tuple<string, int>>();

                StreamWriter sw = new StreamWriter(@"file_to_save_x.txt");
              
                foreach (string f in features)
                {
                    for (int i = 0; i < counted_features.Count(); i++)
                    {
                        if (counted_features[i].Item1==f)
                        {
                            c.Add(counted_features[i]);
                            
                          
                        }
                    }
                }




                ArrayList feat_copy = new ArrayList();
                
                foreach (string st in features)
                {
                    feat_copy.Add(st);
                }

                for (int i = 0; i < feat_copy.Count; i++)
               
                {
                    string temp = feat_copy[i].ToString();
                    for (int j = 0; j < c.Count; j++)
                    {
                       
                        if(feat_copy[i].ToString() == c[j].Item1)
                        
                        {
                            feat_copy.Insert(feat_copy.IndexOf(temp), c[j].Item2);
                            feat_copy.Remove(temp);
                          
                            
                        }

                    }

                    if (feat_copy.Contains(temp))
                    { 
                        feat_copy.Insert(feat_copy.IndexOf(temp), 0);
                        feat_copy.Remove(temp);
                        temp = null;
                    }

                }

                foreach (int val in feat_copy)
                {
                    sw.Write(val);
                }
                
                sw.Close();

                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //return features;

        }



    }
}
