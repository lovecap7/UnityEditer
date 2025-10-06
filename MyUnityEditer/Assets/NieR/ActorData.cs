using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData : MonoBehaviour
{
    [SerializeField]
    // 位置補正の優先度の判別に使う
    public enum Priority : int
    {
        None,
        Low,        // 低
        Middle,     // 中
        High,       // 高
        Static,     // 動かない（最高）
    };
    //モデルのパス
    public string m_modelPath;
    //優先度
    public Priority m_priority;
    //当たり判定を無視するか
    public bool m_isTrough;
    //トリガー
    public bool m_isTrigger;
    //重力
    public bool m_isGravity;
}
