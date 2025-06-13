using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ���s�����Ƃ��ɐe�I�u�W�F�N�g�́u�q���I�u�W�F�N�g�v���ׂĂ� Transform�i�ʒu�E��]�E�X�P�[���j��CSV�ŏo�͂���
/// </summary>
public class ExportData : MonoBehaviour
{
    // ���̃I�u�W�F�N�g�̎q���o�͑ΏۂƂ���iUnity�G�f�B�^����1�w��j
    public GameObject m_parentObject;
    //�o�̓f�[�^�̖��O
    public string m_name = "ObjectTransformData";

    void Start()
    {
        // �o�̓f�[�^���i�[���郊�X�g
        List<string> lines = new List<string>();

        // �w�b�_�[�i�񖼁j��ǉ�
        lines.Add("Name,PosX,PosY,PosZ,RotX,RotY,RotZ,ScaleX,ScaleY,ScaleZ");

        //foreach��C++�ł����͈�for��
        // �q�I�u�W�F�N�g�����ׂĎ擾�i�e���g�����O�j
        foreach (Transform child in m_parentObject.transform)//���ׂē���Ă���
        {
            // ���[���h���W�ňʒu�E��]�E�X�P�[�����擾
            Vector3 pos = child.position;
            Vector3 rot = child.eulerAngles;      // �I�C���[�p�i�x�P�ʁj
            Vector3 scale = child.localScale;

            //$""�͕������Ԃŕ�����ɕϐ��␔��������Ƃ��Ɏg��
            //���W��傫���Ȃǂ̕ϐ����L�^���邽�߂Ɏg��
            //�@"," ���Ƃɋ�؂��Ă���
            // ���O�Ɗe�f�[�^��1�s�ɂ܂Ƃ߂Ēǉ�
            string line = $"{child.name},{pos.x},{pos.y},{pos.z},{rot.x},{rot.y},{rot.z},{scale.x},{scale.y},{scale.z}";
            lines.Add(line);//�s��ǉ�
        }

        // �t�@�C���o�͐�iAssets�t�H���_�����j
        string path = Application.dataPath + "/" + m_name + ".csv";
        //���̊֐��͔z���1�v�f�ɂ�1�s���ǉ����Ă���
        File.WriteAllLines(path, lines);//File.WriteAllLines(�t�@�C���̃p�X, ������̔z��܂��̓��X�g);

        // ���ʂ�Unity��Console�ɕ\��
        Debug.Log($"�I�u�W�F�N�g��Transform�����o�͂��܂���: {path}");
    }
}

