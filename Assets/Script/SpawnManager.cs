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
    [SerializeField]
    private float pozY = 7.0f;

    private float _totalWeight = 0f;
    private float _elapsed; // 経過時間
    private const float POZ_X = 6.5f;

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
            var obj = Instantiate(_item[PramProbability()], transform);
            Curve(obj);
        }
    }

    /// <summary>
    /// 確率計算
    /// </summary>
    int PramProbability()
    {
        var randomPoint = Random.Range(0, _totalWeight);

        var currentWeight = 0f;
        for (var i = 0; i < _itemWeight.Length; i++)
        {
            currentWeight += _itemWeight[i];

            if (randomPoint < currentWeight)
            {
                return i;
            }
        }
        return _itemWeight.Length - 1;
    }

    private void Curve(GameObject obj)
    {
        var rb =  obj.GetComponent<Rigidbody>();
        var pozX = Random.Range(-POZ_X, POZ_X);
        var force = new Vector3(pozX, pozY, 0);
        rb.AddForce(force, ForceMode.Impulse);
    }
}
