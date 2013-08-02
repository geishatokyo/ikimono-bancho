// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[CustomEditor(typeof(RNTween.TweenTransform))]
public class TweenTransformEditor : Editor
{
    SerializedObject so;

    new SerializedProperty target;
    SerializedProperty loop;
    SerializedProperty tweenerType;
    SerializedProperty tweenInfos;

    RNTween.TweenTransform tweenTransform
    {
        get { return base.target as RNTween.TweenTransform; }
    }

    void OnEnable()
    {
        so = new SerializedObject(tweenTransform);

        target = so.FindProperty("target");
        loop = so.FindProperty("loop");
        tweenerType = so.FindProperty("tweenerType");
        tweenInfos = so.FindProperty("tweenInfos");
    }


    void OnSceneGUI()
    {
        var tt = tweenTransform;
        if (tt.target != null && tt.target != tt.transform)
        {
            using (new UndoHelp(tt.target, "TweenTransformEditor.Handles.PositionHandle"))//Ã»²âÊÔ¹ý???????????????
            {
                tt.target.position = Handles.PositionHandle(tt.target.position, Quaternion.identity);
            }
        }
    }


    public override void OnInspectorGUI()
    {
        var tt = tweenTransform;

        // Grab the latest data from the object
        so.Update();

        EditorGUILayout.PropertyField(target);
        EditorGUILayout.PropertyField(loop);
        EditorGUILayout.PropertyField(tweenerType);
        tt.triggerEvent = (TweenTriggerEvent)EditorGUILayout.EnumMaskField("trigger event", tt.triggerEvent);
        EditorGUILayout.PropertyField(tweenInfos, true);

        vectorsUI();

        // Apply the property, handle undo
        so.ApplyModifiedProperties();
    }


    List<bool> shows = new List<bool>();
    void vectorsUI()
    {
        //
        var tt = tweenTransform;
        Transform target = tt.target;
        if (target == null)
            target = tt.transform;


        //
        while (shows.Count < tt.vectors.Count)
            shows.Add(true);



        //
        int remove = -1;
        for (int i = 0; i < tt.vectors.Count; ++i)
        {
            //
            shows[i] = EditorGUILayout.Foldout(shows[i], " [ " + i + " ]");
            if (shows[i])
            {
                EditorGUILayout.BeginHorizontal();

                tt.vectors[i] = EditorGUILayout.Vector3Field("vector", tt.vectors[i]);
                //
                if (GUILayout.Button("remove", GUILayout.Width(60)))
                {
                    remove = i;
                }

                EditorGUILayout.EndHorizontal();



                //
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("cap pos"))
                {
                    Undo.RegisterUndo(tweenTransform, "TweenTransformEditor.cp");
                    tt.vectors[i] = target.localPosition;
                }
                if (GUILayout.Button("cap scale"))
                {
                    Undo.RegisterUndo(tweenTransform, "TweenTransformEditor.cs");
                    tt.vectors[i] = target.localScale;
                }
                if (GUILayout.Button("cap eulAng"))
                {
                    Undo.RegisterUndo(tweenTransform, "TweenTransformEditor.ce");
                    tt.vectors[i] = target.localEulerAngles;
                }
                EditorGUILayout.EndHorizontal();


                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("set pos"))
                {
                    Undo.RegisterUndo(target, "TweenTransformEditor.sp");
                    target.localPosition = tt.vectors[i];
                }
                if (GUILayout.Button("set scale"))
                {
                    Undo.RegisterUndo(target, "TweenTransformEditor.ss");
                    target.localScale = tt.vectors[i];
                }
                if (GUILayout.Button("set eulAng"))
                {
                    Undo.RegisterUndo(target, "TweenTransformEditor.se");
                    target.localEulerAngles = tt.vectors[i];
                }
                EditorGUILayout.EndHorizontal();
            }
        }



        //
        EditorGUILayout.Space();
        if (GUILayout.Button("add"))
        {
            Undo.RegisterUndo(tweenTransform, "TweenTransformEditor.addV");
            tt.vectors.Add(Vector3.zero);
        }

        if (remove != -1)
            removeV(remove);
    }


    void removeV(int index)
    {
        Undo.RegisterUndo(tweenTransform, "TweenTransformEditor.removeV");
        var tt = tweenTransform;
        tt.vectors.RemoveAt(index);

        foreach(var info in tt.tweenInfos)
        {
            if (info.fromIndex > index)
                --info.fromIndex;
            if (info.toIndex > index)
                --info.toIndex;
        }
    }
}

