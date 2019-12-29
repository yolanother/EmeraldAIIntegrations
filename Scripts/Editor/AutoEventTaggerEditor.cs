using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(AutoEventTagger))]
[CanEditMultipleObjects]
public class AutoEventTaggerEditor : Editor {
    private SerializedProperty property;
    private GameObject gameObject;
    private AutoEventTagger tagger;

    private void OnEnable() {
        property = serializedObject.FindProperty("autoEvents");
        tagger = (AutoEventTagger)target;
        gameObject = tagger.gameObject;
    }
    public override void OnInspectorGUI() {
        GUILayout.Label("Auto Events:");
        foreach(AutoEvent autoEvent in tagger.autoEvents) {
            if (null != autoEvent && null != autoEvent.animationClip && null != autoEvent.animationEvent) {
                GUILayout.Label("  " + autoEvent.animationClip.name + " (" + autoEvent.animationEvent.functionName + "@" + autoEvent.animationEvent.time + ")");
            }
        }
        if (GUILayout.Button("Scan for events")) {
            Animator animator = gameObject.GetComponent<Animator>();
            if (null == animator) {
                animator = gameObject.GetComponentInChildren<Animator>();
            }
            if (null == animator) {
                Debug.LogWarning("There are no animators attached to this object.");
            } else {
                List<AutoEvent> events = new List<AutoEvent>();
                var controller = animator.runtimeAnimatorController;
                foreach(AnimationClip clip in controller.animationClips) {
                    Debug.Log("  " + clip.name);
                    foreach (AnimationEvent animEvt in clip.events) {
                        AutoEvent evt = ScriptableObject.CreateInstance<AutoEvent>();
                        evt.animationClip = clip;
                        evt.animationEvent = animEvt;
                        events.Add(evt);
                        Debug.Log("    Added event " + animEvt.functionName);
                    }
                }

                tagger.autoEvents = events.ToArray();
                EditorUtility.SetDirty(target);
            }
        }
    }
}
