using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCelect : MonoBehaviour
{
    private static CharacterCelect _instance;

    private int _playerIndex = 0;

    public static CharacterCelect Instance { get => _instance; set => _instance = value; }
    public int PlayerIndex { get => _playerIndex; set => _playerIndex = value; }

    private void Awake()
    {
        Instance = this;
    }
}
