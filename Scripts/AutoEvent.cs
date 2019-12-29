using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AutoEvent : ScriptableObject
{
    [SerializeField]
    public AnimationClip animationClip;

    [SerializeField]
    public AnimationEvent animationEvent;

    public AnimationEvent Event
    {
        get
        {
            if(null == animationEvent)
            {
                animationEvent = OnCreateAnimationEvent();
            }

            return animationEvent;
        } set {
            animationEvent = value;
        }
    }

    protected virtual AnimationEvent OnCreateAnimationEvent() {
        return animationEvent;
    }
}
