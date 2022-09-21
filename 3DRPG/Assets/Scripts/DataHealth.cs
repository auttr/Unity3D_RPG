using UnityEditor;
using UnityEngine;
namespace aa
{
    /// <summary>
    /// ��q���
    /// </summary>
    [CreateAssetMenu(fileName ="Data Health",menuName ="Auttr/Data Health",order =4)]
    public class DataHealth : ScriptableObject
    {
        [Header("��q"), Range(0, 1000)] 
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("�O�_�����_��")]
        public bool isDropProp;
        [HideInInspector, Header("�_�����m��")]
        public GameObject goProp;
        [HideInInspector, Header("�_�������v"), Range(0.0f, 1.0f)]
        public float propProbability;
    }

    [CustomEditor(typeof (DataHealth))]
    public class DataHealthEditor:Editor
    {
        SerializedProperty spIsDropProp;
        SerializedProperty spGoProp;
        SerializedProperty spPropProbability;
        private void OnEnable()
        {
            spIsDropProp = serializedObject.FindProperty(nameof(DataHealth.isDropProp));
            spGoProp = serializedObject.FindProperty(nameof(DataHealth.goProp));
            spPropProbability = serializedObject.FindProperty(nameof(DataHealth.propProbability));
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();
            if (spIsDropProp.boolValue)
            {
                EditorGUILayout.PropertyField(spGoProp);
                EditorGUILayout.PropertyField(spPropProbability);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }

}
