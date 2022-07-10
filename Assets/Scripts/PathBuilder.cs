using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using static PathList;

public class PathBuilder : MonoBehaviour
{
    [SerializeField]
    private int actualPath;


    private GameObject drone;
    private GameObject referencePointPathBuilder;

    private List<PathPoint> pathCreation = new List<PathPoint>();

    private PathList pathList = new PathList();
    private EndOfPathInstruction end;
    private bool runDemo;
    private float dstTravelled = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> pathCreation = new List<Vector3>();
        pathList.setActualPath(actualPath);
        referencePointPathBuilder = GameObject.Find("referencePointPathBuilder");
        drone = GameObject.Find("dron_2_body_root");
        runDemo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wantToCreateNewPathPoint())
        {
            addActualPositionToPath(false);
        }
        if (wantToAddPath())
        {
            addPathToPathList();
        }
        if (wantToDeleteLastPoint())
        {
            delteLastPathPoint();
        }
        handleDemo();
        if (runDemo)
        {
            startDemo();
        }
    }

    private bool wantToCreateNewPathPoint()
    {
        return Input.GetKeyDown(KeyCode.Space) && !runDemo;
    }

    private void addActualPositionToPath(bool endPoint)
    {
        if (pathCreation.Count == 0)
        {
            pathCreation.Add(createPathPoint(true, false));
        }
        else if (endPoint)
        {
            pathCreation.Add(createPathPoint(false, endPoint));
        }
        else
        {
            pathCreation.Add(createPathPoint(false, false));
        }
        print(drone.transform.position); // Klassen uebergreifender Zugriff auf die Path list 
    }

    private PathPoint createPathPoint(bool startPoint, bool endPoint)
    {
        if (startPoint)
        {
            return new PathPoint(drone.transform.position, startPoint, endPoint);
        }
        if (endPoint)
        {
            return new PathPoint(drone.transform.position, startPoint, endPoint);
        }
        return new PathPoint(drone.transform.position, startPoint, endPoint);
    }

    private void addPathToPathList()
    {
        addActualPositionToPath(true);
        pathList.addNewPath(generatePath());
        pathCreation = new List<PathPoint>();
    }

    private VertexPath generatePath()
    {
        BezierPath bezierPath = new BezierPath(generateListOfPositions(), false, PathSpace.xyz);
        print(bezierPath);
        return new VertexPath(bezierPath, referencePointPathBuilder.transform);
    }

    private List<Vector3> generateListOfPositions()
    {
        List<Vector3> position = new List<Vector3>();
        for (int i = 0; i < pathCreation.Count; i++)
        {
            position.Add(pathCreation[i].getPathPointPosition());
        }

        return position;
    }

    private bool wantToAddPath()
    {
        return Input.GetKeyDown(KeyCode.F);
    }


    private void handleDemo()
    {
        wantToStartDemo();
        wantToStopDemo();
    }

    private void wantToStartDemo()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            runDemo = true;
        }
    }

    private void wantToStopDemo()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            runDemo = false;
        }
    }

    private bool wantToDeleteLastPoint()
    {
        return Input.GetKeyDown(KeyCode.T);
    }

    private void delteLastPathPoint()
    {
        pathCreation[pathCreation.Count - 1].getPathPointObject().SetActive(false);
        pathCreation.RemoveAt(pathCreation.Count - 1);
    }

    private void startDemo()
    {
        if (pathList.PathExist)
        {
            VertexPath path = getActualPath();
            dstTravelled += 70f * Time.deltaTime;
            transform.position = path.GetPointAtDistance(dstTravelled, end);
            print(path.GetPointAtDistance(dstTravelled, end));
        }
        else
        {
            runDemo = false;
        }
    }

    private VertexPath getActualPath()
    {
        return pathList.getActualPath();
    }
}
