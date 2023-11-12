using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVCameraController : MonoBehaviour
{
    #region Fields
    [SerializeField]
    float _mouseSensitivity = 200f;

    Transform _playerBody;

    [SerializeField]
    float _xRotation = 0f;
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
        FPVControls();
    }

    private void FPVControls()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // Prevents over-rotation

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
    #endregion Methods
}
