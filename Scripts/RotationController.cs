using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public enum rotationDirection {left, right, up, vertical, down};
    public rotationDirection rotationAxis;

    [Range(0, 100)]
    public int rotationPace;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rotationAxis == rotationDirection.left)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotationPace);
        }
        else if (rotationAxis == rotationDirection.right)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotationPace);
        }
        else if (rotationAxis == rotationDirection.up)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationPace);
        }
        else if (rotationAxis == rotationDirection.vertical)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        }
        else
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotationPace);
        }
    }
}
