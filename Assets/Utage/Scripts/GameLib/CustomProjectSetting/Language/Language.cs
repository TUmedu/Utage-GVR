//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------
/*
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utage
{

	/// <summary>
	/// 表示言語切り替え用のクラス
	/// </summary>
	public class Language
	{
		/// <summary>
		/// 対応する言語リスト
		/// </summary>
		public List<string> Languages { get { return languages; } }
		List<string> languages = new List<string>();

		//言語による表示テキストデータ
		Dictionary<string, StringGridRow> dataTbl = new Dictionary<string, StringGridRow>();

		StringGrid Grid { get; set; }

		public Language( StringGrid grid )
		{
			//データ解析
			ParseData(grid);
		}

		public Language( TextAsset csv )
		{
			//データ解析
			ParseData(csv);
		}

		/// <summary>
		/// キーがあるか
		/// </summary>
		/// <param name="key">テキストのキー</param>
		/// <returns>あればtrue。なければfalse</returns>
		public bool ContainsKey(string key)
		{
			return dataTbl.ContainsKey(key);
		}

		static bool isLocalizing = false;
		/// <summary>
		/// キーから設定言語のテキストを取得
		/// </summary>
		/// <param name="laguage">言語名</param>
		/// <param name="key">テキストのキー</param>
		/// <returns>対応言語のテキスト</returns>
		internal string LocalizeText(string laguage, string defaultLaguage, string key)
		{
			if (isLocalizing) return key;

			isLocalizing = true;
			string text = LocalizeTextSub(laguage, key);
			isLocalizing = false;

			return text;
		}
		/// <summary>
		/// キーから設定言語のテキストを取得
		/// </summary>
		/// <param name="laguage">言語名</param>
		/// <param name="key">テキストのキー</param>
		/// <returns>対応言語のテキスト</returns>
		string LocalizeTextSub(string laguage, string key)
		{
			StringGridRow val;
			if (!dataTbl.TryGetValue(key, out val))
			{
				Debug.LogError(key + ": is not found in Language data");
				return key;
			}
			else
			{
				if (string.IsNullOrEmpty(laguage))
				{
					return key;
				}
				else
				{
					string text;
					if (val.TryParseCell<string>(laguage, out text))
					{
						return text.Replace(@"\n", "\n");
					}
					else
					{
						return key;
					}
				}
			}
		}

		void ParseData(TextAsset csv)
		{
			dataTbl.Clear();
			ParseData(new StringGrid(csv.name, CsvType.Tsv, csv.text));
		}

		void ParseData(StringGrid grid)
		{
			this.Grid = grid;
			if (Grid.Rows.Count <= 0) return;

			foreach (StringGridRow row in Grid.Rows)
			{
				if (row.IsEmpty) continue;
				dataTbl.Add(row.ParseCell<string>("Key"), row);
			}

			StringGridRow header = Grid.Rows[0];
			for (int i = 0; i < header.Length; ++i)
			{
				if (i == 0) continue;
				if (string.IsNullOrEmpty(header.Strings[i])) continue;
				languages.Add(header.Strings[i]);
			}
		}
	}
}*/