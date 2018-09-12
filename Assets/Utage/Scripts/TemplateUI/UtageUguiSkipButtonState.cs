//----------------------------------------------
// UTAGE: Unity Text Adventure Game Engine
// Copyright 2014 Ryohei Tokimura
//----------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utage;


/// <summary>
/// スキップボタンのステートチェンジ
/// </summary>
[AddComponentMenu("Utage/TemplateUI/SkipButtonState")]
public class UtageUguiSkipButtonState : MonoBehaviour
{
	/// <summary>ADVエンジン</summary>
	public AdvEngine Engine { get { return this.engine ?? (this.engine = FindObjectOfType<AdvEngine>()); } }
	[SerializeField]
	AdvEngine engine;

	public Toggle target;

	void Update()
	{
		if(target==null) return;

		//スキップ可能なページか
		target.interactable = Engine.Page.EnableSkip();
	}
}

