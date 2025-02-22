// See https://aka.ms/new-console-template for more information
using MyConsole;

Console.WriteLine("Hello, World!");
List<Comma> comma = FileReader.Read<Comma>("Path\\Comma.csv", ",");
List<PipeLine> pipeLine = FileReader.Read<PipeLine>("Path\\PipeLine.csv", "|");
List<At> at = FileReader.Read<At>("Path\\New Text Document.txt", "@");


string g = "";