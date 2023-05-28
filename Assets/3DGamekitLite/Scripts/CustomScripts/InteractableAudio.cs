using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(menuName = "ScriptableObjects/Audio/Interactable")]
public class InteractableAudio : ScriptableObject
{
     [SerializeField] private EventReference pickupHealth;
     [SerializeField] private EventReference destructableBox; 
     [SerializeField] private EventReference pressurePad; 
     [SerializeField] private EventReference doorSwitch;
     
     public EventReference doorOpen;

     public void PickupHealthAudio(GameObject pickupObj)
     {
          //RuntimeManager.PlayOneShotAttached(pickupHealth,pickupObj);
     }

     public void DestructableBoxAudio(GameObject boxObj)
     {
          //RuntimeManager.PlayOneShotAttached(destructableBox, boxObj);
     }
     
     public void PressurePadAudio(GameObject padObj)
     {
          //RuntimeManager.PlayOneShotAttached(pressurePad, padObj);
     }
     
     public void DoorSwitchAudio(GameObject switchObj)
     {
          //RuntimeManager.PlayOneShotAttached(doorSwitch, switchObj);
     }

     public void DoorOpenAudio(GameObject doorObj, EventInstance eventInstance, bool opening)
     {
          switch (opening)
          {
               case true:
          
                    RuntimeManager.AttachInstanceToGameObject(eventInstance, doorObj.transform, doorObj.GetComponent<Rigidbody>());
                    eventInstance.start();
                    break;
                    case false:
                         eventInstance.keyOff();
                         eventInstance.release();
                         break;
          }
          
     }
     
     
}



