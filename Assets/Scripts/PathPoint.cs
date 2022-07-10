using UnityEngine;

public class PathPoint : MonoBehaviour
{
    private GameObject pathPointObj;
    private Renderer renderer;

    public PathPoint(Vector3 dronePos, bool startPoint, bool endPoint){ // Veraenderung der einzelnen Punkte moeglich 
        pathPointObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pathPointObj.transform.position = dronePos;
        renderer = pathPointObj.GetComponent<Renderer>();
        decideColour(startPoint, endPoint);
        
    }

    // Start is called before the first frame update
    public Vector3 getPathPointPosition() {
        return pathPointObj.transform.position;
    }

    public GameObject getPathPointObject() {
        return pathPointObj;
    }

    private void decideColour(bool startPoint, bool endPoint){
        if (startPoint){
            renderer.material.color = Color.green;
        }
        else if (endPoint){
            renderer.material.color = Color.red;
        } else{
            renderer.material.color = Color.magenta;
        }
    }
}
