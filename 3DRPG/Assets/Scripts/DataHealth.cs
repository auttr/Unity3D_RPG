using UnityEditor;
using UnityEngine;
namespace aa
{
    /// <summary>
    /// 血量資料
    /// </summary>
    [CreateAssetMenu(fileName ="Data Health",menuName ="Auttr/Data Health",order =4)]
    public class DataHealth : ScriptableObject
    {
        [Header("血量"), Range(0, 1000)] 
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("是否掉落寶物")]
        public bool isDropProp;
        [HideInInspector, Header("寶物欲置物")]
        public GameObject goProp;
        [HideInInspector, Header("寶物掉落率"), Range(0.0f, 1.0f)]
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
