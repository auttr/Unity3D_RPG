using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Auttr/Data Attack", fileName = "Data Attack", order = 2)]
public class DataAttack : ScriptableObject
{
    [Header("§ðÀ»¤O"), Range(0, 1000)]
    public float attack;
    [Header("§ðÀ»°Ï°ì³]©w")]
    public Color attackAreaColor = new Color(1, 0, 0, 0.1f);
    public Vector3 attackAreaSize = Vector3.one;
    public Vector3 attackAreaoffset;
    [Header("§ðÀ»¹Ï¼h")]
    public LayerMask layerTarget;
    [Header("§ðÀ»©µ¿ð"),Range(0.0f, 3)]
    public float attackDelay=1;
    [Header("§ðÀ»°Êµe")]
    public AnimationClip animationClip;
    public float waitAttackEnd => animationClip.length - attackDelay;



}
