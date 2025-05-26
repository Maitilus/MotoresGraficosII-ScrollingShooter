using System.Xml.Serialization;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    private Camera Cam;

    void Start()
    {
        //Get Camera
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        //Hide and lock cursor to window
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        //Move Crosshair with cursor and rotate to camera
        transform.position = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 22));
        transform.rotation = Cam.transform.rotation;
    }
}
