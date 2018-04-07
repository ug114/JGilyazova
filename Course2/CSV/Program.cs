using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Data;

namespace CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("HTML.html"))
            {
                using (StreamReader reader = new StreamReader("CSV.txt"))
                {
                    writer.WriteLine("<table>");
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine("\t<tr>");
                        string[] rowDetails;
                        
                        rowDetails = currentLine.Split(',');

                        foreach (string detail in rowDetails)
                        {
                            writer.WriteLine("\t\t<td>" + detail + "</td>");
                        }

                        writer.WriteLine("\t</tr>");
                    }

                    writer.WriteLine("</table>");
                }
            }
        }
    }
}
