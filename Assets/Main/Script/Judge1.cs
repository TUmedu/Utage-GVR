
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Judge1 : MonoBehaviour
{

    //選択したボタンのテキストラベルと正解のテキストを比較して正誤を判定
    public void JudgeAnswer()
    {
        //正解のデータをテキストでセットする
        string answerText = "Fattiest portion of tuna";
        //選択したボタンのテキストラベルを取得する
        Text selectedBtn = this.GetComponentInChildren<Text>();

        if (selectedBtn.text == answerText)
        {
            Debug.Log("正解");
            //選択したデータをグローバル変数に保存
            ResultMgr.SetJudgeData("正解");
            SceneManager.LoadScene("Result");
        }
        else
        {
            Debug.Log("不正解");
            //選択したデータをグローバル変数に保存
            ResultMgr.SetJudgeData("不正解");
            SceneManager.LoadScene("notResult");
        }

    }

}

