using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatusData;

public class CharaStatusData : MonoBehaviour
{
    [SerializeField]
    //攻撃でひるまない強さ
    public enum Armor : int
    {
        Light = 0,
		Middle = 1,
		Heavy = 2,
		Heaviest = 3,
	};  
    public int      m_hp;   //最大体力
    public int      m_at;   //攻撃力
    public int      m_df;   //防御力
    public float    m_ms;   //移動速度
    public float    m_jp;   //ジャンプ力
    public Armor    m_ar;   //アーマー
}
