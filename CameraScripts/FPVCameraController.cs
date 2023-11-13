using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVCameraController : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float _mouseSensitivity = 200f;

    public Transform _playerBody;

    [SerializeField]
    private float _xRotation = 0f;

    // Acceleration fields
    private Vector2 currentMouseDelta = Vector2.zero;
    private Vector2 currentMouseDeltaVelocity = Vector2.zero;
    
    [SerializeField]
    private float mouseSmoothTime = 0.03f; // Time it takes to smooth the input
    #endregion Fields

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerBody == null)
        {
            Debug.LogWarning("Player body not assigned in FPV Camera Controller");
            return;
        }

        // Get raw mouse input
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Smoothly interpolate towards the target
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (currentMouseDelta != Vector2.zero)
        {
            FPVControls();
        }
    }

    private void FPVControls()
    {
        float mouseX = currentMouseDelta.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = currentMouseDelta.y * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // Prevents over-rotation

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
    #endregion Methods
}

