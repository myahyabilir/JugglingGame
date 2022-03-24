using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torusGroup : MonoBehaviour
{
    [SerializeField] int obstacleCount;
    public GameObject torusPrefab;

    // Start is called before the first frame update
    void Start()
    {
        instantiateObstacle(torusPrefab, obstacleCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateObstacle(GameObject go, int howMany){
        int xHolder = -30;
        int[] scales = {200, 250, 300, 350};
        for (int i = 0; i < howMany; i++)
        {
            int randomScale = scales[Random.Range(0, scales.Length)];

            Vector3 newPos = new Vector3(xHolder, 0 , 0);
            go = Instantiate(torusPrefab, newPos, transform.rotation * Quaternion.Euler(0f, 90f, 90f));
            go.transform.localScale = new Vector3(randomScale, randomScale, go.transform.localScale.z);
            go.AddComponent<torus>();
            go.transform.SetParent(transform);
            xHolder -= 30;
        }
    }
}
