using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 position)
    {
        // ��������� ��������� ��� ����������� � ������ �������� ������
        Vector3 direction = position.x * transform.right + position.z * transform.forward;
        direction.Normalize();
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }
}
