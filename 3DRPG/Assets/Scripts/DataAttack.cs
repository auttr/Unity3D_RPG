using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Auttr/Data Attack", fileName = "Data Attack", order = 2)]
public class DataAttack : ScriptableObject
{
    [Header("�����O"), Range(0, 1000)]
    public float attack;
    [Header("�����ϰ�]�w")]
    public Color attackAreaColor = new Color(1, 0, 0, 0.1f);
    public Vector3 attackAreaSize = Vector3.one;
    public Vector3 attackAreaoffset;
    [Header("�����ϼh")]
    public LayerMask layerTarget;
    [Header("��������"),Range(0.0f, 3)]
    public float attackDelay=1;
    [Header("�����ʵe")]
    public AnimationClip animationClip;
    public float waitAttackEnd => animationClip.length - attackDelay;



}
