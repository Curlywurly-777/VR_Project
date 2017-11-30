using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class FoodController : MonoBehaviour {
    [SerializeField]
    List<GameObject> pieces;

    [SerializeField]
    private bool isMeat;
    private bool isCooked;

    void Start()
    {
        foreach (Transform child in transform)
        {
            pieces.Add(child.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Knife")
        {
            foreach (GameObject p in pieces)
            {
                p.GetComponent<Collider>().enabled = true;
                Physics.IgnoreCollision(p.GetComponent<Collider>(), GetComponent<Collider>());
            }
        }
    }
}
