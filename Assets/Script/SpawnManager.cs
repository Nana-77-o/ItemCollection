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

    private float _totalWeight = 0f;
    private float _elapsed; // �o�ߎ���

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
    /// �m���v�Z
    /// </summary>
    int PramProbability()
    {
        var randomPoint = UnityEngine.Random.Range(0, _totalWeight);

        // �����l��������v�f��擪���珇�ɑI��
        var currentWeight = 0f;
        for (var i = 0; i < _itemWeight.Length; i++)
        {
            // ���ݗv�f�܂ł̏d�݂̑��a�����߂�
            currentWeight += _itemWeight[i];

            // �����l�����ݗv�f�͈͓̔����`�F�b�N
            if (randomPoint < currentWeight)
            {
                return i;
            }
        }
        // �����l���d�݂̑��a�ȏ�Ȃ疖���v�f�Ƃ���
        return _itemWeight.Length - 1;
    }
}
