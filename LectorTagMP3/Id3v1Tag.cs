namespace Tag
{
    public class Id3v1Tag
    {
        private string titulo=string.Empty;
        public string Titulo
        {
            get{ return titulo; }
            set { titulo = value; }
         }
        private string artista=string.Empty;
        public string Artista
        {
            get { return artista; }
            set{ artista = value; }
         }
        private string album = string.Empty;
        public string Album
        {
            get { return album; }
            set{ album = value; }
         }
        private string anio;
        public string Anio
        {
            get { return anio; }
            set { anio = value; }
         }
        public Id3v1Tag(string titulo, string artista, string anio)
        {
            this.titulo = titulo;
            this.artista = artista;
            this.anio = anio;
        }
    }

}
