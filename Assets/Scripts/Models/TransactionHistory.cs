using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionHistory {


    public string bet { get; set; }

    public string profit { get; set; }

    public string timestamp { get; set; }

    public string transaction { get; set; }


    public TransactionHistory() {



    }


    public TransactionHistory(string bet, string profit, string timestamp, string transaction) {

        this.bet = bet;
        this.profit = profit;
        this.timestamp = timestamp;
        this.transaction = transaction;

    }


}
