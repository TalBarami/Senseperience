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
        private readonly TimeSpan _timeInterval = TimeSpan.FromMilliseconds(50);
        private List<string> _toPersist;
        private StreamWriter _writer;
        private DateTime _lastWrittenDateTime;

        public string LogSavePath;

        public int TimeIntervalInMilliseconds;

        private Guid _userNameGuid;
        private string _username;
        public string UserName;


        // Use this for initialization
        void Start()
        {
            _toPersist = new List<string>();
            _writer = new StreamWriter(GetLogPath(), true);
            _lastWrittenDateTime = DateTime.MinValue;
            
            AddToLog("\n\n----------------------------- " + name + " Log -----------------------------");
            AddToLog("----------------------------- " + DateTime.Now + " -----------------------------");

            var sceneName = SceneManager.GetActiveScene().name;
            AddToLog("=> Active Scene: " + sceneName);
            AddToLog("=> Player: " + GetUserName());
            AddToLog("--------------------------------------------------------------------------------");
            //Application.logMessageReceived += HandleLog;
        }

        void FixedUpdate()
        {
            var now = DateTime.Now;
            if (!transform.hasChanged || !IsTimeToWrite(now)) return;

            AddToLog(now + " | " + name + " | Position: " + transform.position);
            _lastWrittenDateTime = DateTime.Now;
        }

        private bool IsTimeToWrite(DateTime dateTime)
        {
            var timePassed = dateTime.Subtract(_lastWrittenDateTime);
            return timePassed.TotalMilliseconds >= TimeIntervalInMilliseconds;
        }

        void OnDisable()
        {
            //Application.logMessageReceived -= HandleLog;
            //Debug.Log("Entered OnDisable\n");
            foreach (var msg in _toPersist)
            {
                _writer.WriteLine(msg);
            }

            _writer.Flush();
            _writer.Close();
        }

        private void AddToLog(string msg)
        {
            //Debug.Log(msg);
            _toPersist.Add(msg);
            //_writer.WriteLine(msg);
        }

        private string GenerateUserName()
        {
            var newGuid = Guid.NewGuid().ToString();
            var length = (newGuid.Length / 4) - 1;
            var generatedShortGuid = newGuid.Substring(0, length);
            return "User_" + generatedShortGuid;
        }

        public string GetUserName()
        {
            if (!string.IsNullOrEmpty(UserName)) return UserName;

            if (string.IsNullOrEmpty(_username))
            {
                _username = GenerateUserName();
            }
            UserName = _username;

            return UserName;
        }

        private string GetLogPath()
        {
            if (string.IsNullOrEmpty(LogSavePath))
            {
                LogSavePath = Application.dataPath + "/Logs";
                //Debug.Log("Log files path: " + LogSavePath);

                if (!Directory.Exists(Application.dataPath))
                {
                    Directory.CreateDirectory(LogSavePath);
                }

                LogSavePath += "/" + name + ".txt";
            }

            return LogSavePath;
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


