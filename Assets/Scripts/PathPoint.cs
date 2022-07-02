using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    private GameObject pathPointObj;

    private Vector3 position;
    private int belongToPath;

    public PathPoint(){ // Veraenderung der einzelnen Punkte moeglich 
        pathPointObj = GameObject.Find("pathPoint");
    }

    // Start is called before the first frame update
    public void newPathPoint(Vector3 dronPos){
        position = dronPos;
        Instantiate(pathPointObj, position, Quaternion.identity);
    }
}
