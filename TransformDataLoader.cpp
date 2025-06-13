#include "TransformDataLoader.h"
#include <fstream>   // �t�@�C���ǂݍ��ݗp
#include <sstream>   // �����񕪉�p�istringstream�jstring���t�@�C���̂悤�Ɉ�����

namespace
{
	constexpr int kElementNum = 10;
}

std::vector<ObjectData> TransformDataLoader::LoadDataCSV(const char* fileName)
{
	//�f�[�^���i�[����z��
	std::vector<ObjectData> objects;

	//�t�@�C�����J��
	std::ifstream file(fileName);
	//�������t�@�C�����J���Ȃ�������
	if (!file.is_open())return objects;//��̃��X�g��Ԃ�

	//1�s���ǂݎ��p�̕ϐ�
	std::string line;
	//�ŏ��̃w�b�_�[�̓X�L�b�v������
	bool isHeader = true;

	//CSV�̏I���܂œǂݎ��
	// getline�œǂݎ���Ă���(�ǂݎ��ʒu�i�����́u�|�C���^�v�j�́A���[�v�̂��тɑO�ɐi�݂܂�)
	//1�s���ǂݎ���Ă����ǂݎ��s���Ȃ��Ȃ�����false�ɂȂ�
	while (std::getline(file,line))//1�s���ǂݎ��
	{
		//�ŏ��̍s�̓X�L�b�v����(�w�b�_�[)
		if (isHeader)
		{
			isHeader = false;
			continue;
		}

		//�s���J���}��؂��1���ǂݍ��ނ��߂̏���
		std::stringstream ss(line);			//��������X�g���[��(getline�œǂݎ�邽��)�ɕϊ�
		std::string part;					//�������Ď��o����1�v�f
		std::vector<std::string> values;	//�v�f���܂Ƃ߂��z��

		//�J���}��؂�Ŏ��o���Ă���
		//ss����,��؂�Ŏ��o���Ă���part�ɓ���Ă���
		while (std::getline(ss, part, ',')) {
			values.emplace_back(part);           // �������ꂽ���ڂ����X�g�ɒǉ�
		}

		//�v�f����10���邩�`�F�b�N(10��K�v)
		if (values.size() < kElementNum)continue;//�Ȃ��ꍇ�͕s���ȍs�Ȃ̂Ŕ�΂�

		//�\���̂Ƀf�[�^�����Ă���
		ObjectData objData;
		
		//���O
		objData.name = values[0];
		//���W
		objData.pos.x = std::stof(values[1]);	//std::stof�͕������float�ɕϊ�����
		objData.pos.y = std::stof(values[2]);	
		objData.pos.z = std::stof(values[3]);	
		//��]
		objData.rot.x = std::stof(values[4]);	
		objData.rot.y = std::stof(values[5]);
		objData.rot.z = std::stof(values[6]);
		//�傫��
		objData.scale.x = std::stof(values[7]);	
		objData.scale.y = std::stof(values[8]);
		objData.scale.z = std::stof(values[9]);

		//�z��ɒǉ�
		objects.emplace_back(objData);
	}

	return objects;
}
