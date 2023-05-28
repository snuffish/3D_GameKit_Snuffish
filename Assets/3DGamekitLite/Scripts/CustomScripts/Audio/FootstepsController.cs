using System;
using System.Linq;
using FMODUnity;
using Gamekit3D;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FootstepsController : MonoBehaviour {
    [SerializeField] private float maxDistance = 0.2f;
    [SerializeField] private UnityEvent onFootstep;
    private PlayerController _playerController;
    private bool _playFootstep;
    private bool _hasPlayedFootstep;

    private String getMaterial(RaycastHit hit) {
        if (hit.transform.TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer)) {
            var material = meshRenderer.materials.FirstOrDefault();
            if (material == default) return null;

            return material.name;
        }

        return null;
    }

    private void FixedUpdate() {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, maxDistance)) {
            if (!_hasPlayedFootstep) {
                if (_playFootstep) {
                    // Debug.Log($"[{gameObject.name}] Footstep Hit!!!");
                    String materialName = getMaterial(hit);
                    StudioEventEmitter emitter = (StudioEventEmitter) onFootstep.GetPersistentTarget(0);
                    emitter.SetParameter("Surface", 1);
                    onFootstep?.Invoke();
                }

                _hasPlayedFootstep = true;
            }
        } else {
            _hasPlayedFootstep = false;
        }

        _playFootstep = true;
    }
}