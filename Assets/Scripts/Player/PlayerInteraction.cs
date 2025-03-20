using UnityEngine;
using Zenject;

public class PlayerInteraction : MonoBehaviour
{
    [Inject]
    private UIManager uiManager;

    [SerializeField]
    private float dropForce;

    private RaycastHit hit;

    private Transform holdPosition, target;

    private Holdable item;

    private void Awake()
    {
        target = transform.Find("Target");
        holdPosition = target.GetChild(0);
    }

    public void Grab(Ray ray)
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<Holdable>())
            {
                // ��������� ���������� �� ������� � ������� ������� ������� "� ����"
                if (hit.distance < 3f && item == null) 
                {
                    item = hit.collider.GetComponent<Holdable>();
                    item.Grab(holdPosition.position, holdPosition);
                    uiManager.TurnOnButton();
                }
            }
        }
    }

    public void Drop()
    {
        if (item != null)
        {
            item.Drop(target.forward * dropForce); // ������� ������ � ���� � ����������� ������
            item = null;
        }
    }
}
