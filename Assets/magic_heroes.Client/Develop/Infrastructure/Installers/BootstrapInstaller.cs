using magic_heroes.Client.Presenter;
using UnityEngine;
using Zenject;

namespace magic_heroes.Client.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindResetInstaller();
            BindEndTurnPresenter();
            Debug.Log("BootstrapInstaller InstallBindings");
        }
        
        private void BindEndTurnPresenter()
        {
            Container.BindInterfacesAndSelfTo<EndTurnPresenter>().AsSingle();
        }

        private void BindResetInstaller()
        {
            Container.BindInterfacesAndSelfTo<ResetPresenter>().AsSingle();
        }
    }
}