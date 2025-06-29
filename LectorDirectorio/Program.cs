// See https://aka.ms/new-console-template for more information

string? path;
string[] directorio;
string[] archivos;
string path_build = Directory.GetCurrentDirectory();
string? path_relativo = Directory.GetParent(path_build)?.Parent?.Parent?.FullName;
string path_archivo_csv = path_relativo + "\\";
List<string> datos = new List<string>();
string dato;
if (path_relativo == null)
{
    Console.WriteLine("No se pudo determinar el directorio relativo.");
    return;
}
string fullPath = path_relativo + "\\reporte_archivos.csv";
long tamanio;
DateTime ultima_modificacion;
path = path_relativo + "\\reporte_archivos.csv";
if (!File.Exists(path))
{
    File.Create(path).Close();
}
do
{
    Console.WriteLine("Ingresar un directorio para analizar:");
    path = Console.ReadLine();
    if (!Directory.Exists(path))
    {
        System.Console.WriteLine("Ingresar un directorio Valido");
    }
} while (!Directory.Exists(path));
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
    using (StreamWriter writer = new StreamWriter(fullPath))
    {
        foreach (var file in archivos)
        {
            FileInfo info = new FileInfo(fullPath);
            tamanio = info.Length / 1000;
            dato = Path.GetFileName(file) + ";" + tamanio; // Hay que probar si anda el string dato de la lista datos
            datos.Add(dato);
            ultima_modificacion = info.LastWriteTime;
            Console.WriteLine("Nombre:{0}, peso del archivo: {1} kilobytes, ultima modificacion : {2}", Path.GetFileName(file), tamanio, ultima_modificacion);
            writer.WriteLine(Path.GetFileName(file) + ";" + tamanio + ";" + ultima_modificacion);
        }
    }    
}
else
{
    Console.WriteLine("Directorio no valido");
}



/*     var archivo_csv=File.ReadAllText(fullPath);
    File.OpenWrite(fullPath); */


