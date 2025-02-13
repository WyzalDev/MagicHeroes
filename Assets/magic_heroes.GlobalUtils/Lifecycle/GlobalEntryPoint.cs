using System;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils;
using magic_heroes.GlobalUtils.Lifecycle.FsmUtils.States;
using UnityEngine;

namespace magic_heroes.GlobalUtils.Lifecycle
{
    public class GlobalEntryPoint : MonoBehaviour
    {
        private const string LIFECYCLE_PREFAB_NAME = "LifecycleObject";
        private const string SCENE_LOADER_PREFAB_NAME = "SceneLoader";
        private const string CAMERA_PREFAB_NAME = "Camera";
        private const string LIFECYCLE_FSM_NAME = "GlobalLifeCycleFSM";

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
            var lifecycleFsmInstance = new Fsm(LIFECYCLE_FSM_NAME);
            lifecycleFsmInstance.AddState(new GlobalBootstrapState(lifecycleFsmInstance));
            lifecycleFsmInstance.AddState(new LoadingState(lifecycleFsmInstance));
            lifecycleFsmInstance.AddState(new GameplayState(lifecycleFsmInstance));
            var lifecycleMono = Instantiate(_lifecycleMonoPrefab).GetComponent<LifecycleMono>();
            DontDestroyOnLoad(lifecycleMono);
            lifecycleMono.Construct(lifecycleFsmInstance);

            lifecycleFsmInstance.SetState(GlobalBootstrapState.STATE_NAME);
        }
    }
}