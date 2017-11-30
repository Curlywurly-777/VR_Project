using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 vel = Vector3.zero;
    private Vector3 trn = Vector3.zero;
    private Vector3 tlt = Vector3.zero;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Camera cam;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        PerformMove();
        PerformTurn();
        PerformTilt();
    }

    private void PerformMove() {
        if (vel != Vector3.zero)
        {
            rb.MovePosition(rb.position + vel * Time.fixedDeltaTime);
        }
    }

    private void PerformTurn() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(trn));
    }

    private void PerformTilt() {
        tlt[0] = Mathf.Clamp(tlt[0], -90, 90);
        cam.transform.localEulerAngles = tlt;
    }

    public void Move(Vector3 _vel) {
        vel = _vel;
    }

    public void Turn(Vector3 _trn) {
        trn = _trn;
    }

    public void Tilt(Vector3 _tlt) {
        tlt += _tlt;
    }
}
