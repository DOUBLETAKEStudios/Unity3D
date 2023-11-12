using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private int _targetFPS = 60; // Default value of 60
    #endregion Fields
    
    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = _targetFPS;
    }
    #endregion Methods
}
