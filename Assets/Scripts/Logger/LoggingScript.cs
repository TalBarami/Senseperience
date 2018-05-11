using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logger
{
    public class LoggingScript : MonoBehaviour
    {
        private List<string> _toPersist;
        private SLogHandler _logHandler;

        // Use this for initialization
        void Start()
        {
            _logHandler = new SLogHandler();
            _toPersist = new List<string>();
        }

        void FixedUpdate()
        {
            //Debug.Log("I'm inside " + name + "!");
            _toPersist.Add("I'm inside " + name + "!");
        }

        // Update is called once per frame
        /*void Update()
        {
            toPersist.Add("I'm inside "+name+"!");
        }
        */
        void OnDisable()
        {
            foreach (var log in _toPersist)
            {
                Debug.Log(log);
            }

            _logHandler.Disable();
        }
    }
}


