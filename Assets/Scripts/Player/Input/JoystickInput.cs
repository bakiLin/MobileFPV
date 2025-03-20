using UnityEngine;
using Zenject;
using UniRx;

// ������ ��� ���������� ��������� ���������
public class JoystickInput : MonoBehaviour
{
    [Inject]
    private FloatingJoystick joystick;

    [Inject]
    private PlayerMovement playerMovement;

    public void Move(CompositeDisposable disposable)
    {
        // ������������� �� FixedUpdate ��� ����������� ������ � �������
        Observable.EveryFixedUpdate().Subscribe(_ =>
        {
            playerMovement.Move(new Vector3(joystick.Horizontal, 0f, joystick.Vertical));
        }).AddTo(disposable);
    }

    public bool IsJoystickTriggered()
    {
        return joystick.Direction.magnitude > 0;
    }
}
