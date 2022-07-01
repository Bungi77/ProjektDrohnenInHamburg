using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Collections.Generic;
using static PathList;

public class PathBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject drone;

    public GameObject ga;

    private List<Vector3> creation = new List<Vector3>();

    private PathList pathList = new PathList();
    private PathCreator pathCreator = new PathCreator();
    private EndOfPathInstruction end;
    private VertexPath path;
    private bool runDemo = false;
    private float dstTravelled = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> creation = new List<Vector3>();   
        ga  = GameObject.Find("referencePointForPathBuilder");
    }

    // Update is called once per frame
    void Update()
    {
        if(wantToCreateNewPathPoint()){
            addActualPositionToPath();
        }
        finishedWithCreation();
        if(runDemo){
            startDemo();
        }
    }

    private bool wantToCreateNewPathPoint(){
        return Input.GetKeyDown(KeyCode.Space) && !runDemo;
    }

    private void generatePath(){
        BezierPath bezierPath = new BezierPath(creation, false, PathSpace.xyz);
        print(bezierPath);
        path = new VertexPath(bezierPath,ga.transform);
    }

    private void finishedWithCreation(){
       if(Input.GetKeyDown(KeyCode.F)){
            addActualPositionToPath();
            //pathList.addNewPath(generatePath());
            generatePath();
            runDemo = true;
       }
    }

    private void addActualPositionToPath(){
        creation.Add(drone.transform.position);
        print(drone.transform.position);
    }

    private void startDemo(){
        dstTravelled += 100f * Time.deltaTime;
        transform.position = path.GetPointAtDistance(dstTravelled, end);
        print(path.GetPointAtDistance(dstTravelled, end));
    }

    private void OnPathChanged() {
            dstTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
