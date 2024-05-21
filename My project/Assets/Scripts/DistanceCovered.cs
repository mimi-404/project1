using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCovered : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private Transform _playerTrans;

    private Vector2 _startpos;

    private void Start()
    {
        _startpos = _playerTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = (Vector2)_playerTrans.position - _startpos;
        distance.y = 0f;

        if(distance.x < 0f) distance.x = 0f;

        _distanceText.text = distance.x.ToString("F0") + "m";
    }


}
