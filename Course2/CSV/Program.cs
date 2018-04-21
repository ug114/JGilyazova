using System;
using System.IO;

namespace CSV
{
    class Program
    {
        static void Print(string outputDocument, string inputDocument)
        {
            FileInfo inputFile = new FileInfo(inputDocument);
            
            if (!inputFile.Exists)
            {
                throw new FileNotFoundException("CSV file not found.");
            }

            using (StreamWriter writer = new StreamWriter(outputDocument))
            {
                using (StreamReader reader = new StreamReader(inputDocument))
                {
                    writer.WriteLine("<!DOCTYPE HTML>");
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine("<title>CSV to HTML</title>");
                    writer.WriteLine("<meta charset=\"utf-8\">");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body>");
                    writer.WriteLine("<table border=\"1\">");
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine("<tr>");
                        writer.Write("<td>");
                        int quotesCount = 0;
                        bool isInQuotes = false;

                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (currentLine[i] != ',' && currentLine[i] != '"' && currentLine[i] != '>' && currentLine[i] != '<' && currentLine[i] != '&')
                            {
                                writer.Write(currentLine[i]);
                            }
                            else
                            {
                                if (currentLine[i] == '"')
                                {
                                    quotesCount++;

                                    if (i < currentLine.Length - 1 && currentLine[i + 1] == '"')
                                    {
                                        writer.Write('"');
                                        i++;
                                    }

                                    if (quotesCount % 2 == 0)
                                    {
                                        isInQuotes = false;
                                    }
                                    else
                                    {
                                        isInQuotes = true;
                                    }
                                }
                                else if (currentLine[i] == '>')
                                {
                                    writer.Write("&gt;");
                                }
                                else if (currentLine[i] == '<')
                                {
                                    writer.Write("&lt;");
                                }
                                else if (currentLine[i] == '&')
                                {
                                    writer.Write("&amp;");
                                }
                                else if (currentLine[i] == ',' && isInQuotes)
                                {
                                    writer.Write(',');
                                }
                                else if (currentLine[i] == ',' && !isInQuotes)
                                {
                                    writer.WriteLine("</td>");
                                    writer.Write("<td>");
                                }
                            }

                            if (i == currentLine.Length - 1)
                            {
                                if (!isInQuotes)
                                {
                                    writer.WriteLine("</td>");
                                }
                                else
                                {
                                    if ((currentLine = reader.ReadLine()) != null)
                                    {
                                        writer.WriteLine("<br>");
                                        i = 0;
                                        writer.Write(currentLine[i]);
                                    }
                                }
                            }
                        }

                        writer.WriteLine("</tr>");
                    }

                    writer.WriteLine("</table>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }
            }
        }

        static void Main(string[] args)
        {
            string inputDocument = Path.GetFullPath("CSV.txt");
            string outputDocument = Path.GetFullPath("HTML.html");
            
            try
            {
                Print(outputDocument, inputDocument);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
