using System.Collections.Generic;

public class ReelSymbolReference {


    public float height { get; set; }

    public List<List<int>> queue { get; set; }

    public List<int> result { get; set; }


    public ReelSymbolReference() {



    }


    public ReelSymbolReference(float height, List<List<int>> queue, List<int> result) {

        this.height = height;
        this.queue = queue;
        this.result = result;

    }


}
