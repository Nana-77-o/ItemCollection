using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int _score = 0;

    public int Score { get => _score; set => _score = value; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
