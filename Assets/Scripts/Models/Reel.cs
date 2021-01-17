using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel {


    public ReelSpinReference spin { get; set; }

    public ReelSymbolReference symbol { get; set; }


    public Reel() {



    }


    public Reel(ReelSpinReference spin, ReelSymbolReference symbol) {

        this.spin = spin;
        this.symbol = symbol;

    }


}
