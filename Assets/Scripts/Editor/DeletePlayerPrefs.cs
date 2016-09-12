using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class DeletePlayerPrefs {

	[MenuItem("Edit/Reset Playerprefs")] 
	public static void DeletePrefs() { 
		PlayerPrefs.DeleteAll(); 
	}
}
