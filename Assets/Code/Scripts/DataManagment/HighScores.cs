using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class HighScores{

	[Serializable]
	public class ScoreEntry
	{
		public string name;
		public float score;
	}
	
	public static List<ScoreEntry> highScores = new List<ScoreEntry>();
	
	public static void AddHighScore(string playerName, float currentScore)
	{
		highScores.Add(new ScoreEntry{ name = playerName, score = currentScore});
		highScores.Sort(delegate(ScoreEntry x, ScoreEntry y) { return x.score.CompareTo(y.score); });

	}

	public static void SaveScores()
	{
		highScores.Reverse ();
		FileStream fileStream = new FileStream (Application.dataPath + "/highscores.dat", FileMode.OpenOrCreate);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		try
		{
			binaryFormatter.Serialize(fileStream, highScores);
		}
		finally
		{
			fileStream.Close ();
		}
	}
	public static void LoadHighScores()
	{
		if(File.Exists(Application.dataPath + "/highscores.dat"))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = File.Open(Application.dataPath + "/highscores.dat", FileMode.Open);
			highScores = (List<ScoreEntry>)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
	}
}
