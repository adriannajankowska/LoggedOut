using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField]
    private bool _enable = true;

    [SerializeField, Range(0, 0.1f)]
    private float _amplitude = 0.015f;

    [SerializeField, Range(0, 30)]
    private float _frequency = 10.0f;

    [SerializeField]
    private Transform _camera = null;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPosition;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _startPosition = _camera.localPosition;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;

        if (speed < _toggleSpeed) return;
        //if (!_controller.isGrounded) return;

    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
