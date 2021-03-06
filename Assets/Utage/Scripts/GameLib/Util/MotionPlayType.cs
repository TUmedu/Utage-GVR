//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Utage
{

	/// <summary>
	/// モーションの再生タイプ
	/// </summary>
	public enum MotionPlayType
	{
		Default,			//デフォルト(終了後は最後の格好で止まる)
		Loop,				//ループする
		IdleOnEnd,			//終了時にアイドル状態へ
		NoReplay,			//直前が同じモーションの場合は、再生しない。最後は止める
		RandomGroup,		//同じグループ内からランダム再生
	};

	public static class MotionPlayTypeUtil
	{
		//モーション変更可能かチェック
		public static bool CheckReplayMotion( string currentMotion, string nextMotion, MotionPlayType playType )
		{
			//同じモーションの場合は、プレイタイプのよってはモーションを再生しない
			if(currentMotion == nextMotion)
			{
				switch(playType)
				{
					case MotionPlayType.Loop:
					case MotionPlayType.NoReplay:
						return false;
				}
			}
			return true;
		}
	}
}
