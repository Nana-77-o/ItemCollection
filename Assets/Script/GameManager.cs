using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] GameObject[] _players = null;

    [SerializeField, Tooltip("終了時間")] 
    private float _timer = 60.0f;
    [SerializeField, Tooltip("カウントダウン時間")]
    private float _countDownTime = 3;
    [SerializeField, Tooltip("タイマーテキスト")] 
    private Text _timerText = null;
    [SerializeField, Tooltip("スコアテキスト")] 
    private Text _scoreText = null;
    [SerializeField, Tooltip("カウントダウンテキスト")]
    private Text _countDownText = null;
    [SerializeField, Tooltip("ゲームスタート時にすること")]
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
