using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] private string TriggerOnTag;
    [SerializeField] private UnityEvent OnTriggerEvent;
    
  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TriggerOnTag))
        {
            OnTriggerEvent.Invoke();
        }
    }
}
