using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterPanelAnimator : MonoBehaviour {


    public Animator animator;

    public Button closeButton;

    public Button openButton;


    public void Start() {

        openButton.onClick.AddListener(Open);

        closeButton.onClick.AddListener(Close);

    }


    public void Update() {



    }


    public void Open() {

        animator.Play("Filter Panel Open");

    }


    public void Close() {

        animator.Play("Filter Panel Close");

    }


}
