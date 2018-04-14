using System;
using System.IO;
using System.Text;

namespace CSV
{
    class Program
    {
        static void Print(string outputDocument, string inputDocument)
        {
            FileInfo outputFile = new FileInfo(outputDocument);
            FileInfo inputFile = new FileInfo(inputDocument);
            
            if (!outputFile.Exists)
            {
                throw new FileNotFoundException("CSV file not found.");
            }
             
            if (!inputFile.Exists)
            {
                throw new FileNotFoundException("HTML file not found.");
            }

            using (StreamWriter writer = new StreamWriter(inputDocument))
            {
                using (StreamReader reader = new StreamReader(outputDocument))
                {
                    writer.WriteLine("<!DOCTYPE HTML>");
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine("<title>CSV to HTML</title>");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<table border = '1'>");
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        StringBuilder builder = new StringBuilder("<tr>\n<td>");
                        int quotesCount = 0;
                        int doubleQuotesCount = 0;

                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (currentLine[i] == '"')
                            {
                                if (i < currentLine.Length - 1 && currentLine[i + 1] == '"')
                                {
                                    i++;
                                    doubleQuotesCount++;
                                    builder.Append('"');
                                }
                                else
                                {
                                    quotesCount++;
                                }
                            }

                            if (currentLine[i] == '>')
                            {
                                builder.Append("&gt");
                            }

                            if (currentLine[i] == '<')
                            {
                                builder.Append("&lt");
                            }

                            if (currentLine[i] == '&')
                            {
                                builder.Append("&amp");
                            }

                            if (currentLine[i] == ',' && quotesCount % 2 == 1)
                            {
                                builder.Append(',');
                            }

                            if (currentLine[i] == ',' && quotesCount % 2 == 0)
                            {
                                builder.Append("</td>\n<td>");
                            }

                            if (currentLine[i] != ',' && currentLine[i] != '"' && currentLine[i] != '>' && currentLine[i] != '<' && currentLine[i] != '&')
                            {
                                builder.Append(currentLine[i]);
                            }

                            if (i == currentLine.Length - 1 && quotesCount % 2 == 0)
                            {
                                builder.Append("</td>");
                            }
                            else if (i == currentLine.Length - 1 && quotesCount % 2 == 1)
                            {
                                if ((currentLine = reader.ReadLine()) != null)
                                {
                                    builder.Append("<br>\n");
                                    i = 0;
                                    builder.Append(currentLine[i]);
                                }
                            }
                        }

                        writer.WriteLine(builder.Append("\n</tr>").ToString());
                    }

                    writer.WriteLine("</table>");
                    writer.WriteLine("</html>");
                }
            }
        }

        static void Main(string[] args)
        {
            string inputDocument = "HTML.html";
            string outputDocument = "CSV.txt";

            try
            {
                Print(outputDocument, inputDocument);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
