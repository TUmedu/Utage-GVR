//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------
using UnityEngine;

namespace Utage
{

	/// <summary>
	/// コマンド：ランダムにサブルーチンへジャンプ終了
	/// </summary>
	internal class AdvCommandJumpSubroutineRandomEnd : AdvCommand
	{
		public AdvCommandJumpSubroutineRandomEnd(StringGridRow row, AdvSettingDataManager dataManager)
			: base(row)
		{
		}
		//ページ区切りのコマンドか
		public override bool IsTypePageEnd() { return true; }

		public override void DoCommand(AdvEngine engine)
		{
			AdvCommandJumpSubroutineRandom command = engine.ScenarioPlayer.JumpManager.GetRandomJumpCommand() as AdvCommandJumpSubroutineRandom;
			if (command != null)
			{
				command.DoRandomEnd(engine);
			}
		}
	}
}
