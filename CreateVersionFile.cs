using System;
using System.Collections;

namespace CreateVersionFile
{
	/// <summary>
	/// CreateVersionFile �̊T�v�̐����ł��B
	/// </summary>
	public class CreateVersionFile
	{
		static void Main(string[] args)
		{
			// 
			// TODO: �R���X�g���N�^ ���W�b�N�������ɒǉ����Ă��������B
			//
			//XmlSerializer�I�u�W�F�N�g���쐬
			//�������ރI�u�W�F�N�g�̌^���w�肷��
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(FileVersion[]));
			//�t�@�C�����J��
			System.IO.FileStream fs = new System.IO.FileStream("VersionFile.xml", System.IO.FileMode.Create);

			GetFileList getFileList = new GetFileList();

			FileVersion[] fl = new FileVersion[getFileList.FileList.Count];
			IEnumerator enumfl = getFileList.FileList.GetEnumerator();
			int i = 0;
			while (enumfl.MoveNext())
			{
				FileVersion fileVersion = (FileVersion)enumfl.Current;
				fl[i] = fileVersion;
				i++;
			}
			//�V���A�������AXML�t�@�C���ɕۑ�����
			if (i != 0) serializer.Serialize(fs, fl);
			//����
			fs.Close();
		}
		
	}
}
