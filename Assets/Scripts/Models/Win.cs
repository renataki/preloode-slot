using System.Collections.Generic;

public class Win {
    

    public decimal amount { get; set; }

    public List<int> line { get; set; }


    public Win(decimal amount, List<int> line) {

        this.amount = amount;
        this.line = line;

    }


}
