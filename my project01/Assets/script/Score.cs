using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;
    public TextMeshProUGUI stage3;    
    public TextMeshProUGUI stage4;
    public TextMeshProUGUI stage5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stage1.text = "STAGE 1 : " + highScore.Load(1).ToString();
        stage2.text = "STAGE 2 : " + highScore.Load(2).ToString();
        stage3.text = "STAGE 3 : " + highScore.Load(3).ToString();
        stage4.text = "STAGE 4 : " + highScore.Load(4).ToString();
        stage5.text = "STAGE 5 : " + highScore.Load(5).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
