//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using System.IO;
using UnityEngine;

namespace Utage
{

	/// <summary>
	/// ゲームで共通して使うシステムセーブデータ
	/// </summary>
	[AddComponentMenu("Utage/ADV/Internal/SystemSaveData")]
	public class AdvSystemSaveData : MonoBehaviour
	{
		/// <summary>
		/// システムセーブデータを使わない
		/// </summary>
		public bool DontUseSystemSaveData { get { return dontUseSystemSaveData; } }
		[SerializeField]
		bool dontUseSystemSaveData = false;

		[SerializeField]
		bool isAutoSaveOnQuit = true;

		FileIOManager FileIOManager { get { return this.fileIOManager ?? (this.fileIOManager = FindObjectOfType<FileIOManager>() as FileIOManager); } }
		[SerializeField]
		FileIOManager fileIOManager;

		/// <summary>
		/// ディレクトリ名
		/// </summary>
		public string DirectoryName
		{
			get { return directoryName; }
			set { directoryName = value; }
		}
		[SerializeField]
		string directoryName = "Save";

		/// <summary>
		/// ファイル名
		/// </summary>
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}
		[SerializeField]
		string fileName = "system";

		/// <summary>
		/// ファイルパス
		/// </summary>
		public string Path { get { return this.path; } }
		string path;

		/// <summary>
		/// 既読のデータ
		/// </summary>
		public AdvReadHistorySaveData ReadData { get { return this.readData; } }
		AdvReadHistorySaveData readData = new AdvReadHistorySaveData();

		/// <summary>
		/// 選択肢のデータ
		/// </summary>
		public AdvSelectedHistorySaveData SelectionData { get { return this.selectionData; } }
		AdvSelectedHistorySaveData selectionData = new AdvSelectedHistorySaveData();

		/// <summary>
		/// 回想モード用のデータ
		/// </summary>
		public AdvGallerySaveData GalleryData { get { return this.galleryData; } }
		AdvGallerySaveData galleryData = new AdvGallerySaveData();

		AdvEngine Engine { get { return this.engine; } }
		AdvEngine engine;
		
		/// <summary>
		/// 初期化フラグ
		/// </summary>
		bool isInit = false;

		/// <summary>
		/// 初期化
		/// </summary>
		public void Init(AdvEngine engine)
		{
			this.engine = engine;
			if (!TryReadSaveData())
			{
				InitDefault();
			}
			isInit = true;
		}

		bool TryReadSaveData()
		{
			if (DontUseSystemSaveData) return false;

			string saveDir = FilePathUtil.Combine(FileIOManager.SdkPersistentDataPath, DirectoryName);
			//セーブデータのディレクトリがなければ作成
			FileIOManager.CreateDirectory(saveDir);

			path = FilePathUtil.Combine(saveDir, FileName);
			if (!FileIOManager.Exists(Path)) return false;

			return FileIOManager.ReadBinaryDecode(Path, ReadBinary);			
		}

		/// <summary>
		/// デフォルト値で初期化(初回でセーブデータがない場合)
		/// </summary>
		public void InitDefault()
		{
			this.engine.Config.InitDefault();
		}

		static readonly int MagicID = FileIOManager.ToMagicID('S', 'y', 's', 't');	//識別ID
		const int Version = 3;	//最新ファイルバージョン
		const int Version2 = 2;	//旧ファイルバージョン2
		const int Version1 = 1;	//旧ファイルバージョン1

		//バイナリ読み込み
		void ReadBinary(BinaryReader reader)
		{
			int magicID = reader.ReadInt32();
			if (magicID != MagicID)
			{
				throw new System.Exception("Read File Id Error");
			}

			int fileVersion = reader.ReadInt32();
			if (fileVersion == Version)
			{
				ReadData.Read(reader);
				SelectionData.Read(reader);
				Engine.Config.Read(reader);
				GalleryData.Read(reader);
				Engine.Param.ReadSystemData(reader);
			}
			else if (fileVersion == Version2)
			{
				ReadData.Read(reader);
				Engine.Config.Read(reader);
				GalleryData.Read(reader);
				Engine.Param.ReadSystemData(reader);
			}
			else if (fileVersion == Version1)
			{
				ReadData.Read(reader);
				Engine.Config.Read(reader);
				GalleryData.Read(reader);
			}
			else
			{
				throw new System.Exception(LanguageErrorMsg.LocalizeTextFormat(ErrorMsg.UnknownVersion, fileVersion));
			}
		}

		/// <summary>
		/// 書き込み
		/// </summary>
		public void Write()
		{
			if (!DontUseSystemSaveData)
			{
				FileIOManager.WriteBinaryEncode(Path, WriteBinary);
			}
		}

		//バイナリ書き込み
		void WriteBinary(BinaryWriter writer)
		{
			writer.Write(MagicID);
			writer.Write(Version);
			ReadData.Write(writer);
			SelectionData.Write(writer);
			Engine.Config.Write(writer);
			GalleryData.Write(writer);
			Engine.Param.WriteSystemData(writer);
		}

		//セーブデータを消去して終了(SendMessageでコールバックされるので名前固定)
		void OnDeleteAllSaveDataAndQuit()
		{
			Delete();
			isInit = false;
		}

		/// <summary>
		/// セーブデータを消去
		/// </summary>
		public void Delete()
		{
			FileIOManager.Delete(Path);
		}
		//ゲーム終了時
		void OnApplicationQuit()
		{
			if (isInit)
			{
				//オートセーブ
				if (!isAutoSaveOnQuit) return;
				Write();
			}
		}
	}
}