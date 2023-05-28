using System;
using System.Linq;
using UnityEngine;

public class SoundEmitterController : MonoBehaviour
{
    private SoundEmitterEntity[] _entities;

    private void Awake()
    {
        _entities = GetComponents<SoundEmitterEntity>();
    }

    public void PlaySoundEmitter(String name)
    {
        var entity = _entities.FirstOrDefault(entity => entity.getName().Equals(name));
        if (entity == default) {
            Debug.LogWarning($"SoundEmitterEntity with name {name} doesnt exist!");
            return;
        };
        
        entity.Play();
    }
}
