using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEditor;
using Zenject;

public class JSONSaver
{
    private string prefix = ".txt";

    /// <summary>
    /// Записать в файл (путь, данные) 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="data"></param>
    public void WriteToFilestring(string fileName, string data)
    {
        string path =  GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(data);
        }

    }
    /// <summary>
    /// Прочитать файл
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        Debug.Log(path);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        Debug.Log("file not found");
        throw new System.IO.FileNotFoundException();
    }
    /// <summary>
    /// Получить абсолютный путь файла
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName + prefix;
    }
}

