// See https://aka.ms/new-console-template for more information
using Lacinizatar.Logic;

char a = 'і';
char b = 'i';
Console.WriteLine(a == b);
string filePath = @"C:\Projects\lacinizatar_test.txt";
File.Delete(filePath);
File.AppendAllText(filePath, new ToBelLatin("маці").Translate() + '\n'); 
File.AppendAllText(filePath, new ToBelLatin("тата").Translate() + '\n'); 
File.AppendAllText(filePath, new ToBelLatin("бегчы").Translate() + '\n'); 
File.AppendAllText(filePath, new ToBelLatin("ісьці").Translate() + '\n');
File.AppendAllText(filePath, new ToBelLatin("беларусы").Translate() + '\n');
