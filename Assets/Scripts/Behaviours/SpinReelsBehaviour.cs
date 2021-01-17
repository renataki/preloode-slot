using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinReelsBehaviour : MonoBehaviour {


    public List<GameObject> reels;

    public List<Image> reelSymbols;

    public List<Image> reelSymbols_;

    public List<Sprite> symbols;

    private Reel reel;

    private SpinStatus status;


    public void Start() {

        initialize();

    }


    public void Update() {

        modify();

    }


    public void spin() {

        if(status == SpinStatus.Idle) {

            status = SpinStatus.Spinning;
            reel.spin.count = new List<int>() {
                0, 0, 0, 0, 0
            };
            reel.spin.statuses = new List<ReelSpinStatus>() {
                ReelSpinStatus.Start, ReelSpinStatus.Start, ReelSpinStatus.Start, ReelSpinStatus.Start, ReelSpinStatus.Start
            };

        }

    }


    private void initialize() {

        initializeReel();

        initializeQueue();

        status = SpinStatus.Idle;

    }


    private void initializeReel() {

        float speed = 10;
        float distance = reelSymbols_[0].transform.localPosition.y - reelSymbols[0].transform.localPosition.y;
        float symbolHeight = distance / 3;

        reel = new Reel(
            new ReelSpinReference(
                new List<int>() {
                    0, 0, 0, 0, 0
                },
                15,
                new ReelSpinLimitReference(
                    new ReelSpinLimitCoordinateReference(
                        reels[0].transform.localPosition.y - distance + symbolHeight,
                        reels[0].transform.localPosition.y - distance
                    ),
                    new ReelSpinLimitCoordinateReference(
                        reels[0].transform.localPosition.y - distance,
                        reels[0].transform.localPosition.y
                    ),
                    new ReelSpinLimitCoordinateReference(
                        reels[0].transform.localPosition.y,
                        reels[0].transform.localPosition.y - symbolHeight
                    )
                ),
                new List<ReelSpinStatus>() {
                    ReelSpinStatus.Start, ReelSpinStatus.Start, ReelSpinStatus.Start, ReelSpinStatus.Start, ReelSpinStatus.Start
                },
                (distance / speed),
                new ReelSpinWinReference(
                    0,
                    new List<List<int>>()
                )
            ),
            new ReelSymbolReference(
                symbolHeight,
                new List<List<int>>(),
                new List<int>()
            )
        );

        for(int i = 0; i < reelSymbols.Count; i++) {

            int number = Random.Range(0, 11);
            int number_ = Random.Range(0, 11);

            if(i < 3 || i > 11) {

                number = Random.Range(1, 11);
                number_ = Random.Range(1, 11);

            }

            reelSymbols[i].sprite = symbols[number];
            reelSymbols_[i].sprite = symbols[number_];

        }

        foreach(GameObject image in reels) {

            image.transform.localPosition = new Vector3(image.transform.localPosition.x, reel.spin.limit.start.min, image.transform.localPosition.z);

        }

    }


    private void initializeQueue() {

        reel.symbol.queue = new List<List<int>>();

        for(int i = 0; i < reel.spin.duration; i++) {

            reel.symbol.queue.Add(new List<int>());

            if(i == (reel.spin.duration - 1)) {

                for(int j = 0; j < reelSymbols.Count; j++) {

                    int number = Random.Range(0, 11);

                    if(i < 3 || i > 11) {

                        number = Random.Range(1, 11);

                    }
                    
                    reel.symbol.queue[i].Add(number);

                }

            } else {

                for(int j = 0; j < reelSymbols.Count; j++) {

                    int number = Random.Range(0, 11);

                    if(i < 3 || i > 11) {

                        number = Random.Range(1, 11);

                    }

                    reel.symbol.queue[i].Add(number);

                }

            }

        }

        int index_ = reel.symbol.queue.Count - 2;
        int index = reel.symbol.queue.Count - 1;

        reel.symbol.result = new List<int>() {
            reel.symbol.queue[index][1],
            reel.symbol.queue[index][2],
            reel.symbol.queue[index_][0],
            reel.symbol.queue[index][4],
            reel.symbol.queue[index][5],
            reel.symbol.queue[index_][3],
            reel.symbol.queue[index][7],
            reel.symbol.queue[index][8],
            reel.symbol.queue[index_][6],
            reel.symbol.queue[index][10],
            reel.symbol.queue[index][11],
            reel.symbol.queue[index_][9],
            reel.symbol.queue[index][13],
            reel.symbol.queue[index][14],
            reel.symbol.queue[index_][12]
        };

    }


    private void initializeResult() {

        if(status == SpinStatus.Result) {

            int column = 1;
            int next = 3;
            
            for(int i = 0; i < reel.symbol.result.Count; i++) {

                if(column == 1) {

                    reel.spin.win.line[reel.symbol.result[i]] += 1;

                }

                if(i == next) {

                    column++;
                    next += 3;

                }

            }

            initializeQueue();

            status = SpinStatus.Idle;

        }

    }


    private void modify() {

        if(status == SpinStatus.Spinning) {

            spinning();

        } else {

            if(Input.GetKeyDown(KeyCode.Space)) {

                spin();

            }

        }

    }


    private void spinning() {

        for(int i = 0; i < reels.Count; i++) {

            if(reel.spin.count[i] <= reel.spin.duration) {

                Spin spin = new Spin(
                    false,
                    reels[i].transform.localPosition.y,
                    false
                );

                if(reel.spin.statuses[i] == ReelSpinStatus.Start) {

                    if(spin.coordinate <= reel.spin.limit.start.max) {

                        if(reel.spin.count[i] == 0) {

                            if(i > 0) {

                                if(reel.spin.statuses[(i - 1)] == ReelSpinStatus.Middle) {

                                    spin.animate = true;

                                    spin.coordinate += (reel.spin.step / 4);

                                }

                            } else {

                                spin.animate = true;

                                spin.coordinate += (reel.spin.step / 4);

                            }

                        }

                    } else if(spin.coordinate > reel.spin.limit.start.max) {

                        reel.spin.statuses[i] = ReelSpinStatus.Middle;

                    }

                } else if(reel.spin.statuses[i] == ReelSpinStatus.Middle) {

                    if(spin.coordinate >= reel.spin.limit.middle.max) {

                        spin.animate = true;

                        spin.coordinate -= reel.spin.step;

                        if(reel.spin.count[i] < reel.spin.duration) {

                            if(spin.coordinate <= reel.spin.limit.middle.max) {

                                spin.coordinate = reel.spin.limit.start.min;

                                spin.repeat = true;

                            }

                        } else {

                            if(spin.coordinate <= reel.spin.limit.end.min) {

                                reel.spin.statuses[i] = ReelSpinStatus.End;

                            }

                        }

                    }

                } else if(reel.spin.statuses[i] == ReelSpinStatus.End) {

                    if(spin.coordinate <= reel.spin.limit.end.max) {

                        spin.animate = true;

                        spin.coordinate += reel.spin.step;

                        if(spin.coordinate >= reel.spin.limit.end.max) {

                            spin.repeat = true;

                            reel.spin.statuses[i] = ReelSpinStatus.Result;

                        }

                    }

                }

                if(spin.animate) {

                    reels[i].transform.localPosition = new Vector3(reels[i].transform.localPosition.x, spin.coordinate, reels[i].transform.localPosition.z);

                }

                if(spin.repeat) {
                    
                    if(reel.spin.count[i] < reel.spin.duration) {

                        reels[i].transform.localPosition = new Vector3(reels[i].transform.localPosition.x, reel.spin.limit.middle.min, reels[i].transform.localPosition.z);

                        int minIndex = i * 3;
                        int maxIndex = minIndex + 3;

                        for(int j = minIndex; j < maxIndex; j++) {

                            reelSymbols[j].sprite = reelSymbols_[j].sprite;
                            reelSymbols_[j].sprite = symbols[reel.symbol.queue[reel.spin.count[i]][j]];

                        }

                    } else {

                        reels[i].transform.localPosition = new Vector3(reels[i].transform.localPosition.x, reel.spin.limit.start.min, reels[i].transform.localPosition.z);

                        int index = (i * 3) + 1;
                        int index_ = index - 1;
                        reelSymbols[index].sprite = reelSymbols[index_].sprite;

                        index -= 1;
                        index_ = index + 2;
                        reelSymbols[index].sprite = reelSymbols_[index_].sprite;

                        index += 2;
                        index_ = index - 1;
                        reelSymbols_[index].sprite = reelSymbols_[index_].sprite;

                    }

                    reel.spin.count[i]++;

                    bool result = true;

                    foreach(int integer in reel.spin.count) {

                        if(integer <= reel.spin.duration) {

                            result = false;

                            break;

                        }

                    }

                    if(result) {

                        status = SpinStatus.Result;

                        initializeResult();

                    }

                }

            }

        }

    }


}
