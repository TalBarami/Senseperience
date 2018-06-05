using Assets.Scripts.Logger;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PathDrawing : MonoBehaviour {
    public Vector3[] vectorsToDraw;
    public string LogFilePath;
    
    void Start()
    {
        if (!string.IsNullOrEmpty(LogFilePath))
        {
            vectorsToDraw = LoggingUtils.ReadPositionsFromLogFile(LogFilePath);
        }
        else
        {
            Debug.Log("logPath is incorrect!");
        }

    }

    void Update() {
        //Handles.DrawLines(_readVectors);
    }

    
}
