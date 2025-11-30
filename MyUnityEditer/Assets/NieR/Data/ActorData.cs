using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData : MonoBehaviour
{
    [SerializeField]
    // 位置補正の優先度の判別に使う
    public enum Priority
    {
        None,
        Low,        // 低
        Middle,     // 中
        High,       // 高
        Static,     // 動かない（最高）
    };
    public enum GameTag
    {
        None,
        Player,     //プレイヤー
        Enemy,      //敵
        Item,       //アイテム
        Object,     //障害物
        Field,      //フィールド
        Attack,     //攻撃
        Area,       //エリア
        Sky,        //空
    };
    //モデルのパス
    public string m_modelPath;
    //優先度
    public Priority m_priority;
    //ゲームタグ
    public GameTag m_gameTag;
    //当たり判定を無視するか
    public bool m_isTrough;
    //トリガー
    public bool m_isTrigger;
    //重力
    public bool m_isGravity;
    //コリジョンの半径(ポリゴン以外で必要)
    public float m_collRadius;
    //高さ(カプセルで必要)
    public float m_collHeight;
    //パスをまとめたパス
    public string m_csvPathData = "None";
}
