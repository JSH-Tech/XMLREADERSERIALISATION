using System.Xml;

namespace XMLREADERSERIALISATION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = XmlReader.Create("C:\\Users\\abots\\source\\repos\\XMLREADERSERIALISATION\\fichier.xml");
            var personne=new Personne();

            reader.MoveToContent();
            reader.ReadStartElement("Personne");

            reader.ReadStartElement("Nom");
            personne.Nom= reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("Prenom");
            personne.Prenom=reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("DateDeNaissance");
            personne.DateDeNaissance=reader.ReadContentAsDateTime();
            reader.ReadEndElement();

            reader.ReadStartElement("Taille");
            personne.Taille=reader.ReadContentAsInt();
            reader.ReadEndElement();

            reader.ReadEndElement();

            Console.WriteLine($"{personne.Nom} {personne.Prenom} {personne.DateDeNaissance} {personne.Taille}");

            var witerSetings = new XmlWriterSettings()
            {
                Indent = true,
            };

            var writer = XmlWriter.Create("C:\\Users\\abots\\source\\repos\\XMLREADERSERIALISATION\\file.xml", witerSetings);

            writer.WriteStartElement("Personne");
            writer.WriteElementString("Nom",personne.Nom);
            writer.WriteElementString("Prenom",personne.Prenom);
            writer.WriteElementString("DateDeNaissance", personne.DateDeNaissance.ToString());
            writer.WriteElementString("Taille", personne.Taille.ToString());
            writer.WriteEndElement();
            writer.Flush();
        }
    }
}
