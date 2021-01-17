using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehaviour : MonoBehaviour {


    private bool quit;


    public void Start() {



    }


    public void Update() {

        modify();

    }


#if UNITY_ANDROID

    private class NegativeButtonListener : AndroidJavaProxy {


        private GlobalBehaviour androidDialog;


        public negativeButtonListener(GlobalBehaviour androidDialog) : base("android.content.DialogInterface$OnClickListener") {

            this.androidDialog = androidDialog;

        }


        public void onClick(AndroidJavaObject androidJavaObject, int value) {

            androidDialog.quit = false;

        }


    }


    private class PositiveButtonListener : AndroidJavaProxy {


        private GlobalBehaviour androidDialog;


        public positiveButtonListener(GlobalBehaviour androidDialog) : base("android.content.DialogInterface$OnClickListener") {

            this.androidDialog = androidDialog;

        }


        public void onClick(AndroidJavaObject androidJavaObject, int value) {

            androidDialog.quit = true;

        }


    }

#endif


    private void close() {

#if UNITY_ANDROID

        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {

            AndroidJavaObject alertDialogBuilder = new AndroidJavaObject("android/app/AlertDialog$Builder", activity);
            alertDialogBuilder.Call<AndroidJavaObject>("setMessage", "Are you sure want to quit game?");
            alertDialogBuilder.Call<AndroidJavaObject>("setCancelable", true);
            alertDialogBuilder.Call<AndroidJavaObject>("setPositiveButton", "Yes", new PositiveButtonListener(this));
            alertDialogBuilder.Call<AndroidJavaObject>("setNegativeButton", "No", new NegativeButtonListener(this));

            AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
            dialog.Call("show");

        }));

#endif

    }


    private void modify() {

        if(Input.GetKeyDown(KeyCode.Escape)) {

            close();

        }

        if(quit) {

            Application.Quit();

        }

    }


}
