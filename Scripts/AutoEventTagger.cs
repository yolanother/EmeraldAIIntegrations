using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoEventTagger : MonoBehaviour
{
    [SerializeField]
    public AutoEvent[] autoEvents;

    // Start is called before the first frame update
    void Start()
    {
        foreach(AutoEvent evt in autoEvents)
        {
            bool found = false;
            foreach(AnimationEvent animEvt in evt.animationClip.events)
            {
                if(animEvt.functionName == evt.Event.functionName)
                {
                    found = true;
                    break;
                }
            }
            if(!found)
            {
                evt.animationClip.AddEvent(evt.Event);
            }
        }
    }
}
