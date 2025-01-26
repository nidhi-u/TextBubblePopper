using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIn_range : MonoBehaviour
{
    
    [SerializeField] Camera _camera;

    private void OnTriggerEnter(Collider other)
    {
        _camera.orthographicSize = 4;
    }
    private void OnTriggerExit(Collider other)
    {
        _camera.orthographicSize = 8.7f;
    }
}
