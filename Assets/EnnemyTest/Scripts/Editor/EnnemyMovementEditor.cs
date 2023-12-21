using System;
using UnityEditor;

[CustomEditor(typeof(EnnemyMovement))]
public class EnnemyMovementEditor : Editor
{
    private SerializedProperty _mouvementConfig;

    private SerializedProperty _positionArrayLoop;
    private SerializedProperty _positionArraySecondeLoop;

    private SerializedProperty _smoothSpeed;
    private SerializedProperty _distanceChangeIndex;
    
    private void OnEnable()
    {
        _mouvementConfig = serializedObject.FindProperty("MouvementConfig");

        _positionArrayLoop = serializedObject.FindProperty("positionArrayLoop");
        _positionArraySecondeLoop = serializedObject.FindProperty("_positionArraySecondeLoop");
        _distanceChangeIndex = serializedObject.FindProperty("_distanceChangeIndex");

        _smoothSpeed = serializedObject.FindProperty("_smoothSpeed");
    }

    public override void OnInspectorGUI()
    {
        EnnemyMovement ennemyMovement = (EnnemyMovement)target;
        
        serializedObject.Update();

        EditorGUILayout.PropertyField(_mouvementConfig);
        
        EditorGUILayout.PropertyField(_positionArrayLoop);
        if (ennemyMovement.MouvementConfig == MouvementConfig.StableAndLoop)
        {
            EditorGUILayout.PropertyField(_positionArraySecondeLoop);
        }
        EditorGUILayout.PropertyField(_distanceChangeIndex);
        
        EditorGUILayout.Space(5);
        EditorGUILayout.PropertyField(_smoothSpeed);
        

        serializedObject.ApplyModifiedProperties();
    }
}
