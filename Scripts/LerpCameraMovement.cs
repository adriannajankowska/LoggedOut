using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCameraMovement : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 posOffset; // this is your fixed relative position to the leader

    void Update()
    {
        Vector3 posGoTo = objectToFollow.transform.TransformPoint(posOffset); // this one you keep updating as the leader moves
        transform.position = posGoTo;
    }
}
