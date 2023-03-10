using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pice : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;
    [SerializeField] Text _nameText = null;
    [SerializeField] Text _speedText = null;
    [SerializeField] Text _commentText = null;
    [SerializeField] int _fastObj = 0;

    void Start()
    {
        UIUpdate(_fastObj);
    }

    public void UIUpdate(int index)
    {
        _nameText.text = $"名前 : {_playerData._playerDataBace[index].m_name}";
        _speedText.text = $"速度 : {_playerData._playerDataBace[index].Speed}";
        _commentText.text = $"助言 : {_playerData._playerDataBace[index].Comment}";
    }
}
