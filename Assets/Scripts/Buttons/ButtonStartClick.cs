using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes
{
    public class ButtonStartClick : ButtonClickScript
    {
        public string sceneName;

        public override void Execute()
        {
            Debug.Log("Starting Game Scene");
            Destroy(GameObject.Find("Geomagic"));
            Destroy(GameObject.Find("GeomagicPen"));
            SceneManager.LoadScene(sceneName);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
