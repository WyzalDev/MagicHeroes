using System;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States;
using UnityEngine;

namespace magic_heroes.GlobalUtils.Lifecycle
{
    public class GlobalEntryPoint : MonoBehaviour
    {
        private const String LIFECYCLE_PREFAB_NAME = "LifecycleObject";
        private const String SCENE_LOADER_PREFAB_NAME = "SceneLoader";
        private const String CAMERA_PREFAB_NAME = "Camera";

        private GameObject _lifecycleMonoPrefab;
        private GameObject _sceneLoaderPrefab;
        private GameObject _cameraPrefab;

        private void Awake()
        {
            _lifecycleMonoPrefab = Resources.Load(LIFECYCLE_PREFAB_NAME) as GameObject;
            _sceneLoaderPrefab = Resources.Load(SCENE_LOADER_PREFAB_NAME) as GameObject;
            _cameraPrefab = Resources.Load(CAMERA_PREFAB_NAME) as GameObject;
        }

        private void Start()
        {
            //init camera and SceneLoader
            var sceneLoaderInstance = Instantiate(_sceneLoaderPrefab);
            var cameraInstance = Instantiate(_cameraPrefab);
            DontDestroyOnLoad(cameraInstance.gameObject);

            //create lifecycle fsm, initialize LifeCycleMono, add states
            var lifecycleFsmInstance = new Fsm();
            lifecycleFsmInstance.AddState(typeof(GlobalBootstrapState));
            lifecycleFsmInstance.AddState(typeof(LoadingState));
            lifecycleFsmInstance.AddState(typeof(GameplayState));
            var lifecycleMono = Instantiate(_lifecycleMonoPrefab).GetComponent<LifecycleMono>();
            lifecycleMono.Construct(lifecycleFsmInstance);

            //TODO create connection utils entities

            lifecycleFsmInstance.SetState(GlobalBootstrapState.STATE_NAME);
        }
    }
}