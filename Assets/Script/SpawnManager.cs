using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField, Tooltip("�����Ԋu")]
    float _interval = 1;
    [SerializeField, Tooltip("�A�C�e���̐�")]
    int _itemCount = 5;
    [SerializeField, Tooltip("�A�C�e���̏o���m��")]
    int[] _itemWeight = null;
    [SerializeField, Tooltip("�A�C�e��")]
    GameObject[] _item = null;
    [SerializeField]
    private float pozY = 7.0f;

    private float _totalWeight = 0f;
    private float _elapsed; // �o�ߎ���
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
    /// �m���v�Z
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
