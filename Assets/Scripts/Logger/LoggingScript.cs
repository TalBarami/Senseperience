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
        private Vector3 _lastWrittenPosition;

        public string LogSavePath;
        public string FileName;
        public int TimeIntervalInMilliseconds;

        private Guid _userNameGuid;
        private string _username;
        public string UserName;

        private string SceneName;

        // Use this for initialization
        void Start()
        {
            _toPersist = new List<string>();
            _writer = new StreamWriter(GetLogFilePath(), true);
            _lastWrittenDateTime = DateTime.MinValue;
            _lastWrittenPosition = transform.position;

            if (TimeIntervalInMilliseconds == 0) {
                TimeIntervalInMilliseconds = _timeInterval.Milliseconds;
            }

            AddToLog("\n\n----------------------------- " + name + " Log -----------------------------");
            AddToLog("----------------------------- " + DateTime.Now + " -----------------------------");

            SceneName = string.IsNullOrEmpty(SceneName) ? SceneManager.GetActiveScene().name : SceneName;
            AddToLog("=> Active Scene: " + SceneName);
            AddToLog("=> Player: " + GetUserName());
            AddToLog("--------------------------------------------------------------------------------");
            //Application.logMessageReceived += HandleLog;
        }

        void FixedUpdate()
        {
            var now = DateTime.Now;
            if (transform.hasChanged || IsPositionChanged(transform.position) || IsTimeToWrite(now))
            {
                WritePositionToLog(transform.position, now);
            }

        }

        void OnCollisionEnter(Collision col)
        {
            AddToLog("Collision Enter: Collided with " + col.gameObject.name, DateTime.Now);
        }

        void OnCollisionExit(Collision col)
        {
            AddToLog("Collision Exit: Collided with " + col.gameObject.name, DateTime.Now);
        }

        void OnDisable()
        {
            //Application.logMessageReceived -= HandleLog;
            //Debug.Log("Entered OnDisable\n");
            //SceneManager.sceneLoaded -=On
            AddToLog("\n----------------------------- End Of Log -----------------------------");

            FlushToFile();
        }

        private void WritePositionToLog(Vector3 position, DateTime logTime) {
            AddToLog(LoggingUtils.PositionPrefix + LoggingUtils.Vector3toString(position), logTime);

            _lastWrittenDateTime = logTime;
            _lastWrittenPosition = position;
            transform.hasChanged = false;
        }

        private bool IsPositionChanged(Vector3 position)
        {
            var distance = Vector3.Distance(position, _lastWrittenPosition);
            return distance > 0.01;
        }

        private bool IsTimeToWrite(DateTime dateTime)
        {
            var timePassed = dateTime.Subtract(_lastWrittenDateTime);
            return timePassed.TotalMilliseconds >= TimeIntervalInMilliseconds;
        }
        
        private void FlushToFile()
        {
            if (_writer == null) return;

            foreach (var msg in _toPersist)
            {
                _writer.WriteLine(msg);
            }

            _writer.Flush();
            _writer.Close();
        }

        private void AddToLog(string msg, DateTime now = default(DateTime))
        {
            //Debug.Log(msg);
            if (!now.Equals(default(DateTime)))
            {
                msg = now + " | " + msg;
            }
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

        private string GetUserName()
        {
            if (!string.IsNullOrEmpty(UserName)) return UserName;

            if (string.IsNullOrEmpty(_username))
            {
                _username = GenerateUserName();
            }
            UserName = _username;

            return UserName;
        }

        public string GetLogFilePath()
        {
            if (string.IsNullOrEmpty(LogSavePath))
            {
                LogSavePath = Application.dataPath + "/Logs";
                //Debug.Log("Log files path: " + LogSavePath);

                LoggingUtils.CreateDirectoryPathIfMissing(LogSavePath);
                CreateFileNameIfMissing();
               
                LogSavePath += "/" + FileName + ".txt";
            }
            
            return LogSavePath;
        }

        void CreateFileNameIfMissing() {
            if (string.IsNullOrEmpty(FileName))
            {
                SceneName = string.IsNullOrEmpty(SceneName) ? SceneManager.GetActiveScene().name : SceneName;
                FileName = DateTime.Now.ToFileTime() + "_" + SceneName + "_" + name;
            }
        }
    }
}


