using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

// Скрипт отвечающий за тактильный ввод
public class TouchInput : MonoBehaviour
{
    [Inject]
    private PlayerRotation playerRotation;

    [Inject]
    private JoystickInput joystickInput;

    [Inject]
    private PlayerInteraction playerInteraction;
 
    private MobileInput mobileInput;

    private InputAction pressAction, deltaAction, tapAction, positionAction;

    private CompositeDisposable disposable = new CompositeDisposable();

    private bool isMoving;

    private void Awake()
    {
        mobileInput = new MobileInput();
        mobileInput.Enable();

        pressAction = mobileInput.Touch.Press;
        deltaAction = mobileInput.Touch.Delta;
        tapAction = mobileInput.Touch.Tap;
        positionAction = mobileInput.Touch.Position;

        pressAction.started += Press;
        pressAction.canceled += PressCancel;
        tapAction.started += Tap;
    }

    private void Press(InputAction.CallbackContext context)
    {
        Observable.EveryUpdate().Subscribe(_ => 
        {
            // Проверка состояния джойстика чтобы не поворачивать игрока при перемещении триггера
            if (!joystickInput.IsJoystickTriggered()) 
            {
                Vector2 delta = deltaAction.ReadValue<Vector2>(); // Разница между текущим и предыдущим положениями
                playerRotation.Rotate(new Vector3(0f, -delta.x), new Vector3(delta.y, 0f)); 
            }
            else
            {
                if (!isMoving) 
                {
                    isMoving = true;
                    joystickInput.Move(disposable);
                }
            }
        }).AddTo(disposable);
    }

    private void PressCancel(InputAction.CallbackContext context)
    {
        disposable.Clear();
        isMoving = false;
    }

    private void Tap(InputAction.CallbackContext context)
    {
        Vector3 position = positionAction.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(position); // Посылаем луч в точку нажатия
        playerInteraction.Grab(ray);
    }
}
