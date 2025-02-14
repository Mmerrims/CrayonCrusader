using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

class Timer: MonoBehaviour
{
    private bool _timerActive;
    private float _currentTime;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _startMinutes; 

    private void Start()
    {
        _currentTime = _startMinutes * 60;
        _timerActive = true;
    }

    void Update()
    {
        if ( _timerActive )
        {
            _currentTime = _currentTime - Time.deltaTime;
            if( _currentTime <= 0)
            {
                _timerActive = false;
            }

        }
        
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
    public void StartTimer()
    {
        _timerActive = true;
    }

    public void StopTimer()
    {
        _timerActive = false;
    }







}
