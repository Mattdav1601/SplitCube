using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

public class FileManager
{
    public static void SaveData<T>(T toSave, string filePath)
    {
        // Open the file, creating it if necessary.
        FileStream stream = File.Open(filePath, FileMode.Create);

        // Convert the object to XML data and put it in the stream.
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stream, toSave);

        // Close the file.
        stream.Close();
    }

    public static T LoadData<T>(string filePath)
    {
        // Check to see whether the save exists.
        // Open the file.
        FileStream stream = File.Open(filePath, FileMode.Open,
            FileAccess.Read);

        // Read the data from the file.
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        T data = (T)serializer.Deserialize(stream);

        // Close the file.
        stream.Close();
                        
        return data;
    }
}