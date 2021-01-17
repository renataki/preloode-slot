using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryBehaviour : MonoBehaviour {


    public Font font;

    public GameObject tableEntry;


    public void Start() {

        List<TransactionHistory> transactionHistories = new List<TransactionHistory>() {
            new TransactionHistory("Bet", "Profit", "Timestamp", "Transaction"),
            new TransactionHistory("Bet", "Profit", "Timestamp", "Transaction"),
            new TransactionHistory("Bet", "Profit", "Timestamp", "Transaction")
        };

        float y = -60f;

        foreach(TransactionHistory transactionHistory in transactionHistories) {

            initializeRow(new Vector3(0f, y, 0), transactionHistory);

            y -= 100f;

        }

    }


    public void Update() {


        
    }


    private void initializeRow(Vector3 position, TransactionHistory data) {

        Vector2 anchorMin = new Vector2(0.5f, 1f);
        Vector2 anchorMax = new Vector2(0.5f, 1f);
        float height = 100f;
        Vector2 pivot = new Vector2(0.5f, 0.5f);

        GameObject rowPanel = new GameObject("Panel");
        rowPanel.transform.parent = tableEntry.transform;
        rowPanel.transform.localPosition = position;
        rowPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        rowPanel.AddComponent<RectTransform>().sizeDelta = new Vector2(tableEntry.GetComponent<RectTransform>().sizeDelta.x, height);
        rowPanel.GetComponent<RectTransform>().anchorMin = anchorMin;
        rowPanel.GetComponent<RectTransform>().anchorMax = anchorMax;
        rowPanel.GetComponent<RectTransform>().pivot = pivot;

        GameObject timestampText = new GameObject("Text");
        timestampText.transform.parent = rowPanel.transform;
        timestampText.transform.localPosition = new Vector3(-750f, 0, 0);
        timestampText.transform.localScale = new Vector3(1f, 1f, 1f);
        timestampText.AddComponent<RectTransform>().sizeDelta = new Vector2(300f, height);
        timestampText.AddComponent<Text>().text = data.timestamp;
        timestampText.GetComponent<Text>().font = font;
        timestampText.GetComponent<Text>().fontSize = 40;
        timestampText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        GameObject transactionText = new GameObject("Text");
        transactionText.transform.parent = rowPanel.transform;
        transactionText.transform.localPosition = new Vector3(-300f, 0, 0);
        transactionText.transform.localScale = new Vector3(1f, 1f, 1f);
        transactionText.AddComponent<RectTransform>().sizeDelta = new Vector2(600f, height);
        transactionText.AddComponent<Text>().text = data.transaction;
        transactionText.GetComponent<Text>().font = font;
        transactionText.GetComponent<Text>().fontSize = 40;
        transactionText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        GameObject betText = new GameObject("Text");
        betText.transform.parent = rowPanel.transform;
        betText.transform.localPosition = new Vector3(200f, 0, 0);
        betText.transform.localScale = new Vector3(1f, 1f, 1f);
        betText.AddComponent<RectTransform>().sizeDelta = new Vector2(400f, height);
        betText.AddComponent<Text>().text = data.bet;
        betText.GetComponent<Text>().font = font;
        betText.GetComponent<Text>().fontSize = 40;
        betText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        GameObject profitText = new GameObject("Text");
        profitText.transform.parent = rowPanel.transform;
        profitText.transform.localPosition = new Vector3(600f, 0, 0);
        profitText.transform.localScale = new Vector3(1f, 1f, 1f);
        profitText.AddComponent<RectTransform>().sizeDelta = new Vector2(400f, height);
        profitText.AddComponent<Text>().text = data.profit;
        profitText.GetComponent<Text>().font = font;
        profitText.GetComponent<Text>().fontSize = 40;
        profitText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

    }


}
