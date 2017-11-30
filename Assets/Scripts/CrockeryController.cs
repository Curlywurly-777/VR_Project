using UnityEngine;

public class CrockeryController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "food")
        {

        }
    }
}
