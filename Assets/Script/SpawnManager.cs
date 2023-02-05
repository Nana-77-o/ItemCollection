using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField, Tooltip("生成間隔")]
    float _interval = 1;
    [SerializeField, Tooltip("アイテムの数")]
    int _itemCount = 5;
    [SerializeField, Tooltip("アイテムの出現確率")]
    int[] _itemWeight = null;
    [SerializeField, Tooltip("アイテム")]
    GameObject[] _item = null;

    private float _totalWeight = 0f;
    private float _elapsed; // 経過時間

    private void Start()
    {
        for (var i = 0; i < _itemWeight.Length; i++)
        {
            _totalWeight += _itemWeight[i];
        }
    }
    void Update()
    {
        _elapsed += Time.deltaTime;
        if (GameObject.FindGameObjectsWithTag("Item").Length + GameObject.FindGameObjectsWithTag("Weight").Length>= _itemCount)
        {
            return;
        }
        if (_elapsed > _interval)
        {
            _elapsed = 0;
            Instantiate(_item[PramProbability()], transform);
        }
    }

    /// <summary>
    /// 確率計算
    /// </summary>
    int PramProbability()
    {
        var randomPoint = UnityEngine.Random.Range(0, _totalWeight);

        // 乱数値が属する要素を先頭から順に選択
        var currentWeight = 0f;
        for (var i = 0; i < _itemWeight.Length; i++)
        {
            // 現在要素までの重みの総和を求める
            currentWeight += _itemWeight[i];

            // 乱数値が現在要素の範囲内かチェック
            if (randomPoint < currentWeight)
            {
                return i;
            }
        }
        // 乱数値が重みの総和以上なら末尾要素とする
        return _itemWeight.Length - 1;
    }
}
