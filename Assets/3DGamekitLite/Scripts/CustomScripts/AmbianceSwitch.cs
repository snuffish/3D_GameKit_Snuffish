using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AmbianceSwitch : MonoBehaviour
{
    private AudioManager _audioManager;

    public AudioManager.AmbianceLocation locationChange;


    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"AmbianceSwitch:{other.name}");
            //_audioManager.AmbianceChange(locationChange);
        }
    }
}