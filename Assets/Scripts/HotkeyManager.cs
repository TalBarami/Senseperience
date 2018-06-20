using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HotkeyManager : MonoBehaviour
{
    private const int scenesCount = 5;


    private KeyCode hotkeyReset = KeyCode.R;
    private KeyCode hotkeyNext = KeyCode.N;
    private KeyCode hotkeyPrevious = KeyCode.P;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(hotkeyReset))
        {
            ReloadScene();
        }
        else if (Input.GetKeyDown(hotkeyNext))
        {
            NextScene();
        }
        else if (Input.GetKeyDown(hotkeyPrevious))
        {
            PrevScene();
        }
    }

    public static void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void NextScene()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % scenesCount);
    }
    public static void PrevScene()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex -1 + scenesCount) % scenesCount);
    }

    public static void LoadScene(int index)
    {
        Debug.Log("Starting Game Scene: " + index);
        Destroy(GameObject.Find("Geomagic"));
        SceneManager.LoadScene(index);
    }
}