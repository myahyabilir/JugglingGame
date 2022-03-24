using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public int count;
    private int newCount;
    [SerializeField] float rotationSpeed;
    [SerializeField] float radius = 4f;


    private float newRadius;

    // Start is called before the first frame update
    void Start()
    {
        newCount = count;
        newRadius = radius;
        instantiateInCircle(GameObject.CreatePrimitive(PrimitiveType.Sphere), new Vector3(0, 0, 0), count);
        transform.position = new Vector3(0, radius, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(count != newCount){
            destroyChildren();
            instantiateInCircle(GameObject.CreatePrimitive(PrimitiveType.Sphere), new Vector3(0, 0, 0), count);
            newCount = count;
        }


        radius += Input.GetAxis("Vertical") * 0.1f; //5
        if(radius <= 4){ 
            radius = 4;
        }
        if(radius >= 10){
            radius = 10;
        } 

        if(radius != newRadius){
            transform.position = new Vector3(0, radius,0);
            newRadius = radius;
            Debug.Log(newRadius);
        }



        int childCount = 0;
        foreach(Transform child in transform){
            float angle = childCount * Mathf.PI*2f / count;


            Vector3 newLoc = radius * Vector3.Normalize(child.transform.position - transform.position) + transform.position;
            child.transform.position = newLoc;
            child.transform.RotateAround(transform.position, new Vector3(1,0,0), rotationSpeed * Time.deltaTime);
            childCount++;
        }
    }

    public void instantiateInCircle(GameObject obj, Vector3 location, int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {

            float angle = i * Mathf.PI*2f / howMany;
            Vector3 newPos = new Vector3(0, Mathf.Cos(angle)*radius+transform.position.y , Mathf.Sin(angle)*radius);
            GameObject go = Instantiate(obj, newPos, Quaternion.identity);
            go.AddComponent<sphereOnClick>();
            go.AddComponent<Rigidbody>();
            go.transform.SetParent(transform);

            if(i == howMany-1){
                Destroy(obj.gameObject);
            }
        }
        
    }

    public void destroyChildren(){
        int i = 0;
        GameObject[] allChildren = new GameObject[transform.childCount];

        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }
    }
}
