using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Camera _camera;
    private void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.transform.forward);
    }
}
