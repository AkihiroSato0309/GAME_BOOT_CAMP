﻿using UnityEngine;
using System.Collections;

public class AnimalManager : MonoBehaviour {

	//========================================================================================
	// 定数
	//========================================================================================
	public enum eAnimals : int
	{
		Gorilla = 0,
		Lion,
		Panda,
		Pig,
		Rhino,
		Tiger,
		last
	}
	
	//========================================================================================
	// 変数
	//========================================================================================
	//--public----------------------
	public static eAnimals s_animalID;
	
	//--pirvate---------------------
	
	
	//========================================================================================
	// プロパティ。イベント
	//========================================================================================
	
	
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
}
