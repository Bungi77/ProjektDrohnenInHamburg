using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileWriter : MonoBehaviour
{
    public string path;
    public string content;
    void Start()
    {
        path = Application.dataPath + "/FlugInfo.txt";
        
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "Path log \n\n");
        }
    }

    public void writeText(string input)
    {
        File.AppendAllText(path, input);
    }
}