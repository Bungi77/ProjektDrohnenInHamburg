using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    private GameObject pathPointObj;

    public PathPoint(){
        pathPointObj = GameObject.Find("pathPoint");
    }

    // Start is called before the first frame update
    public void newPathPoint(Vector3 dronPos){
        Instantiate(pathPointObj, dronPos, Quaternion.identity);
    }
}
