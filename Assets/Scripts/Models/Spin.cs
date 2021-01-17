using System.Collections.Generic;

public class Spin {


    public bool animate { get; set; }

    public float coordinate { get; set; }

    public bool repeat { get; set; }


    public Spin() {



    }


    public Spin(bool animate, float coordinate, bool repeat) {

        this.animate = animate;
        this.coordinate = coordinate;
        this.repeat = repeat;

    }


}
