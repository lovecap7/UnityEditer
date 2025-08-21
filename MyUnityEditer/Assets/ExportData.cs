using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 実行したときに親オブジェクトの「子供オブジェクト」すべての Transform（位置・回転・スケール）をCSVで出力する
/// </summary>
public class ExportData : MonoBehaviour
{
    // このオブジェクトの子を出力対象とする（Unityエディタから1つ指定）
    public GameObject m_parentObject;
    //出力データの名前
    public string m_name = "ObjectTransformData";


    //出力先
    public string m_fileName = "Stage1";

    void Start()
    {
        // 出力データを格納するリスト
        List<string> lines = new List<string>();

        // ヘッダー（列名）を追加
        lines.Add("Name,PosX,PosY,PosZ,RotX,RotY,RotZ,ScaleX,ScaleY,ScaleZ,GroupTag,HP,Armor,AttackPower,Speed,SearchPlaceRang");

        //foreachはC++でいう範囲for文
        // 子オブジェクトをすべて取得（親自身を除外）
        foreach (Transform child in m_parentObject.transform)//すべて入れていく
        {
            // ワールド座標で位置・回転・スケールを取得
            Vector3 pos = child.position;
            Vector3 rot = child.eulerAngles;      // オイラー角（度単位）
            Vector3 scale = child.localScale;
            //グループ
            string tagName  = child.tag;
            //ステータス
            int hp = 0;
            int armor = 0;
            int attackPower = 0;
            float speed = 0.0f;
            float searchPlaceRang = 0.0f;
            //ステータスがあるかどうか
            if(child.GetComponent<StatusData>())
            {
                StatusData status = child.GetComponent<StatusData>();
                hp = status.hp;
                armor = (int)status.armor;
                attackPower = status.attackPower;
                speed = status.speed;
                searchPlaceRang = status.searchPlaceRang;
            }

            //$""は文字列補間で文字列に変数や数式を入れるときに使う
            //座標や大きさなどの変数を記録するために使う
            //　"," ごとに区切っていく
            // 名前と各データを1行にまとめて追加
            string line = $"{child.name},{pos.x},{pos.y},{pos.z},{rot.x},{rot.y},{rot.z},{scale.x},{scale.y},{scale.z},{tagName},{hp},{armor},{attackPower},{speed},{searchPlaceRang}";
            lines.Add(line);//行を追加
        }

        // ファイル出力先（Assetsフォルダ直下）
        string path = Application.dataPath + "/CSV/" +m_fileName + "/" + m_name + ".csv";
        //この関数は配列の1要素につき1行ずつ追加していく
        File.WriteAllLines(path, lines);//File.WriteAllLines(ファイルのパス, 文字列の配列またはリスト);

        // 結果をUnityのConsoleに表示
        Debug.Log($"オブジェクトのTransform情報を出力しました: {path}");
    }
}

