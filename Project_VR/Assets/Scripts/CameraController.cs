using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1.5f;
    private float X;
    private float Y;
    private float halfScreen = Screen.width * 0.5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {



            Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            if (mouse.x < Screen.width / 2)
            {
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
                X = transform.rotation.eulerAngles.x;
                Y = transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(X, Y, 0);
                //print("Mouse is on left side of screen.");
            }

            /*if (mouse.x > Screen.width / 2)
            {
                print("Mouse is on right side of screen.");
            }*/

        }
    }
}