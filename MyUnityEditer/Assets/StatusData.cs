using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusData : MonoBehaviour
{
    //アーマー
    public enum Armor
    {
        Light		= 0,
		Middle		= 1,
		Heavy		= 2,
		Heaviest	= 3,
    }

    //体力
    public int hp = 0;
    //アーマー
    public Armor armor = Armor.Light;
    //攻撃力
    public int attackPower = 0;
    //移動速度
    public float speed = 0.0f;
    //探索範囲
    public float searchPlaceRang = 0.0f;
}
