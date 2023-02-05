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
    [SerializeField, Header("ゲーム終了時")]
    private GameObject _clerePanel = null;
    [SerializeField]
    private Text _sore = null;
    [SerializeField]
    private Text _text = null;
    [SerializeField]
    private GameObject _moneys;
    [SerializeField, Tooltip("ゲーム終了時にすること")]
    private UnityEvent _gameFinisht;

    private GameObject _newPlayer = null;
    private bool _startGame = false;
    private bool _gameClere = false;
    private int _playerId = 0;
    private string[] _textList = null;
    private const float NEXT_TEXT = 1f;

    void Start()
    {
        _playerId = CharacterCelect.Instance.PlayerIndex;
        _newPlayer = Instantiate(_players[_playerId]);
        _newPlayer.GetComponent<PlayerController>().SetUp(_playerData._playerDataBace[_playerId]);
        _newPlayer.GetComponent<PlayerController>().ScoreText = _scoreText;
    }

    void Update()
    {
        if(_countDownTime >= 0)
        {
            _countDownTime -= Time.deltaTime;
            _countDownText.text = $"{_countDownTime:0}";
        }
        else if(_countDownTime < 0 && !_startGame)
        {
            _countDownText.gameObject.SetActive(false);
            _startGame = true;
            _newPlayer.GetComponent<PlayerController>().enabled = true;
            _gameStart.Invoke();
        }
        
        if (!_startGame) { return; }
        if (_timer <= 0 && !_gameClere) { GameClear(); }
        _timer -= Time.deltaTime;
        int minutes = (int)_timer / 60;
        float seconds = _timer - minutes * 60;
        _timerText.text = $"{minutes:00}:{(int)seconds:00}";
    }

    /// <summary>
    /// ゲーム終了時
    /// </summary>
    public void GameClear()
    {
        _gameClere = true;
        _gameFinisht.Invoke();
        _textList = new string[_scoreText.text.Length];
        for (int i = 0; i < _scoreText.text.Length; i++)
        {
            var inputText = _scoreText.text.Substring(i, 1);
            _textList[i] = inputText;
        }
        _sore.text = null;
        StartCoroutine(UI());
    }

    /// <summary>
    /// スコア発表演出
    /// </summary>
    IEnumerator UI()
    {
        _sore.gameObject.SetActive(true);
        _text.gameObject.SetActive(true);
        for(int i = _textList.Length -1; 0 <= i; i--)
        {
            _sore.text = $"{_textList[i]}{_sore.text}";
            yield return new WaitForSeconds(NEXT_TEXT);
        }
        _moneys.SetActive(true);
    }
}
