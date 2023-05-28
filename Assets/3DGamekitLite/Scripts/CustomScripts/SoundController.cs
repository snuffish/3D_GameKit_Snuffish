using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;
using System.Collections.Generic;
using UnityEditor;

#region Utils
public static class SoundUtil
{
    public static GameObject GetPlayerEllen()
    {
        return GameObject.Find("Ellen");
    }
}
#endregion

#region Struct
public enum SoundType
{
    PlayOneShotAttached,
    PlayOneShot
}

[Serializable]
public struct Params
{
    public string name;
    public float value;
}

[Serializable]
public struct Sound
{
    [Tooltip("Specify a name of this Sound (is used to target this element when executing a Function Script Call)")]
    public string soundName;

    [Tooltip("Choose the RuntimeManager EventType to be Played.")]
    public SoundType soundType;

    [Tooltip("Choose which FMOD Event that should be triggered.")]
    public EventReference eventPath;

    [Tooltip("Specify the Parameters you want to send to FMOD.")]
    public List<Params> parameters;

    [Header("[Settings] Play One Shot Attached")]
    [Tooltip("Which Object should the sound be attached to?")]
    public GameObject attachToObject;

    [Header("[Settings] Play One Shot")]
    [Tooltip("Specify where the Sound should be triggered.")]
    public Vector3 soundPosition;
}
#endregion

#region Component
public class SoundController : MonoBehaviour {
    [Header("Setup your List of Sounds for this GameObject here!")]
    public List<Sound> soundList;

    private delegate EventInstance DelegatePlayMethod(Sound sound);
    private DelegatePlayMethod executePlayMethod;

    private EventInstance PlayOneShotAttached(Sound sound)
    {
        var instance = RuntimeManager.CreateInstance(sound.eventPath);
        RuntimeManager.AttachInstanceToGameObject(instance, sound.attachToObject.transform, sound.attachToObject.GetComponent<Rigidbody>());

        if (sound.parameters.Count > 0)
            sound.parameters.ForEach(item => instance.setParameterByName(item.name, item.value));

        instance.start();
        instance.release();

        return instance;
    }

    private EventInstance PlayOneShot(Sound sound)
    {
        RuntimeManager.PlayOneShot(sound.eventPath, sound.soundPosition);
        
        // @NOTE: Empty instance for now
        EventInstance instance = new EventInstance();
        return instance;
    }

    public void PlaySound(string name) {
        PlaySound(name, default);
    }

    public EventInstance PlaySound(string name, Params? param)
    {
        var resource = GetSoundFromListByName(name);
        //if (!resource.HasValue) return;

        Sound sound = resource.Value;

        if (param.HasValue) sound.parameters.Add((Params)param);

        var logPrefix = $"Path:{sound.eventPath.Path}";

        Debug.Log($"[{logPrefix}] Play Sound!");
        if (param.HasValue) {
             Debug.Log($"With Parameter:{param.Value.value}");
        }
        var instance = GetExecuteMethod(sound).Invoke(sound);
        Debug.Log($"[{logPrefix}] Sound Complete!");

        return instance;
    }

    private DelegatePlayMethod GetExecuteMethod(Sound sound)
    {
        if (sound.soundType.Equals(SoundType.PlayOneShotAttached))
            return PlayOneShotAttached;

        if (sound.soundType.Equals(SoundType.PlayOneShot))
            return PlayOneShot;

        return default;
    }

    private Sound? GetSoundFromListByName(string name)
    {
        Sound sound = soundList.Find(sound => sound.soundName.Equals(name));

        if (sound.soundName == null || soundList.Count == 0)
            return null;

        return sound;
    }
}
#endregion
