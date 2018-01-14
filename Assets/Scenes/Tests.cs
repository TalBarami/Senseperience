using System;
using System.Collections;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Assets.Scenes
{
    public class Tests
    {
        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator CursorCollides()
        {
            SetupScene();
            for (var i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(1);
                var o = GameObject.Find("GeomagicPen(Clone)");
                CollisionDetection collisionDetection = o.GetComponent("CollisionDetection") as CollisionDetection;
                if (collisionDetection != null)
                {
                    if (collisionDetection.IsOnCollision)
                    {
                        yield break;
                    }
                }
            }

            Assert.Fail();
        }

        [UnityTest]
        public IEnumerator TestBoxSceneLoading()
        {
            const string sceneName = "TestBox";
            var testScene = SceneManager.GetActiveScene();
            
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);

            SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);

        }

        [UnityTest]
        public IEnumerator TestBoxPrefabLoading()
        {
            var sceneName = "TestBox";
            var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("BasicCube");
            Assert.NotNull(cubePrefab);

            SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }


        [UnityTest]
        public IEnumerator TestCursorCollideDetectGetter()
        {
            var sceneName = "TestBox";
            var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("GeomagicPen");
            yield return new WaitForSeconds(1);
            var colDetect = cubePrefab.GetComponent<CollisionDetection>();
            Assert.NotNull(colDetect);

            SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        private void SetupScene()
        {
            try
            {
                InstantiateGameObject("BasicCube");
                InstantiateGameObject("GeomagicPen");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void InstantiateGameObject(string name)
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>(name));
        }
    }
}