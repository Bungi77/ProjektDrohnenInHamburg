using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using PathCreation;

public class PathList : MonoBehaviour
{
    //private Dictionary<string, VertexPath> paths;
    private List<VertexPath> paths = new List<VertexPath>();
    private int actualPath;

    // Start is called before the first frame update
    void Start()
    {
        //paths = new Dictionary<string, VertexPath>();
        actualPath = 0;
    }

    public bool PathExist{
        get { return actualPath < paths.Count;}
    }

    public void addNewPath(VertexPath path){ // Umaendern in Map mit Namen der vom User beim erstellen gesetzt werden kann und eine Liste von Vector3 enthaelt 
        paths.Insert(paths.Count, path);
    }

    public void setActualPath(int actualPath){
        this.actualPath = actualPath;
    }

    public VertexPath getActualPath(){
        Contract.Requires(actualPath < paths.Count);
        return paths[actualPath];
        
    }

    private string pathName(){
        return "path" + (paths.Count + 1);
    } 
}
