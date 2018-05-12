using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Logger
{
    public class LoggingScript : MonoBehaviour
    {
        //private List<string> _toPersist;
        //private SLogHandler _logHandler;
        private string _logSavePath;

        private StreamWriter _writer;
        // Use this for initialization
        void Start()
        {
            //_logHandler = new SLogHandler();
            //_toPersist = new List<string>();
            _logSavePath = Application.dataPath + "/Logs";
            Debug.Log("Log files path: " + _logSavePath);

            if (!Directory.Exists(Application.dataPath))
            {
                Directory.CreateDirectory(_logSavePath);
            }

            _logSavePath += "/" + name + ".txt";
            _writer = new StreamWriter(_logSavePath, true);

            _writer.WriteLine("\n\n----------------------------- " + name + " Log -----------------------------");
            _writer.WriteLine("----------------------------- " + DateTime.Now + " -----------------------------");

            //Application.logMessageReceived += HandleLog;
        }

        void FixedUpdate()
        {
            if (transform.hasChanged)
            {
                var dateTime = DateTime.Now;
                _writer.WriteLine(dateTime + " | "+name+" | Position: " + transform.position);

            }

            //_toPersist.Add("I'm inside " + name + "!");
        }

        
        void OnDisable()
        {
            //Application.logMessageReceived -= HandleLog;
            _writer.Flush();
            _writer.Close();
        }
        /*
        void HandleLog(string logString, string stackTrace, LogType type)
        {
            using (var writer = new StreamWriter(_logSavePath, true))
            {
                var typeCaps = type.ToString().ToUpper();
                var dateTime = DateTime.Now;
                writer.WriteLine(dateTime+" [" + typeCaps + "] " + logString);
            }
        }*/
    }
}


