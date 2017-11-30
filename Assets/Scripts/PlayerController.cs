using UnityEngine;

//[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    
    private float moveSpeed = 2f;
    private float lookSpeed = 3f;
    //private float currentTlt = 0;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    private void Update ()
    {
        //Movement
        float _xMov = GetStrafe();
        float _zMov = GetWalk();
        Vector3 _movH = transform.right * _xMov;
        Vector3 _movV = transform.forward * _zMov;
        Vector3 _vel = (_movH + _movV).normalized * moveSpeed;
        motor.Move(_vel);

        //Camera
        float _xRot = GetTilt();
        Vector3 _tlt = new Vector3(-_xRot, 0f, 0f) * lookSpeed;
        motor.Tilt(_tlt);
        float _yRot = GetTurn();
        Vector3 _rot = new Vector3(0f, _yRot, 0f) * lookSpeed;
        motor.Turn(_rot);
    }

    private float GetStrafe()
    {
        //NEEDS SWAPPING FOR VR MOVEMENT
        return Input.GetAxisRaw("Strafe");
    }


    private float GetWalk()
    {
        //NEEDS SWAPPING FOR VR MOVEMENT
        return Input.GetAxisRaw("Walk");
    }

    private float GetTurn()
    {
        //NEEDS SWAPPING FOR VR MOVEMENT
        return Input.GetAxisRaw("MouseX");
    }

    private float GetTilt()
    {
        //NEEDS SWAPPING FOR VR MOVEMENT
        return Input.GetAxisRaw("MouseY");
    }
}
