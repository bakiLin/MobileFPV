using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform target;

    private Vector3 rotation;

    private void Awake()
    {
        target = transform.Find("Target");
    }

    public void Rotate(Vector3 rotationX, Vector3 rotationY)
    {
        rotation = transform.rotation.eulerAngles + speed * Time.deltaTime * rotationX;
        transform.rotation = Quaternion.Euler(rotation); // ������� ������

        rotation = target.rotation.eulerAngles + speed * Time.deltaTime * rotationY;
        target.rotation = Quaternion.Euler(rotation); // ������� ��������� ������� � ������������� �������
    }
}
