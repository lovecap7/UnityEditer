using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using static EXNieR;

public class EXNieR : MonoBehaviour
{
    public GameObject m_parentObject;
    public string m_name = "ObjectTransformData";
    public string m_fileName = "Stage1";

    public enum ActorType { None, Character, Stage, Attack };
    public ActorType m_actorType = ActorType.None;

    void Start()
    {
        List<string> lines = new List<string>();
        lines.Add("名前,アクタータイプ,座標X,座標Y,座標Z,回転X,回転Y,回転Z,大きさX,大きさY,大きさZ,モデルのパス,優先度,ゲームタグ,当たり判定無視,トリガー,重力を受ける,コリジョンの半径,コリジョンの高さ");

        string actorType = m_actorType.ToString();

        foreach (Transform child in m_parentObject.transform)
        {
            var actorData = child.GetComponent<ActorData>();
            if (actorData == null) continue;

            Vector3 pos = child.position;
            Vector3 rot = child.eulerAngles;
            Vector3 scale = child.localScale;

            //フラグ
            string isTrough = "false";
            if(actorData.m_isTrough) isTrough="true";
            string isTrigger = "false";
            if (actorData.m_isTrigger) isTrigger = "true";
            string isGravity = "false";
            if (actorData.m_isGravity) isGravity = "true";

            string line = $"{child.name},{actorType},{pos.x},{pos.y},{pos.z}," +
                          $"{rot.x},{rot.y},{rot.z},{scale.x},{scale.y},{scale.z}," +
                          $"{actorData.m_modelPath},{actorData.m_priority},{actorData.m_gameTag},{isTrough},{isTrigger},{isGravity}," +
                          $"{actorData.m_collRadius},{actorData.m_collHeight}";
            lines.Add(line);
        }

        string path = Application.dataPath + "/CSV/NieR/" + m_fileName + "/" + m_name + ".csv";
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        // BOM付きUTF-8で出力（Excel対応）
        File.WriteAllText(path, string.Join("\n", lines), new UTF8Encoding(true));

        Debug.Log($"オブジェクトのTransform情報を出力しました: {path}");
    }
}
