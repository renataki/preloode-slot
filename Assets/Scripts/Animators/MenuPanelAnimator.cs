using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelAnimator : MonoBehaviour {


    public Animator animator;

    public Button button;


    public void Start() {

        button.onClick.AddListener(Toggle);

    }


    public void Update() {



    }


    public void Toggle() {

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Menu Panel Open")) {

            animator.Play("Menu Panel Close");

        } else {

            animator.Play("Menu Panel Open");

        }

    }


}
