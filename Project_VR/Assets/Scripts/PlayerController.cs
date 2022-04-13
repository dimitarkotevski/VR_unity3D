using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody Controller;
    public VirtualJoystick VirtualJoystick;

    private Transform _camTransform;

    public float MoveSpeed = 5.0f;
    public float Drag = 0.5f;
    public float TerminalRotationSpeed = 25.0f;


	void Start () {
        Controller.maxAngularVelocity = TerminalRotationSpeed;
        Controller.drag = Drag;

        _camTransform = Camera.main.transform;
    }
	
	void Update () {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        /*if (dir.magnitude > 1) {
            dir.Normalize();
        }*/


        if (VirtualJoystick.InputVector != Vector3.zero) {
            dir = VirtualJoystick.InputVector;
        }

        Vector3 rotatedDir = _camTransform.TransformDirection(dir);
        rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
        rotatedDir = rotatedDir.normalized * dir.magnitude;

        Controller.MovePosition(transform.position+rotatedDir/5);
        
        //Controller.MovePosition(rotatedDir * MoveSpeed);
    }

}