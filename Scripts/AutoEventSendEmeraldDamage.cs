using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SendEmeraldDamageAutoEvent", menuName = "Emerald AI/Auto Event/Send Emerald Damage", order = 51)]
public class AutoEventSendEmeraldDamage : AutoEvent
{
    [SerializeField]
    float attackTime;

    protected override AnimationEvent OnCreateAnimationEvent()
    {
        AnimationEvent evt = new AnimationEvent();
        evt.time = attackTime;
        evt.functionName = "SendEmeraldDamage";
        return evt;
    }
}
