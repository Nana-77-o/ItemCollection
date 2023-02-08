using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int _score = 0;

    public int Score { get => _score; set => _score = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
