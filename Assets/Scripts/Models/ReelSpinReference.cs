using System.Collections.Generic;

public class ReelSpinReference {


    public List<int> count { get; set; }

    public int duration { get; set; }

    public ReelSpinLimitReference limit { get; set; }

    public List<ReelSpinStatus> statuses { get; set; }

    public float step { get; set; }


    public ReelSpinReference() {



    }


    public ReelSpinReference(List<int> count, int duration, ReelSpinLimitReference limit, List<ReelSpinStatus> statuses, float step) {

        this.count = count;
        this.duration = duration;
        this.limit = limit;
        this.statuses = statuses;
        this.step = step;

    }


}
