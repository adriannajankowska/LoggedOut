using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    public GameObject gameObject;
    public int numberOfDuplicates;
    public float translateByX;
    public float translateByY;
    public float translateByZ;


    void Start()
    {
        for (var i = 0; i < numberOfDuplicates; i++)
        {
            Instantiate(gameObject, new Vector3(gameObject.transform.position.x+translateByX*(i+1), gameObject.transform.position.y+translateByY*(i + 1), gameObject.transform.position.z+translateByZ*(i + 1)), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
