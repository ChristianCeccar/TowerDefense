using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetQualityLevel(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel, true);
        Debug.Log("Current Quality Level " + QualitySettings.GetQualityLevel());
    }
}
