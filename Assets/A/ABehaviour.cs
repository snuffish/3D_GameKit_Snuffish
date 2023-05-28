using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[Serializable]
public class ABehaviour : PlayableBehaviour
{
    public AspectRatioFitter newExposedReference;
    public Vector3 newBehaviourVariable;

    public override void OnGraphStart (Playable playable)
    {
        
    }
}
