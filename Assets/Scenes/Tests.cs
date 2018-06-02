using System;
using System.Collections;
using Assets.Scripts;
using Assets.Util;
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
        public IEnumerator CursorCollidesInBoxScene()
        {
            const string sceneName = "TestBox";
           // var activeScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cubePrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);
                var colDetect = cubePrefab.GetComponent<CollisionDetection>();
                if (colDetect != null)
                {
                    Assert.IsTrue(colDetect.IsOnCollision, "Collision Detection Object: " + colDetect +
                                                           "\nisCollision = " + colDetect.IsOnCollision);
                    break;
                }
                else
                {
                    Assert.Fail("Collision Detection Object: " + colDetect);
                }
            }

            //yield return SceneManager.LoadSceneAsync(activeScene.name);
            //SceneManager.SetActiveScene(activeScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator CursorCollidesInSphereScene()
        {
            const string sceneName = "TestSphere";
            //var activeScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cursorPrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);
                var colDetect = cursorPrefab.GetComponent<CollisionDetection>();
                if (colDetect != null)
                {
                    Assert.IsTrue(colDetect.IsOnCollision, "Collision Detection Object: " + colDetect +
                                                           "\nisCollision = " + colDetect.IsOnCollision);
                    break;
                }
                else
                {
                    Assert.Fail("Collision Detection Object: " + colDetect);
                }
            }

            //yield return SceneManager.LoadSceneAsync(activeScene.name);
            //SceneManager.SetActiveScene(activeScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator CursorCollidesWithCube()
        {
            const string sceneName = "TestBox";
            //var activeScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cursorPrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);

                var colDetect = cursorPrefab.GetComponent<CollisionDetection>();
                if (colDetect != null && colDetect.IsOnCollision)
                {
                    var otherCollider = colDetect.GetOther();
                    var cubeType = GameObject.Find("Prefab").GetType();
                    Assert.AreEqual(cubeType, otherCollider.gameObject.GetType());
                    yield break;
                }
                else
                {
                    Assert.Fail("component = "+colDetect);
                }
            }
            //yield return SceneManager.LoadSceneAsync(activeScene.name);
            //SceneManager.SetActiveScene(activeScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator CursorCollidesWithSphere()
        {
            const string sceneName = "TestSphere";
           // var testScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cursorPrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);

                var colDetect = cursorPrefab.GetComponent<CollisionDetection>();
                if (colDetect != null && colDetect.IsOnCollision)
                {
                    var otherCollider = colDetect.GetOther();
                    var sphereType = GameObject.Find("Sphere").GetType();
                    Assert.AreEqual(sphereType, otherCollider.gameObject.GetType());
                    yield break;
                }
                else
                {
                    Assert.Fail("component = " + colDetect);
                }
            }

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator TestBoxSceneLoading()
        {
            const string sceneName = "TestBox";
            //var testScene = SceneManager.GetActiveScene();
            
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);

        }

        [UnityTest]
        public IEnumerator TestBoxPrefabLoading()
        {
            var sceneName = "TestBox";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("Prefab");
            Assert.NotNull(cubePrefab);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator TestSpherePrefabLoading()
        {
            var sceneName = "TestSphere";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var spherePrefab = GameObject.Find("Sphere");
            Assert.NotNull(spherePrefab);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }


        [UnityTest]
        public IEnumerator TestCursorCollideDetectGetter()
        {
            var sceneName = "TestBox";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("GeomagicPen");
            yield return new WaitForSeconds(1);
            var colDetect = cubePrefab.GetComponent<CollisionDetection>();
            Assert.NotNull(colDetect);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator TestCollisionSoundOnBox()
        {
            const string sceneName = "TestBox";
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cubePrefab = GameObject.Find("Prefab");
                yield return new WaitForSeconds(1);
                var colDetect = cubePrefab.GetComponent<CollisionSoundController>();
                if (colDetect != null)
                {
                    var colState = colDetect.GetCollisionState();
                    switch (colState)
                    {
                        case CollisionState.None:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsFalse(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Enter:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Stay:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Exit:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;

                            }
                    }
                    break;
                }
            }

            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator TestCollisionSoundOnSphere()
        {
            const string sceneName = "TestBox";
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cubePrefab = GameObject.Find("Prefab");
                yield return new WaitForSeconds(1);
                var colDetect = cubePrefab.GetComponent<CollisionSoundController>();
                if (colDetect != null)
                {
                    var colState = colDetect.GetCollisionState();
                    switch (colState)
                    {
                        case CollisionState.None:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsFalse(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Enter:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Stay:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Exit:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;

                            }
                    }
                    break;
                }
            }

            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        public IEnumerator CursorCollidesInButtonScene()
        {
            const string sceneName = "TestBox";
           // var activeScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cubePrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);
                var colDetect = cubePrefab.GetComponent<CollisionDetection>();
                if (colDetect != null)
                {
                    Assert.IsTrue(colDetect.IsOnCollision, "Collision Detection Object: " + colDetect +
                                                           "\nisCollision = " + colDetect.IsOnCollision);
                    break;
                }
                else
                {
                    Assert.Fail("Collision Detection Object: " + colDetect);
                }
            }

            //yield return SceneManager.LoadSceneAsync(activeScene.name);
            //SceneManager.SetActiveScene(activeScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }


         [UnityTest]
        public IEnumerator CursorCollidesWithButton()
        {
            const string sceneName = "TestBox";
            //var activeScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cursorPrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);

                var colDetect = cursorPrefab.GetComponent<CollisionDetection>();
                if (colDetect != null && colDetect.IsOnCollision)
                {
                    var otherCollider = colDetect.GetOther();
                    var cubeType = GameObject.Find("Prefab").GetType();
                    Assert.AreEqual(cubeType, otherCollider.gameObject.GetType());
                    yield break;
                }
                else
                {
                    Assert.Fail("component = "+colDetect);
                }
            }
            //yield return SceneManager.LoadSceneAsync(activeScene.name);
            //SceneManager.SetActiveScene(activeScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator CursorCollidesWithRoom()
        {
            const string sceneName = "TestRoom";
           // var testScene = SceneManager.GetActiveScene();

            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cursorPrefab = GameObject.Find("GeomagicPen");
                yield return new WaitForSeconds(1);

                var colDetect = cursorPrefab.GetComponent<CollisionDetection>();
                if (colDetect != null && colDetect.IsOnCollision)
                {
                    var otherCollider = colDetect.GetOther();
                    var sphereType = GameObject.Find("Floor").GetType();
                    Assert.AreEqual(sphereType, otherCollider.gameObject.GetType());
                    yield break;
                }
                else
                {
                    Assert.Fail("component = " + colDetect);
                }
            }

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator TestButtonSceneLoading()
        {
            const string sceneName = "TestButton";
            //var testScene = SceneManager.GetActiveScene();
            
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

            Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);

        }

        [UnityTest]
        public IEnumerator TestButtonPrefabLoading()
        {
            var sceneName = "TestSphere";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("Sphere");
            Assert.NotNull(cubePrefab);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        [UnityTest]
        public IEnumerator TestButtonBackgroundMusicLoading()
        {
            var sceneName = "TestMusic";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("BackgroundMusic");
            Assert.NotNull(cubePrefab);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }
                
        [UnityTest]
        public IEnumerator TestDecorations()
        {
            var sceneName = "TestDecoration";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var cubePrefab = GameObject.Find("Picture");
            Assert.NotNull(cubePrefab);

            var cubePrefab = GameObject.Find("Saw");
            Assert.NotNull(cubePrefab);

            var cubePrefab = GameObject.Find("Sylvanas");
            Assert.NotNull(cubePrefab);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }
        [UnityTest]
        public IEnumerator TestRoomPrefabLoading()
        {
            var sceneName = "TestSphere";
            //var testScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            yield return new WaitForSeconds(1);

            var spherePrefab = GameObject.Find("Floor");
            Assert.NotNull(spherePrefab);

            //SceneManager.SetActiveScene(testScene);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }



        [UnityTest]
        public IEnumerator TestCollisionSoundOnButton()
        {
            const string sceneName = "TestBox";
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            var testScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(testScene);

            yield return new WaitForSeconds(1);

            for (var i = 0; i < 5; i++)
            {
                var cubePrefab = GameObject.Find("Prefab");
                yield return new WaitForSeconds(1);
                var colDetect = cubePrefab.GetComponent<CollisionSoundController>();
                if (colDetect != null)
                {
                    var colState = colDetect.GetCollisionState();
                    switch (colState)
                    {
                        case CollisionState.None:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsFalse(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Enter:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Stay:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;
                            }
                        case CollisionState.Exit:
                            {
                                var collisionAudio = colDetect.GetCollisionAudioSource();
                                Assert.IsTrue(collisionAudio.isPlaying);
                                break;

                            }
                    }
                    break;
                }
            }

            yield return SceneManager.UnloadSceneAsync(sceneName);
        }

        
    }
    
}