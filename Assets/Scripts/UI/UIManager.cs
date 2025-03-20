using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject]
    private PlayerInteraction playerInteraction;

    [SerializeField]
    private GameObject dropButton;

    private void Awake()
    {
        dropButton.SetActive(false);
    }

    public void Drop()
    {
        playerInteraction.Drop();
        dropButton.SetActive(false);
    }

    public void TurnOnButton()
    {
        dropButton.SetActive(true);
    }
}
