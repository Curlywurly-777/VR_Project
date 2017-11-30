using UnityEngine;

//[System.Serializable]
//[RequireComponent(typeof(Renderer))]
public class HandController : MonoBehaviour {

    public string iD = "handLeft";
    public float range = 0.2f;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Object;

    [SerializeField]
    private LayerMask Holdable;

    [SerializeField]
    private Rigidbody Hand;

    [SerializeField]
    private Renderer Vis;

    private void Start()
    {
    }

    private void Update()
    {
        Hand.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (Input.GetMouseButtonDown(0))
        {
            GetObject();
            Vis.enabled = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Object = null;
            Vis.enabled = true;
        }
        if (Object != null)
        {
            Object.transform.position = Hand.transform.position;
            Object.transform.rotation = Hand.transform.rotation;
        }
        else
        {
            Hand.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    private bool Grab()
    {
        // NEEDS SWAPPING FOR VR CONTROLS
        if (Input.GetMouseButton(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 GetRotation()
    {
        //NEEDS SWAPPING FOR VR CONTROLS
        if (Object.name == "Knife")
        {
            return new Vector3(90, 0, 0);
        }
        return new Vector3(0, 0, 0);
    }

    private void GetObject()
    {
        // Sends raycast, returns hit object if object is holdable
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, range, Holdable))
        {
            Debug.Log("Grabbed " + _hit.collider.name);
            Object = _hit.collider.gameObject;
        }
    }
    
}
