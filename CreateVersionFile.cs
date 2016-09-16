using System;
using System.Collections;

namespace CreateVersionFile
{
	/// <summary>
	/// CreateVersionFile の概要の説明です。
	/// </summary>
	public class CreateVersionFile
	{
		static void Main(string[] args)
		{
			// 
			// TODO: コンストラクタ ロジックをここに追加してください。
			//
			//XmlSerializerオブジェクトを作成
			//書き込むオブジェクトの型を指定する
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(FileVersion[]));
			//ファイルを開く
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
			//シリアル化し、XMLファイルに保存する
			if (i != 0) serializer.Serialize(fs, fl);
			//閉じる
			fs.Close();
		}
		
	}
}
