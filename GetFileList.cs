using System;
using System.Collections;

namespace CreateVersionFile
{
	public class FileVersion
	{
		public string FileName;
		public string TimeStamp;
		public long   Size;
	}
	/// <summary>
	/// GetFileList の概要の説明です。
	/// </summary>
	public class GetFileList
	{
		private ArrayList _fileList = new ArrayList();
		private string currentPath = System.IO.Directory.GetCurrentDirectory();
		
		public GetFileList()
		{
			List(currentPath);
		}
		
		public void List(string path)
		{
			string[] files = System.IO.Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].EndsWith("CreateVersionFile.exe")) continue;
				if (files[i].EndsWith(".xml")) continue;
// MOD 2008.04.11 ACT Vista対応 START
//				if (files[i].EndsWith(".dll") && !files[i].EndsWith("AutoUpGradeUtility.dll")) continue;
				if (files[i].EndsWith(".dll") && !files[i].EndsWith("AutoUpGradeUtility.dll") && !files[i].EndsWith("CharConvUtility.dll")) continue;
// MOD 2008.04.11 ACT Vista対応 END
				System.IO.FileStream fs = new System.IO.FileStream(files[i], System.IO.FileMode.Open);

				FileVersion fileVersion = new FileVersion();
				fileVersion.FileName  = fs.Name.Substring(currentPath.Length + 1);
// MOD 2007.11.28 東都）高木 タイムスタンプの桁数障害対応 START
//				fileVersion.TimeStamp = System.IO.File.GetLastWriteTime(files[i]).ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
				fileVersion.TimeStamp = System.IO.File.GetLastWriteTime(files[i]).ToString("yyyyMMddHHmmss");
// MOD 2007.11.28 東都）高木 タイムスタンプの桁数障害対応 END
				fileVersion.Size      = fs.Length;
				
				_fileList.Add(fileVersion);
				fs.Close();
			}
			string[] directories = System.IO.Directory.GetDirectories(path);
			for (int i = 0; i < directories.Length; i++)
			{
				List(directories[i]);	
			}
		}

		public ArrayList FileList
		{
			get {return this._fileList;}
		}
	}
}
