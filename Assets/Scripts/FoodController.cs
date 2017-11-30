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
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length-1];
        int i = 0;

        foreach (Transform child in transform)
        {
            pieces.Add(child.gameObject);
            if (meshFilters[i].sharedMesh == null) continue;
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i++].transform = meshFilters[i].transform.localToWorldMatrix;
        }
        if (combine == null)
        {
            Debug.Log("what");
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
       

        for (var i = 0; i < meshFilters.Length; i++)
        {
        }

        GetComponent(MeshFilter).mesh = new Mesh();
        GetComponent(MeshFilter).mesh.CombineMeshes(combine);

        GetComponent(MeshCollider).sharedMesh = GetComponent(MeshFilter).mesh;

        renderer.material = meshFilters[1].renderer.sharedMaterial;
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
