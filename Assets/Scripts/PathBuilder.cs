using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Collections.Generic;
using static PathList;

public class PathBuilder : MonoBehaviour
{
    [SerializeField] 
    private int actualPath;


    private GameObject drone;
    private GameObject referencePointPathBuilder;

    private List<Vector3> pathCreation = new List<Vector3>();

    private PathList pathList = new PathList();
    private PathPoint pathPoint;
    private PathCreator pathCreator = new PathCreator();
    private EndOfPathInstruction end;
    private bool runDemo;
    private float dstTravelled = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> pathCreation = new List<Vector3>();   
        pathPoint = new PathPoint();
        pathList.setActualPath(actualPath);
        referencePointPathBuilder  = GameObject.Find("referencePointPathBuilder");
        drone = GameObject.Find("dron_2_body_root");
        runDemo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(wantToCreateNewPathPoint()){
            addActualPositionToPath();
            createPathPoint();
        }
        if(wantToAddPath()){
            addPathToPathList();
        }
        handleDemo();
        if(runDemo){
            startDemo();
        }
    }

    private bool wantToCreateNewPathPoint(){
        return Input.GetKeyDown(KeyCode.Space) && !runDemo;
    }

    private void addActualPositionToPath(){
        pathCreation.Add(drone.transform.position); // Path runner auslagern 
        print(drone.transform.position); // Klassen uebergreifender Zugriff auf die Path list 
    }

    private void createPathPoint(){
        pathPoint.newPathPoint(transform.position);
    }

    private void addPathToPathList(){
        addActualPositionToPath();
        pathList.addNewPath(generatePath());
    }

    private VertexPath generatePath(){
        BezierPath bezierPath = new BezierPath(pathCreation, false, PathSpace.xyz);
        print(bezierPath);
        return new VertexPath(bezierPath,referencePointPathBuilder.transform);
    }

    private bool wantToAddPath(){
        return Input.GetKeyDown(KeyCode.Z);
    }


    private void handleDemo(){
        wantToStartDemo();
        wantToStopDemo();
    }

    private void wantToStartDemo(){
        if(Input.GetKeyDown(KeyCode.F)){
            runDemo = true;
        }
    }

    private void wantToStopDemo(){
        if(Input.GetKeyDown(KeyCode.P)){
            runDemo = false;
        }
    }

    private void startDemo(){
        if(pathList.PathExist){
            VertexPath path = getActualPath();
            dstTravelled += 80f * Time.deltaTime;
            transform.position = path.GetPointAtDistance(dstTravelled, end);
            print(path.GetPointAtDistance(dstTravelled, end));
        }else{
            runDemo = false;
        }
    }

    private VertexPath getActualPath(){
        return pathList.getActualPath();
    }
}
