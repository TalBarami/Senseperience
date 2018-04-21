using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes
{
    public class ButtonStartClick : ButtonClickScript
    {
        public int sceneBuildNumber;

        public override void Execute()
        {
            Debug.Log("Starting Game Scene");
            Destroy(GameObject.Find("Geomagic_Basic"));
            Destroy(GameObject.Find("GeomagicPen"));
            SceneManager.LoadScene(sceneBuildNumber);
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
