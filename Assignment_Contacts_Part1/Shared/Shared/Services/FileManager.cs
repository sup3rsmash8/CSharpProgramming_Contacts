using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace Shared.Services;

public static class FileManager
{
    /// <summary>
    /// Saves a string to a file.
    /// </summary>
    public static void SaveToFile(string directoryPath, string fileName, string content)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        using var streamWriter = new StreamWriter($@"{directoryPath}\{fileName}", false);
        streamWriter.WriteLine(content);
    }

    /// <summary>
    /// Saves an object of type T to JSON to a file of specified path.
    /// </summary>
    public static void SaveObjectToJsonFile<T>(string directoryPath, string fileName, T content) where T : class
    {
        SaveToFile(directoryPath, fileName, JsonConvert.SerializeObject(content));
    }

    /// <summary>
    /// Reads the contents of a file. If file doesn't exist, returns null.
    /// </summary>
    public static string? ReadFromFile(string path)
    {
        if (File.Exists(path)) 
        {
            using var reader = new StreamReader(path);
            return reader.ReadToEnd();
        }
        return null;
    }

    /// <summary>
    /// Loads a json file, tries to deserialize it as an object of type T and returns the object.
    /// </summary>
    public static T? GetJsonObjectFromFile<T>(string pathToJsonFile) where T : class
    {
        try
        {
            string json = ReadFromFile(pathToJsonFile)!;
            if (json != null)
            {
                T deserializedObject = JsonConvert.DeserializeObject<T>(json)!;
                return deserializedObject;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }

        return null;
    }
}
