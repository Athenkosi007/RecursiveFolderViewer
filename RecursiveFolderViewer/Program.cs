using System;
using System.Collections.Generic;

namespace RecursiveFolderViewer
{
    // File class
    public class FileItem
    {
        public string Name { get; set; }
        public int SizeKB { get; set; }

        public void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}📄 {Name} - {SizeKB} KB");
        }
    }

    // Folder class (recursive structure)
    public class Folder
    {
        public string Name { get; set; }
        public List<FileItem> Files { get; set; } = new List<FileItem>();
        public List<Folder> Subfolders { get; set; } = new List<Folder>();

        public void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}📁 {Name}");

            foreach (var file in Files)
                file.Display(indent + 2);

            foreach (var subfolder in Subfolders)
                subfolder.Display(indent + 2); // recursion here
        }
    }

    // Main Program
    public class Program
    {
        public static void Main()
        {
            Folder root = new Folder { Name = "Root" };

            // Add top-level files
            root.Files.Add(new FileItem { Name = "readme.txt", SizeKB = 12 });
            root.Files.Add(new FileItem { Name = "config.json", SizeKB = 4 });

            // Documents folder
            Folder documents = new Folder { Name = "Documents" };
            documents.Files.Add(new FileItem { Name = "resume.docx", SizeKB = 120 });
            documents.Files.Add(new FileItem { Name = "coverletter.docx", SizeKB = 98 });

            // Nested Pictures folder inside Documents
            Folder pictures = new Folder { Name = "Pictures" };
            pictures.Files.Add(new FileItem { Name = "vacation.jpg", SizeKB = 2048 });

            // Add Pictures to Documents
            documents.Subfolders.Add(pictures);

            // Add Documents to Root
            root.Subfolders.Add(documents);

            // Display structure
            root.Display();

            Console.ReadLine();
        }
    }
}
