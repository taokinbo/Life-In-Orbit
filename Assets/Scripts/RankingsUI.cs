using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
using System;

public class RankingsUI : MonoBehaviour
{
    public TextMeshProUGUI first;
    public TextMeshProUGUI second;
    public TextMeshProUGUI third;
    public TextMeshProUGUI fourth;
    public TextMeshProUGUI fifth;
    public TextMeshProUGUI sixth;
    public Image rankingsBoard;
    private int ascendancyIndex;

    // Start is called before the first frame update
    void Start()
    {
        rankingsBoard.GetComponent<Image>().enabled = false;
        first.GetComponent<TextMeshProUGUI>().enabled = false;
        second.GetComponent<TextMeshProUGUI>().enabled = false;
        third.GetComponent<TextMeshProUGUI>().enabled = false;
        fourth.GetComponent<TextMeshProUGUI>().enabled = false;
        fifth.GetComponent<TextMeshProUGUI>().enabled = false;
        sixth.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void rankingsBoardPopup()
    {
        rankingsBoard.GetComponent<Image>().enabled = true;
        first.GetComponent<TextMeshProUGUI>().enabled = true;
        second.GetComponent<TextMeshProUGUI>().enabled = true;
        third.GetComponent<TextMeshProUGUI>().enabled = true;
        fourth.GetComponent<TextMeshProUGUI>().enabled = true;
        fifth.GetComponent<TextMeshProUGUI>().enabled = true;
        sixth.GetComponent<TextMeshProUGUI>().enabled = true;

    }
    public void GetRankingsUI()
    {
        rankingsBoardPopup();

        Dictionary<string, int> rankings = new Dictionary<string, int>();
        ascendancyIndex = (int)Math.Ceiling(AscendancyIndexManager.Instance.GetAscendancyIndex());

        rankings.Add("Player", (int)ascendancyIndex);

        if (ascendancyIndex < 75)
        {
            rankings.Add("Gary Pine", UnityEngine.Random.Range(rankings["Player"], 90));
            rankings.Add("Will O'Wisp", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
            rankings.Add("Sycamore Reed", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
            rankings.Add("Sybil Oakley", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
            rankings.Add("Ivy Bennet", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
        }
        else if (ascendancyIndex > 75 && ascendancyIndex < 90)
        {
            rankings.Add("Gary Pine", UnityEngine.Random.Range(rankings["Player"], 90));
            rankings.Add("Will O'Wisp", UnityEngine.Random.Range(0, rankings["Player"]));
            rankings.Add("Sycamore Reed", UnityEngine.Random.Range(0, rankings["Player"]));
            rankings.Add("Sybil Oakley", UnityEngine.Random.Range(0, rankings["Player"]));
            rankings.Add("Ivy Bennet", UnityEngine.Random.Range(0, rankings["Player"]));
        }
        else
        {
            rankings.Add("Gary Pine", UnityEngine.Random.Range(89, rankings["Player"]));
            rankings.Add("Will O'Wisp", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
            rankings.Add("Sycamore Reed", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
            rankings.Add("Sybil Oakley", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
            rankings.Add("Ivy Bennet", UnityEngine.Random.Range(0, rankings["Gary Pine"]));
        }

        rankings = rankings.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        int order = 0;
        foreach (var ranking in rankings)
        {
            switch (order)
            {
                case 0:
                    first.text = "1 - " + ranking.Key + " - " + ranking.Value.ToString();
                    break;
                case 1:
                    second.text = "2 - " + ranking.Key + " - " + ranking.Value.ToString();
                    break;
                case 2:
                    third.text = "3 - " + ranking.Key + " - " + ranking.Value.ToString();
                    break;
                case 3:
                    fourth.text = "4 - " + ranking.Key + " - " + ranking.Value.ToString();
                    break;
                case 4:
                    fifth.text = "5 - " + ranking.Key + " - " + ranking.Value.ToString();
                    break;
                case 5:
                    sixth.text = "6 - " + ranking.Key + " - " + ranking.Value.ToString();
                    break;
                default:
                    break;
            }
            order++;
        }
    }

    public void closeRankingsUI()
    {
        rankingsBoard.GetComponent<Image>().enabled = false;
        first.GetComponent<TextMeshProUGUI>().enabled = false;
        second.GetComponent<TextMeshProUGUI>().enabled = false;
        third.GetComponent<TextMeshProUGUI>().enabled = false;
        fourth.GetComponent<TextMeshProUGUI>().enabled = false;
        fifth.GetComponent<TextMeshProUGUI>().enabled = false;
        sixth.GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
