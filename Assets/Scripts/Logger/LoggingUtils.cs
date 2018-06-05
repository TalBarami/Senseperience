using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Logger
{
    public static class LoggingUtils
    {
        public const string PositionPrefix = "Position Changed: ";

        public static Vector3[] ReadPositionsFromLogFile(string logPath)
        {
            StreamReader reader = new StreamReader(logPath);
            var inputFile = reader.ReadToEnd();
            var lines = ExtractPositionStrings(inputFile.Split("\n"[0]));

            var vectors = new List<Vector3>();

            for (int i = 0; i < lines.Length; i++)
            {
                var current = lines[i];
                //Debug.Log("Line " + i + ": " + current);
                //Debug.Log("Line length = " + current.Length);
                var translatedVector = StringToVector3(current);
                if (translatedVector != null)
                {
                    vectors.Add(translatedVector);
                }
                
                //Debug.Log("Read the following vector: " + vectors[i]);
            }

            reader.Close();
            return vectors.ToArray();
        }

        public static Vector3 StringToVector3(string sVector)
        {
            if (sVector.Length < 3)
            {
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

        public static string Vector3toString(Vector3 vector)
        {
            var x = vector.x;
            var y = vector.y;
            var z = vector.z;

            return "(" + x + ", " + y + ", " + z + ")";
        }

        private static string[] ExtractPositionStrings(string[] lines)
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

        public static void CreateDirectoryPathIfMissing(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
