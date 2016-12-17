using UnityEngine;
using System.Collections;

public class ZombieKillCount : MonoBehaviour {
	public static int zombieKillCount =0;
	public UnityEngine.UI.Text zombieKillsText;
	public UnityEngine.UI.Text zombieKillStreak;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		zombieKillsText.text="Zombie Kills: "+zombieKillCount;
		if (zombieKillCount%5==0&&zombieKillCount!=0) // every 5 kills
		{
			StartCoroutine (zombieKillStreakText());
		}
	}

	IEnumerator zombieKillStreakText()
	{
		Debug.Log ("Kill Streak");
		zombieKillStreak.text="Kill Streak!!!";
		zombieKillStreak.gameObject.SetActive (true);
		yield return new WaitForSeconds(3.5f);
		zombieKillStreak.gameObject.SetActive (false);
	}
}
