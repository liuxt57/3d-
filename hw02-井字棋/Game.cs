using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int empty = 9;
    private int turn = 1;
    private int[,] chess = new int[3, 3];
    public Texture2D img;
    public Texture2D img1;
    public Texture2D img2;

    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    void reset()
    {
        empty = 9;
        turn = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)         
                chess[i, j] = 0;          
        }
    }

    private void OnGUI()
    {
        GUIStyle fontStyle = new GUIStyle();
        GUIStyle fontStyle1 = new GUIStyle();

        fontStyle.normal.background = img;
        fontStyle1.fontSize = 40;
        fontStyle1.normal.textColor = new Color(255, 255, 255);

        GUI.Label(new Rect(0, 0, 1500, 900),"", fontStyle);
        GUI.Label(new Rect(200, 100, 150, 150), img1);
        GUI.Label(new Rect(1000, 100, 150, 150), img2);

        if (GUI.Button(new Rect(550, 400, 200, 80), "Reset"))
        {
            reset();
        }

        int result = is_win();

        if (result == 1)
        {
            GUI.Label(new Rect(200, 250, 200, 50), "You win！", fontStyle1);
        }

        else if (result == 2)
        {
            GUI.Label(new Rect(1000, 250, 200, 50), "You win！", fontStyle1);
        }

        else if (result == 3)
        {
            GUI.Label(new Rect(550, 20, 200, 50), "no one wins", fontStyle1);
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (chess[i, j] == 1) GUI.Button(new Rect(i * 100 + 500, j * 100 + 80, 100, 100), img1);
                if (chess[i, j] == 2) GUI.Button(new Rect(i * 100 + 500, j * 100 + 80, 100, 100), img2);
                if (GUI.Button(new Rect(i * 100 + 500, j * 100 + 80, 100, 100), ""))
                {
                    if (result == 0)
                    {
                        if (turn == 1) chess[i, j] = 1;
                        if (turn == 2) chess[i, j] = 2;
                        empty--;

                        if (empty % 2 == 1)
                        {
                            turn = 1;
                        }

                        else
                        {
                            turn = 2;
                        }
                    }
                }
            }
        }
    }
    int is_win()
    {
        int temp = chess[1, 1];
        if (temp != 0)
        {
            if (temp == chess[0, 0] && temp == chess[2, 2])
            {
                return temp;
            }

            if (temp == chess[0, 2] && temp == chess[2, 0])
            {
                return temp;
            }

            if (temp == chess[0, 1] && temp == chess[2, 1])
            {
                return temp;
            }

            if (temp == chess[1, 0] && temp == chess[1, 2])
            {
                return temp;
            }
        }

        //判断是否中心的十字形或者X字形
        temp = chess[0, 0];

        if (temp != 0)
        {
            if (temp == chess[0, 1] && temp == chess[0, 2])
            {
                return temp;
            }

            if (temp == chess[1, 0] && temp == chess[2, 0])
            {
                return temp;
            }
        }

        //判断是否是第一行或者第一列相同
        temp = chess[2, 2];

        if (temp != 0)
        {
            if (temp == chess[2, 0] && temp == chess[2, 1])
            {
                return temp;
            }

            if (temp == chess[0, 2] && temp == chess[1, 2])
            {
                return temp;
            }
        }

        //判断是否是第三行或者第三列相同

        if (empty == 0)
        {
            return 3;//没有空的地方，因此双方平局
        }

        else
        {
            return 0;//还未分出胜负
        }
    }
}
