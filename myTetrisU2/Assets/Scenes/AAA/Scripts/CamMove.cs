///
/// http://jibransyed.wordpress.com/2013/02/22/rotating-panning-and-zooming-a-camera-in-unity/
/// 
using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour 
{
    Camera cam;

    void Start()
    {
	  //cam = GameObject.Find("Camera").GetComponent<Camera>();
		cam = GetComponent<Camera>();
    }


    public float turnSpeed = 0.5f; // Speed of camera turning when mouse moves in along an axis
	public float panSpeed  = 0.1f; // Speed of the camera when being panned
	public float zoomSpeed = 0.1f; // Speed of the camera going back and forth
	
	private Vector3 mouseOrigin;// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isRotating;	// Is the camera being rotated?
	private bool isZooming;		// Is the camera zooming?

	
	void Update () 
	{
		// Get the left mouse button
		if(Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating  = true;
		}
		
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning   = true;
		}
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming   = true;
		}
		
		// Disable movements on button release
		if (!Input.GetMouseButton(0)) isRotating = false;
		if (!Input.GetMouseButton(1)) isPanning  = false;
		if (!Input.GetMouseButton(2)) isZooming  = false;
		
		// Rotate camera along X and Y axis
		if (isRotating)
		{
	        Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}
		
		// Move the camera on it's XY plane
		if (isPanning)
		{
	        	Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

	        	Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
	        	transform.Translate(move, Space.Self);
		}
		
		// Move the camera linearly along Z axis
		if (isZooming)
		{
			Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = pos.y * zoomSpeed * transform.forward;

			if (transform.position.z > -30 &&
                transform.position.x > -30 &&
                transform.position.y > -30 &&
                move.z <= 0
                )
				
				transform.Translate(move, Space.World);

            if (transform.position.z < -5 &&
                transform.position.x < 30 &&
                transform.position.y < 30 &&
                move.z > 0
                )

                transform.Translate(move, Space.World);
        }
	}
}