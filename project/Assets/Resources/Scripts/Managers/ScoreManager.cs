﻿//========================================================================================
//
// 製作者 :　大榮圭祐
//
//========================================================================================

using UnityEngine;
using System.Collections;

public class ScoreManager {
//========================================================================================
// 定数
//========================================================================================
	
	
//========================================================================================
// 変数
//========================================================================================
	//--public----------------------
	
	
	//--pirvate---------------------
	private int collectedCoinNum = 0;

	
//========================================================================================
// プロパティ。イベント
//========================================================================================
	public delegate void CollectedCoinNumChangeEventHandler();
	public event CollectedCoinNumChangeEventHandler OnChangedCollectedCoinNum;

	public int CollectedCoinNum {
		get { return this.collectedCoinNum; }
		private set { this.collectedCoinNum = value; this.OnChangedCollectedCoinNum(); }
	}
	
	
//========================================================================================
// 関数
//========================================================================================
	//--------------------------------------------------------
	// 初期化処理
	//--------------------------------------------------------
	void Start () 
	{
		
	}
	
	//--------------------------------------------------------
	// 更新処理
	//--------------------------------------------------------
	void Update () 
	{
		
	}

	//--------------------------------------------------------
	// コイン増加処理
	//--------------------------------------------------------
	void AddCollectedCoin ( int num = 1 )
	{
		this.CollectedCoinNum += num;
	}
}
