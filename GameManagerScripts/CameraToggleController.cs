using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraToggleController : MonoBehaviour
{
    #region Fields
    public Camera _mainCamera;
    public Camera _secondaryCamera;
    AudioListener _mainAudioListener;
    AudioListener _secondaryAudioListener;
    bool _active = true;
    #endregion Fields

    #region Methods
    private void Start()
    {
        // Ensure main camera is active, when the game starts
        _mainCamera.gameObject.SetActive(true);
        _secondaryCamera.gameObject.SetActive(false);

        // Get the AudioListener components from the cameras
        _mainAudioListener = _mainCamera.GetComponent<AudioListener>();
        _secondaryAudioListener = _secondaryCamera.GetComponent<AudioListener>();

        // Ensure only one AudioListener is active at the start
        _mainAudioListener.enabled = true;
        _secondaryAudioListener.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCamera();
        }           
    }

    void ToggleCamera()
    {
        _active = !_active;

        _mainCamera.gameObject.SetActive(_active);
        _secondaryCamera.gameObject.SetActive(!_active);

        // Toggle the AudioListeners along with the cameras, to prevent warnings.
        _mainAudioListener.enabled = _active;
        _secondaryAudioListener.enabled = !_active;
    }
    #endregion Methods
}
