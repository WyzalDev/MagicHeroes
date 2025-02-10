using magic_heroes.Client;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ClientInfoInstaller", menuName = "Installers/ClientInfoInstaller")]
public class ClientInfoInstaller : ScriptableObjectInstaller<ClientInfoInstaller>
{
    [SerializeField]
    private ClientInfo clientInfo;
    
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<ClientInfo>()
            .FromInstance(clientInfo)
            .AsSingle();
    }
}