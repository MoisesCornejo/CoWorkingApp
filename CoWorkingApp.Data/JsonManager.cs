using Newtonsoft.Json;

namespace CoWorkingApp.Data;

// clase JsonManager al cual se le pasara un tipo generic T para que acepte cualquier tipo de dato
// estos datos de las clases se guardaran en un json (User, Desk y Reservation)
public class JsonManager<T>
{
    // metodo para obtener la lista de datos
    public List<T> GetCollection()
    {
        // ruta donde se crear donde se leeran y guardaran los archivos json
        var collectionPath = $"{Directory.GetCurrentDirectory()}//{typeof(T)}.json";

        // coleccion temporal de los elementos
        var myCollection = new List<T>();
        
        // condicional si el archivo existe lo lea
        if (File.Exists(collectionPath))
        {
            // leemos el archivo json
            var streamReader = new StreamReader(collectionPath);
            // lectura de datos hasta el final
            var currentContent = streamReader.ReadToEnd();
            // transformacion de el string al tipo de dato generic T
            // instalamos el nuget Newtonsoft.Json para trabajar con json
            // convertimos el contenido del archivo json a la coleccion temporal
            myCollection = JsonConvert.DeserializeObject<List<T>>(currentContent);
            // cerramos el archivo
            streamReader.Close();
        }
        else
        {
            // convertimos la coleccion temporal en json
            var jsonCollection = JsonConvert.SerializeObject(myCollection);
            // si no existe el archivo json lo creamos para utilizarlo
            var streamWriter = new StreamWriter(collectionPath);
            // escribimos el contenido en el archivo json
            streamWriter.WriteLine(jsonCollection);
            // cerramos el archivo
            streamWriter.Close();
        }
        return myCollection;
    }

    public bool SaveCollection(List<T> collection)
    {
        // ruta donde se guardara
        var collectionPath = $"{Directory.GetCurrentDirectory()}//{typeof(T)}.json";

        try
        {
            var jsonCollection = JsonConvert.SerializeObject(collection);
            var streamWriter = new StreamWriter(collectionPath);
            streamWriter.WriteLine(jsonCollection);
            streamWriter.Close();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}