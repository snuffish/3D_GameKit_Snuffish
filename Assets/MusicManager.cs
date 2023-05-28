using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter[] musicEmitters; // an array of FMOD StudioEventEmitter components
    [SerializeField] private Collider[] musicTriggers; // an array of colliders that trigger music events

    private int currentEmitterIndex = -1; // the index of the currently playing music emitter

    private void OnTriggerEnter(Collider other)
    {
        // check if the collider that triggered the event is one of the music triggers
        int triggerIndex = System.Array.IndexOf(musicTriggers, other);
        if (triggerIndex >= 0)
        {
            // stop the currently playing music
            if (currentEmitterIndex >= 0)
            {
                musicEmitters[currentEmitterIndex].Stop();
            }

            // play the music associated with the triggered collider
            currentEmitterIndex = triggerIndex;
            musicEmitters[currentEmitterIndex].Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // check if the collider that triggered the event is one of the music triggers
        int triggerIndex = System.Array.IndexOf(musicTriggers, other);
        if (triggerIndex >= 0)
        {
            // stop the currently playing music if it's associated with the triggered collider
            if (currentEmitterIndex == triggerIndex)
            {
                musicEmitters[currentEmitterIndex].Stop();
                currentEmitterIndex = -1;
            }
        }
    }
}