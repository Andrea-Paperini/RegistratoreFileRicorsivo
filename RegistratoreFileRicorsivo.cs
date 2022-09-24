using System;
using System.IO;
using System.Reflection;

namespace RegistratoreFileRicorsivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!");
            string percorsoExe = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            int numero = 0;
            string[] dischi = { @"y:\", @"z:\", @"u:\", @"v:\", @"w:\", @"x:\", @"t:\" };
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //Se il file esiste prima lo svuoto (elimino)
            if (File.Exists(path + @"\ListaFile.txt"))
            {
                File.Delete(path + @"\ListaFile.txt");
            }
            foreach (var discocorrente in dischi)
            {
                foreach (var CurrentFile in
                Directory.EnumerateFiles(discocorrente, "*", SearchOption.AllDirectories))
                {
                    FileInfo fi = new FileInfo(CurrentFile);
                    // Print the file size to console
                    //Console.WriteLine($"File size: {fi.Length} bytes");
                    //elimino i primi 3 caratteri cioè il percorso che non ci serve
                    //elimino gli ultimi 4 caratteri . e nome dell'estensione 4+ i 3 di prima 7 
                    string nomefile = Path.GetFileName(CurrentFile);
                    string nomeContenuto = nomefile.Substring(0, nomefile.Length - 4);
                    Console.WriteLine("File corrente: " + nomeContenuto);
                    File.AppendAllText(percorsoExe + @"\ListaFile.txt", nomeContenuto + Environment.NewLine);
                    numero++;
                }
                Console.WriteLine("Disco corrente -> " + discocorrente + " Ho letto e registrato " + numero + " file");
                numero = 0;
            }
            Console.ReadKey();
        }
    }
}
