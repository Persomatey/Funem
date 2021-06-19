using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class DataReaderWriter : MonoBehaviour
{
	private string dataPath = "Data/data.txt";

	private string level1Str; 
	private string level2Str; 
	private string level3Str; 
	private string level4Str; 
	private string level5Str; 
	private string level6Str;

	public static bool level1;
	public static bool level2;
	public static bool level3;
	public static bool level4;
	public static bool level5;
	public static bool level6;

	private static List<string> readList = new List<string>();

	void Start()
	{
		level1 = false; 
		level2 = false; 
		level3 = false; 
		level4 = false; 
		level5 = false; 
		level6 = false;
	}

	public void ReadData()
	{
		StreamReader reader = new StreamReader(dataPath);

		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			readList.Add(line);
		}

		level1Str = readList[1];
		level2Str = readList[3];
		level3Str = readList[5];
		level4Str = readList[7];
		level5Str = readList[9];
		level6Str = readList[11];

		reader.Close();

		SetUnlockValues(); 
	}

	public void WriteData()
	{
		StreamWriter writer = new StreamWriter(dataPath);

		for (int r = 0; r < readList.Count; r++)
		{
			writer.WriteLine(readList[r]);
		}

		writer.Close();
	}

	public void AmendList(int index, string str)
	{
		readList[index] = str; 
	}

	private void SetUnlockValues()
	{
		if (level1Str == "T") { level1 = true; }

		if (level2Str == "T") { level2 = true; }

		if (level3Str == "T") { level3 = true; }

		if (level4Str == "T") { level4 = true; }

		if (level5Str == "T") { level5 = true; }

		if (level6Str == "T") { level6 = true; }
	}
}
