using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[Serializable]
public class AClip : PlayableAsset, ITimelineClipAsset
{
    public ABehaviour template = new ABehaviour ();
    public ExposedReference<AspectRatioFitter> newExposedReference;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.SpeedMultiplier | ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<ABehaviour>.Create (graph, template);
        ABehaviour clone = playable.GetBehaviour ();
        clone.newExposedReference = newExposedReference.Resolve (graph.GetResolver ());
        return playable;
    }
}
