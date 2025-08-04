using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector3 _mouseOrigin;
    private bool _isPanning;
    private float _panningSpeed;

    private void Update()
    {
        
        
        if (Input.GetMouseButtonDown(1))
        {
            _mouseOrigin = Input.mousePosition;
            print(_mouseOrigin);
            _isPanning = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isPanning = false;
        }
        if(_isPanning )
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - _mouseOrigin);
            Vector3 movedirection = new Vector3(pos.x * _panningSpeed, pos.y * _panningSpeed, 0f);
            _camera.transform.Translate(movedirection, Space.World);
        }
    }


}
