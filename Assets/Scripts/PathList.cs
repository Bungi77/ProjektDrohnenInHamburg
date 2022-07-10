using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using PathCreation;

public class PathList : MonoBehaviour
{
    private List<VertexPath> paths = new List<VertexPath>();
    private int actualPath;

    // Start is called before the first frame update
    void Start()
    {
        actualPath = 0;
    }

    public bool PathExist{
        get { return actualPath < paths.Count;}
    }

    public void addNewPath(VertexPath path){ 
        paths.Add(path);
    }

    public void setActualPath(int actualPath){
        this.actualPath = actualPath;
    }

    public VertexPath getActualPath(){
        Contract.Requires(actualPath < paths.Count);
        return paths[actualPath];
        
    }

    public VertexPath getPath(int index) {
        Contract.Requires(index < paths.Count);
        Contract.Requires(index >= 0);
        return paths[index];
    }

    public int getSize(){
        return paths.Count;
    }

    private string pathName(){
        return "path" + (paths.Count + 1);
    }
}
