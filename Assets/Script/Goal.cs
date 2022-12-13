using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject clearText;    // 追記。レベルクリアと表示するテキストを格納
    public GameObject nextButton;   // 追記。次のレベルへ遷移するボタンを格納
    public AudioSource audioSorce;   // 音楽を再生するコンポーネント

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("ゴール！");

            clearText.SetActive(true);  // 追記。無効になって非表示になったゲームオブジェクトを
            nextButton.SetActive(true); // このタイミングで有効にする。
            audioSorce.Play();          // Playメソッドを実行することが出来る
        }
    }
}