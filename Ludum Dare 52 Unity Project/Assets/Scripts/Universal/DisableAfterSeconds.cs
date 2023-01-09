using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    [SerializeField] float seconds = 0.5f;

    private void Start() => Invoke(nameof(DisableGameObject), seconds);

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
