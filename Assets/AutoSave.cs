using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData
{
	public static string playerName = "Unknow";
	public static int playerLevel = 1;
	public static int sence = 0;
}
public class AutoSave  
{
	public static void Save()
	{
		GameData.playerName = "Job";
		GameData.playerLevel = 10;
		GameData.sence = test.scene;

		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		using (FileStream fs = new FileStream ("gamesave.bin", FileMode.Create, FileAccess.Write))
		{
			binaryFormatter.Serialize (fs, GameData.playerName);
			binaryFormatter.Serialize (fs, GameData.playerLevel);
			binaryFormatter.Serialize (fs, GameData.sence);
		}
	}

	public static void Load ()
	{
		if (!File.Exists ("gamesave.bin"))
			return;

		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		using (FileStream fs = new FileStream("gamesave.bin", FileMode.Open, FileAccess.Read))
		{
			GameData.playerName = (string)binaryFormatter.Deserialize (fs);
			GameData.playerLevel = (int)binaryFormatter.Deserialize (fs);
			SceneManager.LoadSceneAsync (GameData.sence);
		}
	}
}
