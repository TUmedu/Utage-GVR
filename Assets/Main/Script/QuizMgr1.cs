using UnityEngine;
using System.Collections;
using UnityEngine.UI;//UI オブジェクトを扱う時は必須
public class QuizMgr1 : MonoBehaviour
{

    //アタッチしたオブジェクトが呼ばれた時に実行される。
    void Start()
    {
        QuestionLabelSet();
        AnswerLabelSet();
    }

    private void QuestionLabelSet()
    {
        //特定の名前のオブジェクトを検索してアクセス
        Text qLabel = GameObject.Find("Canvas/QLabel").GetComponentInChildren<Text>();
        //データをセットすることで、既存情報を上書きできる
        qLabel.text = "大トロは英語で何という？";
    }

    private void AnswerLabelSet()
    {
        //回答文面の作成
        string[] array = new string[] { "Toro", "Pizza", "Fattiest portion of tuna" };
        //ボタンが4つあるのでそれぞれ代入
        for (int i = 1; i <= 3; i++)
        {
            Text ansLabel = GameObject.Find("Canvas/AnsButton" + i).GetComponentInChildren<Text>();
            ansLabel.text = array[i - 1];
        }
    }
}
