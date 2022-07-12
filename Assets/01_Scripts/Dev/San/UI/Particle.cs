using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private float _deleteTime;

    private float _crtTime = 0;
    // Update is called once per frame
    void Update()
    {
        OnDelete();
    }
    private void OnDelete()
    {
        _crtTime += Time.deltaTime;
        if (_crtTime > _deleteTime)
        {
            _crtTime = 0;
            PoolingManager.Instance.Push(gameObject);
        }
    }
}
