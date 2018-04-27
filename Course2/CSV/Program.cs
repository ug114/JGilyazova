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
                    int quotesCount = 0;
                    bool isInQuotes = false;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (!isInQuotes)
                        {
                            writer.WriteLine("<tr>");
                            writer.Write("<td>");
                        }

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
                                    if (i < currentLine.Length - 1 && currentLine[i + 1] == '"')
                                    {
                                        if (isInQuotes)
                                        {
                                            i++;
                                            quotesCount++;
                                            writer.Write('"');
                                        }
                                    }

                                    quotesCount++;

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
                        }

                        if (!isInQuotes)
                        {
                            quotesCount = 0;
                            writer.WriteLine("</td>");
                            writer.WriteLine("</tr>");
                        }
                        else
                        {
                            writer.WriteLine("<br>");
                        }
                    }

                    writer.WriteLine("</table>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new ArgumentException("Введите, пожалуйста, два значения: путь к CSV файлу и путь к HTML файлу.");
                }

                string inputDocument = args[0];
                string outputDocument = args[1];

                Print(outputDocument, inputDocument);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
