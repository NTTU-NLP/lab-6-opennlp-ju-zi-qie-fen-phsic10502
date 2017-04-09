using opennlp.tools.sentdetect;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static SentenceDetector detector;

        static void lab5(String src)
        {
            StreamReader input = new StreamReader(src);
            StreamWriter output = new StreamWriter(Regex.Replace(src, "(.*).txt", "$1_Sent.txt"));
            while (input.Peek() != -1)
            {
                string dataLine = input.ReadLine();
                string[] sents = detector.sentDetect(dataLine);
                for (int i = 0; i < sents.Length; i++)
                    output.WriteLine(sents.GetValue(i));
                output.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            java.io.InputStream model_src = new java.io.FileInputStream(@"..\..\en-sent.bin");
            SentenceModel smodel = new SentenceModel(model_src);
            detector = new SentenceDetectorME(smodel);

            foreach (String src in Directory.GetFiles(@"..\..\..\..\Dataset"))
                lab5(src);
        }
    }
}
