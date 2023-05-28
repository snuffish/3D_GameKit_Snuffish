using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
[CreateAssetMenu(menuName = "ScriptableObjects/Audio/Enemy")]
public class EnemyAudio : ScriptableObject
{
    public EventReference enemyFootstep;
    public EventReference enemyMelee;
    public EventReference enemyOnDeath;
    public EventReference chomperAttack;
    public EventReference spitterAttack;

    private EventInstance enemyfootstepinstance;
    private EventInstance enemyMeleeInstance;
    private EventInstance enemyDeathInstance;
    private EventInstance spitterAttackInstance;
    private EventInstance chomperAttackInstance;
    private EventInstance grenadierWalk;
    private EventInstance grenadierDie;
    private EventInstance grenadierGrenadeAttack;
    private EventInstance grenadierTakeDamage;
    private EventInstance grenadierPunchAttack;
    private EventInstance grenadierLightningAttack;



    public void EnemyFootstepAudio(GameObject footObj, int footType)

    {
        enemyfootstepinstance = RuntimeManager.CreateInstance(enemyFootstep);
        RuntimeManager.AttachInstanceToGameObject(enemyfootstepinstance,footObj.transform,footObj.GetComponent<Rigidbody>());
        enemyfootstepinstance.setParameterByName("FootType", footType);
        enemyfootstepinstance.start();
        enemyfootstepinstance.release();    

    }


    public void EnemyMeleeAttack(GameObject meleeObj, int attackStage)
    {
        enemyMeleeInstance = RuntimeManager.CreateInstance(enemyMelee);
        
        RuntimeManager.AttachInstanceToGameObject(enemyMeleeInstance, meleeObj.transform, meleeObj.GetComponent<Rigidbody>());

        enemyMeleeInstance.setParameterByName("Attack", attackStage);
        
        enemyMeleeInstance.start();    
        
        enemyMeleeInstance.release();
    }
    


}
