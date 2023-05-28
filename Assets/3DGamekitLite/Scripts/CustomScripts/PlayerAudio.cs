using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Gamekit3D;
using Debug = FMOD.Debug;

[CreateAssetMenu(menuName = "ScriptableObjects/Audio/Player/Audio")]
public class PlayerAudio : ScriptableObject
{
    public EventReference playerFootsteps;
    public EventReference playerJump;
    public EventReference playerLand;
    public EventReference playerMelee;

    private EventInstance playerMeeleInstance;
    private EventInstance playerFootstepsInstance;
    private EventInstance playerJumpInstance;
    private EventInstance playerLandInstance;
    
    

    
   
    public void PlayerMelee(GameObject meleeObj, int combo)
    {
        // Initialiserar en EventInstance med referens till det event som är lagrat i EventReference
        playerMeeleInstance = RuntimeManager.CreateInstance(playerMelee);
       
        //Fäster en eventinstance till meleeObjektets transformen och rigidbody för att kunna spela upp ljudet efter objektets position
        RuntimeManager.AttachInstanceToGameObject(playerMeeleInstance, meleeObj.transform, meleeObj.GetComponent<Rigidbody>());

        //Sätter vår FMOD-Parameter till samma värde som int:en Combo
        playerMeeleInstance.setParameterByName("Combo", combo);
        
        //Spelar vårt FMOD-Event 
        playerMeeleInstance.start();
        
        //"slänger" instansens Resurser
        playerMeeleInstance.release();

        UnityEngine.Debug.Log("Combo is:"   + combo);
        
    }

    
    

}
