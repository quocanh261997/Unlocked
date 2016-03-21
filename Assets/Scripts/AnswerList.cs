
using System.Collections.Generic;
using System;
using UnityEngine;

class AnswerList : MonoBehaviour
{
	static long count = 0;
	static string[] rules = new string[10] {
		"123456789",
		"26584",
		"1345679",
		"26584",
		"1235789",
		"12346789",
		"1235789",
		"26584",
		"1345679",
		"26584"
	};
	static List<string>[] result = new List<string>[9];

	static void Try (string s)
	{
		count += 1;
		if (s.Length > 0)
			result [s.Length - 1].Add (s);
		if (s.Length < 9) {
			if (s == "") {
				for (int i = 0; i < rules[0].Length; i++)
					Try (s + rules [0] [i]);
			} else {
				int index = Int32.Parse (s [s.Length - 1] + "");
				//Console.WriteLine("index: "+index);
            
				for (int i = 0; i < rules[index].Length; i++)
					if (!s.Contains (rules [index] [i] + "")) {
						Try (s + rules [index] [i]);
					}
			}
		}
	}

	public static string TakeRandom (int length)
	{
		return result [length-1] [UnityEngine.Random.Range(0, result[length-1].Count)];
	}

	public void Awake ()
	{
		for (int i = 0; i < 9; i++)
			result [i] = new List<string> ();
		Try ("");
	}
}
