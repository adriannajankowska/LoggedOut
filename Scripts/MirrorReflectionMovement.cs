using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflectionMovement : MonoBehaviour
{
    public Transform playerTarget;
    public Transform mirror;
    private Transform spawnTransform;
    private GameObject sphere;

    private void Start()
    {
        
        //Debug.Log("Player position: " + playerTarget.position);
        //Debug.Log("Inversed Transform Point: " + localPlayer);

        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        
    }
    void Update()
    {
        //Vector3 localPlayer = mirror.InverseTransformPoint(playerTarget.position);
        sphere.transform.position = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, -playerTarget.transform.position.z);
        transform.LookAt(sphere.transform);

        //transform.position = mirror.TransformPoint(new Vector3(localPlayer.x, localPlayer.y, -localPlayer.z));

        //Vector3 lookAtMirror = mirror.TransformPoint(new Vector3(-localPlayer.x, localPlayer.y, localPlayer.z));
        //transform.LookAt(playerTarget);

        ////Set the virtual camera's position and rotaion to the player camera
        //m_MirrorCamera.transform.position = playerTarget.transform.position;
        //m_MirrorCamera.transform.rotation = Quaternion.Euler(playerTarget.transform.rotation.eulerAngles.x, playerTarget.transform.rotation.eulerAngles.y, m_MirrorCamera.transform.rotation.eulerAngles.z);
        //transform.position = playerTarget.transform.position;
        //transform.rotation = Quaternion.Euler(playerTarget.transform.rotation.eulerAngles.x, playerTarget.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        //transform.SetPositionAndRotation((playerTarget.transform.position, playerTarget.transform.rotation);
    }
}
