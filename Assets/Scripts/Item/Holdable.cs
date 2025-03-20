using UnityEngine;
using UnityEngine.Rendering;

// Скрипт определяющий возможность объекта быть поднятым игроком
public class Holdable : MonoBehaviour
{
    private ItemPhysics itemPhysics;

    private MeshRenderer mr;

    private void Awake()
    {
        itemPhysics = GetComponent<ItemPhysics>();
        mr = GetComponent<MeshRenderer>();
    }

    public void Grab(Vector3 position, Transform parent)
    {
        itemPhysics.Grab();
        transform.position = position;
        transform.parent = parent;
        mr.shadowCastingMode = ShadowCastingMode.Off;
    }

    public void Drop(Vector3 direction)
    {
        transform.parent = null;
        itemPhysics.Drop(direction);
        mr.shadowCastingMode = ShadowCastingMode.On;
    }
}
