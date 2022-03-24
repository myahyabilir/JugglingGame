using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torus : MonoBehaviour
{
    Collider col;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        float yValue = col.bounds.size.y;


        float scale = transform.localScale.y;
        if(scale > 50){
            Vector3 pos = transform.position;
            float y = -2;
            float yToAdd = scale/50;
            y += yToAdd * 2.353f;
            pos.y = y;
            transform.position = pos;    
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMover = -0.5f * Time.deltaTime * -35f;

        transform.Translate(0 , 0, xMover);

    }
}
