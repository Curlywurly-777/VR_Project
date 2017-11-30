using UnityEngine;
using UnityEngine.Collections;
using System.Collections.Generic;

public class SliceController : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Knife")
        {
            GetComponent<Rigidbody>().isKinematic = false;

            List<Transform> preCut = new List<Transform>(); // everything in the object's parent's child list 'before' the cut
            List<Transform> postCut = new List<Transform>(); // everything in the object's parent's child list 'after' the cut

            bool reachedCutSegment = false; // flag that tells me that we have reached the point in the object that this transform resides at
            
            for (int i = 0; i<transform.parent.childCount; i++)
            {

                Transform t = transform.parent.GetChild(i);

                if(t.transform == this.transform) { reachedCutSegment = true; }

                if (!reachedCutSegment)
                {
                    preCut.Add(t);
                }
                else
                {
                    postCut.Add(t);
                }

            }

            GameObject leftSideOfObject = new GameObject();
            leftSideOfObject.name = transform.parent.name + " left";

            GameObject rightSideOfObject = new GameObject();
            rightSideOfObject.name = transform.parent.name + " right";

            foreach(Transform t in preCut)
            {
                t.parent = leftSideOfObject.transform;
            }

            foreach (Transform t in postCut)
            {
                t.parent = rightSideOfObject.transform;
            }

        }
    }
}
