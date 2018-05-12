using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Logger
{
    public class SLogHandler : ILogHandler
    {
        private readonly FileStream _mFileStream;
        private readonly StreamWriter _mStreamWriter;
        private readonly ILogHandler _mDefaultLogHandler = Debug.unityLogger.logHandler;

        public SLogHandler()
        {
            var day = DateTime.Now.ToShortDateString();
            var filePath = Application.dataPath + "/Log.txt";

            _mFileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _mStreamWriter = new StreamWriter(_mFileStream);

            // Replace the default debug log handler
            Debug.unityLogger.logHandler = this;
        }

        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            _mStreamWriter.WriteLine(String.Format(format, args));
            _mStreamWriter.Flush();
            _mDefaultLogHandler.LogFormat(logType, context, format, args);
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            _mDefaultLogHandler.LogException(exception, context);
        }

        public void Disable()
        {
            _mStreamWriter.Flush();
            _mStreamWriter.Close();
            _mFileStream.Close();
        }
    }
}
