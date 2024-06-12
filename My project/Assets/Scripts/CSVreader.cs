using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CSVreader : MonoBehaviour
{
    public TextAsset textAssetData;
    [System.Serializable]
    public class Player
    {
        public string name;
        public int score;
        public int coins;
        public int distance;
        public int best;
    }
    public class PlayerList
    {
        public Player[] player;
    }
    public PlayerList myPlayerList = new PlayerList();


    void Update()
    {
        ReadCSV();
    }
    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tablesize = data.Length / 5 - 1;
        myPlayerList.player = new Player[tablesize];
        for (int i = 0; i < tablesize; i++)
        {
            myPlayerList.player[i] = new Player();
            myPlayerList.player[i].name = data[5 * (i + 1)];
            myPlayerList.player[i].score = int.Parse(data[5 * (i + 1) + 1]);
            myPlayerList.player[i].coins = int.Parse(data[5 * (i + 1) + 1]);
            myPlayerList.player[i].distance = int.Parse(data[5 * (i + 1) + 1]);
            myPlayerList.player[i].best = int.Parse(data[5 * (i + 1) + 1]);
        }
    }
}
