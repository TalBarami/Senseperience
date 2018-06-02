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
        private const string PositionPrefix = "Position Changed: ";
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

        /*void OnEnable() {
            SceneManager.sceneLoaded += OnSceneFinishedLoading;
        }

        void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("Scene" + scene.name + " Loaded");
        }*/

        // Use this for initialization
        void Start()
        {
            _toPersist = new List<string>();
            _writer = new StreamWriter(GetLogPath(), true);
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

        private void WritePositionToLog(Vector3 position, DateTime logTime) {
            AddToLog(PositionPrefix + position, logTime);
            _lastWrittenDateTime = logTime;
            _lastWrittenPosition = position;
            transform.hasChanged = false;
        }

        private bool IsPositionChanged(Vector3 position)
        {
            var distance = Vector3.Distance(position, _lastWrittenPosition);
            return distance > 0.01;
        }

        public void OnCollisionEnter(Collision col)
        {
            AddToLog("Collision Enter: Collided with "+col.gameObject.name, DateTime.Now);
        }

        public void OnCollisionExit(Collision col)
        {
            AddToLog("Collision Exit: Collided with " + col.gameObject.name, DateTime.Now);
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
            //SceneManager.sceneLoaded -=On
            AddToLog("\n----------------------------- End Of Log -----------------------------");

            FlushToFile();
            /*
            var vectors = ReadPositionsFromLogFile();
            _writer = new StreamWriter(GetLogPath(), true);
            _toPersist.Clear();

            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i] != default(Vector3) || vectors[i] == new Vector3(0, 0, 0))
                {
                    AddToLog("Found Position: " + vectors[i]);
                }
            }

            FlushToFile();*/
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

        private Vector3[] ReadPositionsFromLogFile()
        {
            StreamReader reader = new StreamReader(GetLogPath());
            var inputFile = reader.ReadToEnd();
            var lines = ExtractPsitionStrings(inputFile.Split("\n"[0]));
            
            Vector3[] vectors = new Vector3[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var current = lines[i];
                //Debug.Log("Line " + i + ": " + current);
                //Debug.Log("Line length = " + current.Length);
                vectors[i] = StringToVector3(current);
                //Debug.Log("Read the following vector: " + vectors[i]);


            }

            reader.Close();
            return vectors;
        }

        public static Vector3 StringToVector3(string sVector)
        {
            if (sVector.Length < 3) {
                return default(Vector3);
            }

            //Debug.Log("Removing parentheses");
            sVector = sVector.Substring(1, sVector.Length - 3);
            //Debug.Log("Splitting: "+sVector);
            string[] sArray = sVector.Split(',');

            return new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));
        }

        private string[] ExtractPsitionStrings(string[] lines)
        {
            var extracted = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                extracted[i] = string.Empty;
                var startOfPrefix = lines[i].IndexOf(PositionPrefix);
                if (startOfPrefix < 0) continue;
                var lengthToRead = lines[i].Length - (startOfPrefix + PositionPrefix.Length);
                extracted[i] = (lines[i].Substring(startOfPrefix + PositionPrefix.Length, lengthToRead));
            }

            return extracted;
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

                CreateDirectoryPathIfMissing(LogSavePath);
                CreateFileNameIfMissing();
               
                LogSavePath += "/" + FileName + ".txt";
            }
            
            return LogSavePath;
        }

        void CreateDirectoryPathIfMissing(string path) {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
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


