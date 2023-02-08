using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("���x��������")]
    private int _decelerationTime = 3;
    [SerializeField, Tooltip("������")]
    private float _deceleration = 2;

    private float _speed = 0f;
    private int _addScore;
    private int _totalScore = 0;
    private Text _scoreText = null;
    [Tooltip("�X�s�[�h�����p")]
    private const float ADJUSTMENT = 0.025f;

    public Text ScoreText { get => _scoreText; set => _scoreText = value; }

    void Start()
    {
        _deceleration *= ADJUSTMENT;
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        if(gameObject.transform.position.x > 8.0 || gameObject.transform.position.x < -8.5) { return; }
        if(h < 0) { gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        else if(h > 0) { gameObject.GetComponent<SpriteRenderer>().flipX = true; }
        transform.position += new Vector3(h * _speed, 0, 0);
    }

    public void SetUp(PlayerDataBace data)
    {
        _speed = data.Speed * ADJUSTMENT;
    }

    /// <summary>
    /// �������Ă��܂��A�C�e���擾��
    /// </summary>
    IEnumerator Weight()
    {
        if(_speed < _deceleration) 
        { 
            Debug.Log("�����ʂ����Ƃ̃X�s�[�h��葽��");
            yield break; 
        }
        _speed -= _deceleration;
        yield return new WaitForSeconds(_decelerationTime);
        _speed += _deceleration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            _addScore = other.gameObject.GetComponent<Item>().Score;
            _totalScore += _addScore;
            ScoreText.text = $"{_totalScore:000,000,000}";
        }
        if (other.gameObject.CompareTag("Weight"))
        {
            StartCoroutine(Weight());
        }
    }
}
