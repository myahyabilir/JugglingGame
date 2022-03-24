using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereOnClick : MonoBehaviour
{
    public GameObject empty;
    private sphere sphere;
    private SphereCollider col;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
/*         col = GetComponent<SphereCollider>();
        col.isTrigger = true; */
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

/*     private void OnMouseDown() {
        empty = transform.parent.gameObject;
        sphere = empty.GetComponent<sphere>();
        sphere.count -= 1;
        Debug.Log("clicked");
    } */

    void OnCollisionEnter(Collision other) {
        empty = transform.parent.gameObject;
        sphere = empty.GetComponent<sphere>();
        sphere.count -= 1;
        Debug.Log("clicked");
    }

    
}
