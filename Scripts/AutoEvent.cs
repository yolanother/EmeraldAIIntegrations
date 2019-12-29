using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AutoEvent
{
    [SerializeField]
    public AnimationClip animationClip;

    [SerializeField]
    public String functionName;

    [SerializeField]
    public float time;

    public AnimationEvent Event
    {
        get
        {
            AnimationEvent animationEvent = new AnimationEvent();
            animationEvent.functionName = functionName;
            animationEvent.time = time;
            return animationEvent;
        } set {
            functionName = value.functionName;
            time = value.time;
        }
    }
}
