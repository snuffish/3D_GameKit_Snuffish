using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public PlayerAudio PlayerAudio;
    public EnemyAudio EnemyAudio;
    public InteractableAudio InteractableAudio;
    public StudioEventEmitter ambianceManagerEmitter;
    
    public enum AmbianceLocation
    {
        Outdoor = 0,
        InsideSmall = 1,
        InsideLarge = 2,
    }

    public AmbianceLocation currentLocation;
    public AmbianceLocation previousLocation;

    public bool toggle;
    private SoundController _soundController;

    private void Start()
    {
        _soundController = GetComponent<SoundController>();
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
            DontDestroyOnLoad(gameObject);
    }

    public void AmbianceChange(AmbianceLocation newLocation)
    {
        previousLocation = currentLocation;
        currentLocation = newLocation;
        
        if (currentLocation != previousLocation) {
            var instance = _soundController.PlaySound("Ambiance", new Params
                {
                    name = "Location",
                    value = (float)currentLocation
                });
            
            Debug.Log("INSTANCE!!!");
        }

        /*
        switch (toggle)
        {
            case false:
                currentLocation = newLocation;
                toggle = true;
                break; 
            case true:
                currentLocation = previousLocation;
                toggle = false;
                break;
            
        }
        */
        
        /*
        if (ambianceManagerEmitter != null)
            ambianceManagerEmitter.SetParameter("Location",(int)currentLocation);
        */
    }
}
