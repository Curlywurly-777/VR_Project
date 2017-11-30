using UnityEngine;

public class SliceController : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Knife")
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            
        }
    }
}
