using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] GameObject[] _players = null;

    [SerializeField, Tooltip("�I������")] 
    private float _timer = 60.0f;
    [SerializeField, Tooltip("�J�E���g�_�E������")]
    private float _countDownTime = 3;
    [SerializeField, Tooltip("�^�C�}�[�e�L�X�g")] 
    private Text _timerText = null;
    [SerializeField, Tooltip("�X�R�A�e�L�X�g")] 
    private Text _scoreText = null;
    [SerializeField, Tooltip("�J�E���g�_�E���e�L�X�g")]
    private Text _countDownText = null;
    [SerializeField, Tooltip("�Q�[���X�^�[�g���ɂ��邱��")]
    private UnityEvent _gameStart;

    private bool _startGame = false;
    private int _playerId = 0;

    void Start()
    {
        _playerId = CharacterCelect.Instance.PlayerIndex;
        var player = Instantiate(_players[_playerId]);
        player.GetComponent<PlayerController>().SetUp(_playerData._playerDataBace[_playerId]);
    }

    void Update()
    {
        if(_countDownTime >= 0)
        {
            _countDownTime -= Time.deltaTime;
            _countDownText.text = $"{_countDownTime:0}";
        }
        else if(_countDownTime < 0)
        {
            _countDownText.gameObject.SetActive(false);
            _startGame = true;
            _gameStart.Invoke();
        }
        
        if (!_startGame) { return; }
        _timer -= Time.deltaTime;
        int minutes = (int)_timer / 60;
        float seconds = _timer - minutes * 60;
        _timerText.text = $"{minutes:00}:{(int)seconds:00}";
    }
}
