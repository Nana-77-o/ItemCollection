using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("‘¬“x§ŒÀŽžŠÔ")]
    private int _decelerationTime = 3;
    [SerializeField, Tooltip("Œ¸‘¬—Ê")]
    private int _deceleration = 2;

    private float _speed = 0f;
    private int _addScore;
    private int _totalScore = 0;
    private Text _scoreText = null;

    public Text ScoreText { get => _scoreText; set => _scoreText = value; }

    void Start()
    {
        Debug.Log($"{_speed}");
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h * _speed, 0, 0);
    }

    public void SetUp(PlayerDataBace data)
    {
        _speed = data.Speed;
    }

    IEnumerator Weight()
    {
        _speed -= _deceleration;
        yield return new WaitForSeconds(_decelerationTime);
        _speed += _deceleration;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            _addScore = collision.gameObject.GetComponent<Item>().Score;
            _totalScore += _addScore;
            ScoreText.text = $"{_totalScore}";
        }
        if (collision.gameObject.CompareTag("Weight"))
        {
            StartCoroutine(Weight());
        }
    }
}
