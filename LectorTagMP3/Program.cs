
using System.Text;
using Tag;

string path_build = Directory.GetCurrentDirectory();
string? path_relativo = Directory.GetParent(path_build)?.Parent?.Parent?.FullName;
string path_archivo = path_relativo + "\\prueba.mp3";
long offset;
byte[] arreglo_Bytes = new byte[2048];
int bytes_leidos = 0;
Id3v1Tag tag = new Id3v1Tag(string.Empty, string.Empty, string.Empty);
Encoding latin1 = Encoding.Latin1;
string contenido = string.Empty;
do
{
    Console.WriteLine("Ingresar el directorio del archivo llamado 'prueba' a analizar:");
    path_archivo = Console.ReadLine();
    if (!Directory.Exists(path_archivo))
    {
        System.Console.WriteLine("Ingresar un directorio Valido");
    }
} while (!Directory.Exists(path_archivo));
path_archivo = path_archivo + "\\prueba.mp3";
if (path_archivo == null)
{
    Console.WriteLine("El path del archivo es nulo. No se puede continuar.");
    return;
}

using (FileStream reader = new FileStream(path_archivo, FileMode.Open, FileAccess.Read))
{
    offset = reader.Seek(-128, SeekOrigin.End);
    reader.Read(arreglo_Bytes, 0, 3);
    bytes_leidos=reader.Read(arreglo_Bytes, 0, 30);
    contenido = latin1.GetString(arreglo_Bytes, 0, bytes_leidos).TrimEnd('\0');
    tag.Titulo = contenido;

    bytes_leidos = reader.Read(arreglo_Bytes,0, 30);
    contenido = latin1.GetString(arreglo_Bytes, 0, bytes_leidos).TrimEnd('\0');
    tag.Artista = contenido;

    bytes_leidos = reader.Read(arreglo_Bytes, 0, 30);
    contenido = latin1.GetString(arreglo_Bytes, 0, bytes_leidos).TrimEnd('\0');
    tag.Album = contenido;


    bytes_leidos = reader.Read(arreglo_Bytes, 0, 4);
    contenido = latin1.GetString(arreglo_Bytes, 0, bytes_leidos).TrimEnd('\0');
    tag.Anio = contenido;
}
Console.WriteLine($"Del tag se leyo, titulo:{tag.Titulo},Artista: {tag.Artista}, Album : {tag.Album}, año : {tag.Anio}");
