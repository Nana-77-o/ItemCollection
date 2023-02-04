using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public PlayerDataBace[] _playerDataBace;
}

[System.Serializable]
public class PlayerDataBace
{
    public string m_name;
    [SerializeField, Header("‘¬“x")] float _speed;
    public float Speed => _speed;

    [SerializeField, Header("ˆêŒ¾")] string _comment;
    public string Comment => _comment;
}
