using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ExCharaData : MonoBehaviour
{
    public GameObject m_parentObject;
    private string m_name = "CharaStatusData";
    public string m_fileName = "Stage1";

    void Start()
    {
        List<string> lines = new List<string>();
        lines.Add("名前,ID,体力,攻撃力,防御力,移動速度,ジャンプ力,アーマー");
        foreach (Transform child in m_parentObject.transform)
        {
            var charaData = child.GetComponent<CharaStatusData>();
            var id = child.GetComponent<ID>();
            if (charaData == null) continue;

            string line = $"{child.name},{id.m_myID},{charaData.m_hp},{charaData.m_at},{charaData.m_df}," +
                $"{charaData.m_ms},{charaData.m_jp},{(int)charaData.m_ar}";
            lines.Add(line);
        }

        string path = Application.dataPath + "/CSV/NieR/" + m_fileName + "/" + m_name + ".csv";
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        // BOM付きUTF-8で出力（Excel対応）
        File.WriteAllText(path, string.Join("\n", lines), new UTF8Encoding(true));

        Debug.Log($"オブジェクトのTransform情報を出力しました: {path}");
    }
}
