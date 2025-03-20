using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private PlayerRotation playerRotation;

    [SerializeField]
    private PlayerInteraction playerInteraction;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(playerMovement).AsSingle().NonLazy();

        Container.Bind<PlayerRotation>().FromInstance(playerRotation).AsSingle().NonLazy();

        Container.Bind<PlayerInteraction>().FromInstance(playerInteraction).AsSingle().NonLazy();
    }
}