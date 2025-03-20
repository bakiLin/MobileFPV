using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField]
    private FloatingJoystick joystick;

    [SerializeField]
    private JoystickInput joystickInput;

    public override void InstallBindings()
    {
        Container.Bind<FloatingJoystick>().FromInstance(joystick).AsSingle().NonLazy();

        Container.Bind<JoystickInput>().FromInstance(joystickInput).AsSingle().NonLazy();
    }
}