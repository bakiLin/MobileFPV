using UnityEngine;

// Взаимодействие с физикой объекта
public class ItemPhysics : MonoBehaviour
{
    private Rigidbody rb;

    private Collider coll;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    public void Grab()
    {
        transform.rotation = Quaternion.identity;
        coll.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void Drop(Vector3 direction)
    {
        coll.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(direction, ForceMode.Impulse);
    }
}
