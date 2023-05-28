using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SoundEmitterController))]
public class SoundEmitterEntity : MonoBehaviour
{
     [SerializeField] private String name;
     [SerializeField] private UnityEvent onSoundEmitterTriggered;

     public void Play()
     {
          onSoundEmitterTriggered?.Invoke();
     }

     public String getName()
     {
          return name;
     }
}
