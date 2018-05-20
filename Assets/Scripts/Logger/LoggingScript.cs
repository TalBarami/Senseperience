using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Logger
{
    public class LoggingScript : MonoBehaviour
    {
        private List<string> _toPersist;
        
        private Guid _userNameGuid; 
        //private SLogHandler _logHandler;

        public string LogSavePath { get; set; }
        private string _username;

        public string UserName;
        
        private StreamWriter _writer;
        // Use this for initialization
        void Start()
        {
            //_logHandler = new SLogHandler();
            //_toPersist = new List<string>();
            LogSavePath = LogSavePath ?? Application.dataPath + "/Logs";
            //Debug.Log("Log files path: " + LogSavePath);

            if (!Directory.Exists(Application.dataPath))
            {
                Directory.CreateDirectory(LogSavePath);
            }

            LogSavePath += "/" + name + ".txt";

            _writer = new StreamWriter(LogSavePath, true);
            _toPersist = new List<string>();

            AddToLog("\n\n----------------------------- " + name + " Log -----------------------------");
            AddToLog("----------------------------- " + DateTime.Now + " -----------------------------");

            var sceneName = SceneManager.GetActiveScene().name;
            AddToLog("=> Active Scene: " +sceneName);
            AddToLog("=> Player: "+GetUserName());
            AddToLog("--------------------------------------------------------------------------------");
            //Application.logMessageReceived += HandleLog;
        }

        void FixedUpdate()
        {
            if (transform.hasChanged)
            {
                var dateTime = DateTime.Now;
               AddToLog(dateTime + " | " + name + " | Position: " + transform.position);

            }
        }

        
        void OnDisable()
        {
            //Application.logMessageReceived -= HandleLog;
            
            foreach (var msg in _toPersist)
            {
                _writer.WriteLine(msg);
            }

            _writer.Flush();
            _writer.Close();
        }

        private void AddToLog(string msg)
        {
            _toPersist.Add(msg);
            //_writer.WriteLine(msg);
        }

        private string GenerateUserName()
        {
            var newGuid = Guid.NewGuid().ToString();
            var generatedShortGuid = newGuid.Substring(0, newGuid.Length / 2);
            return "User_" + generatedShortGuid;
        }

        public string GetUserName()
        {
            if (string.IsNullOrEmpty(_username))
            {
                _username = GenerateUserName();
            }

            UserName = _username;
            return _username;
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


