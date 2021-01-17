public class ReelSpinLimitReference {


    public ReelSpinLimitCoordinateReference end { get; set; }

    public ReelSpinLimitCoordinateReference middle { get; set; }

    public ReelSpinLimitCoordinateReference start { get; set; }


    public ReelSpinLimitReference() {



    }


    public ReelSpinLimitReference(ReelSpinLimitCoordinateReference end, ReelSpinLimitCoordinateReference middle, ReelSpinLimitCoordinateReference start) {
        
        this.end = end;
        this.middle = middle;
        this.start = start;

    }


}
