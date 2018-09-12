using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public static int qCount;

	public void  NextScene(){
	
		if (Application.loadedLevelName == "Title") {
			Application.LoadLevel ("Main");
		
		}
	}

	public void NextQuiz(){
	
		if (Application.loadedLevelName == "Result") {
			 
			if(qCount < 2){
				qCount++;
				Application.LoadLevel ("Main");
			}else{
				qCount = 0;
				Application.LoadLevel ("Score");
			}
		}
	}

	public void  BackToTitle(){
		
		if (Application.loadedLevelName == "Score") {
			ResultMgr.SetScoreData(0);
			Application.LoadLevel ("Title"); 
		}
	}

}
