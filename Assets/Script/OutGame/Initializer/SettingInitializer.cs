using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingInitializer : MonoBehaviour
{
    private const int fpsLimit = 60;
    
    void Start()
    {
        Application.targetFrameRate = fpsLimit;
    }
}
