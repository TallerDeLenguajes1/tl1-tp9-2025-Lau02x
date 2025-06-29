// See https://aka.ms/new-console-template for more information
string? path;
string[] directorio;
string[] archivos;
string path_relativo= Directory.GetCurrentDirectory();
string fullPath = path_relativo + "\\datos.csv";
long tamanio;

do
{
    Console.WriteLine("Ingresar un directorio para analizar:");
    path = Console.ReadLine();
} while (Directory.Exists(path));
if (Directory.Exists(path))
{
    directorio = Directory.GetDirectories(path);
    Console.WriteLine("Carpetas del directorio:");
    foreach (var item in directorio)
    {
        Console.WriteLine(item);
    }
    archivos = Directory.GetFiles(path);
    Console.WriteLine("Archivos del directorio:");
    foreach (var file in archivos)
    {
        var info = new FileInfo(file);
        tamanio = info.Length / 1000;
        Console.WriteLine("Nombre:{0}, peso del archivo: {1} kilobytes", Path.GetFileName(file), tamanio);
    }
}
else
{
    Console.WriteLine("Directorio no valido");
}

var archivo_csv=File.ReadAllText(fullPath);
File.OpenWrite(fullPath);


