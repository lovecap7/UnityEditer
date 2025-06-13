#pragma once
#include <DxLib.h>
#include <string>
#include <vector>
// �I�u�W�F�N�g�̏����i�[����\����
struct ObjectData {
    std::string name; // �I�u�W�F�N�g��
    VECTOR pos;       // �ʒu
    VECTOR rot;       // ��]�i���W�A���j
    VECTOR scale;     // �X�P�[��
};

class TransformDataLoader
{
public:
    TransformDataLoader();
	virtual ~TransformDataLoader();

    /// <summary>
    /// CSV�t�@�C������I�u�W�F�N�g��Tranceform�����擾
    /// </summary>
    /// <param name="fileName">csv</param>
    /// <returns></returns>
    static std::vector<ObjectData> LoadDataCSV(const char* fileName);
};

