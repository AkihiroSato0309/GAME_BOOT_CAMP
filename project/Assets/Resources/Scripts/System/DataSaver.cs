using UnityEngine;
using System.IO;
using System.Collections;

public static class DataSaver {
	
	private enum eLatestDataType {
		LATEST_SCORE,
		LATEST_COIN
	}

	private enum eUserDataType {
		HIGHEST_SCORE,
		COIN_NUM,
		HEART_NUM
	}
	
	public static string GetLatestScore () {
		string filePath = Application.persistentDataPath + "/LatestData";

		// Read score from file
		string[] scoreArray;
		scoreArray = File.ReadAllLines (filePath, System.Text.Encoding.Unicode);

		return scoreArray [(int)eLatestDataType.LATEST_SCORE];
	}

	public static string GetLatestCoinNum () {
		string filePath = Application.persistentDataPath + "/LatestData";
		
		// Read score from file
		string[] scoreArray;
		scoreArray = File.ReadAllLines (filePath, System.Text.Encoding.Unicode);
		
		return scoreArray [(int)eLatestDataType.LATEST_COIN];
	}

	public static string GetHighestScore () {
		string filePath = Application.persistentDataPath + "/UserData";

		// Read score from file
		string[] scoreArray;
		scoreArray = File.ReadAllLines (filePath, System.Text.Encoding.Unicode);

		return scoreArray [(int)eUserDataType.HIGHEST_SCORE];
	}

	public static string GetCoinNum () {
		string filePath = Application.persistentDataPath + "/UserData";
		
		// Read score from file
		string[] scoreArray;
		scoreArray = File.ReadAllLines (filePath, System.Text.Encoding.Unicode);
		
		return scoreArray [(int)eUserDataType.COIN_NUM];
	}

	public static string GetHeartNum () {
		string filePath = Application.persistentDataPath + "/UserData";
		
		// Read score from file
		string[] scoreArray;
		scoreArray = File.ReadAllLines (filePath, System.Text.Encoding.Unicode);
		
		return scoreArray [(int)eUserDataType.HEART_NUM];
	}

	public static void FirstDataCreate () {
		string filePath = Application.persistentDataPath + "/UserData";

		if (!File.Exists (filePath)) {
			string[] scoreArray = new string[2];
			scoreArray[0] = "0";
			scoreArray[1] = "0";
			//stuff that isn't supported in the web player
			File.WriteAllLines (filePath, scoreArray, System.Text.Encoding.Unicode);
			return;
		}

		filePath = Application.persistentDataPath + "/LatestData";

		if (!File.Exists (filePath)) {
			string[] scoreArray = new string[2];
			scoreArray[0] = "0";
			scoreArray[1] = "0";
			File.WriteAllLines (filePath, scoreArray, System.Text.Encoding.Unicode);
			return;
		}

		filePath = Application.persistentDataPath + "/HeartData";
		
		if (!File.Exists (filePath)) {
			string[] scoreArray = new string[1];
			scoreArray[0] = "0";
			File.WriteAllLines (filePath, scoreArray, System.Text.Encoding.Unicode);
			return;
		}
	}

	public static void SaveData (int latestScore, int latestCoinNum) {
		// Save latest data
		string filePath = Application.persistentDataPath + "/LatestData";
		string[] scoreArray = new string[2];

		if (File.Exists (filePath)) {
			scoreArray[0] = latestScore.ToString ();
			scoreArray[1] = latestCoinNum.ToString ();
			File.WriteAllLines (filePath, scoreArray, System.Text.Encoding.Unicode);
		}

		// Save user data
		filePath = Application.persistentDataPath + "/UserData";

		if (File.Exists (filePath)) {
			// Read score from file
			string[] userDataArray;
			userDataArray = File.ReadAllLines (filePath, System.Text.Encoding.Unicode);

			if (latestScore > int.Parse(userDataArray[0])) {
				userDataArray[0] = latestScore.ToString ();
			}

			int coinNum = int.Parse(userDataArray[1]) + latestCoinNum;
			userDataArray[1] = coinNum.ToString ();

			File.WriteAllLines (filePath, userDataArray, System.Text.Encoding.Unicode);
		}
	}

	public static void SaveHeartData (int heartNum) {
		string filePath = Application.persistentDataPath + "/HeartData";
		
		if (File.Exists (filePath)) {
			string[] heartArray = new string[1];
			heartArray[0] = heartNum.ToString ();
			File.WriteAllLines (filePath, heartArray, System.Text.Encoding.Unicode);
		}
	}
}
