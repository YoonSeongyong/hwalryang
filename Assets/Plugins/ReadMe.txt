Welcome to the Plato Evolved Unity Google Play Game Services Plugin for Android (v1.03)

Preparation

First you need to set up your game in the Google Developer Console, use the link below for detailed instructions on how to do this:
https://developers.google.com/games/services/android/quickstart#step_2_set_up_the_game_in_the_dev_console

Setup (test using SimpleDemo scene)

1 Import the package

2 Amend the AndroidManifest.xml (Plugins/Android/AndroidManifest.xml), change only the following two lines , entering you App ID (instead of 123456789).
(Note the backslash and space preceding your App ID, you must keep these in)

<meta-data android:name="com.google.android.gms.games.APP_ID" android:value="\ 123456789" />
<meta-data android:name="com.google.android.gms.appstate.APP_ID" android:value="\ 123456789" />

3 Deploy to an android device (only works once deployed!)

Note that Google Play Game Services only seem to work when you sign your game with your release key (ie not the debug key). 
This means you will need to get the SHA1 signing certificate fingerprint for your release key and use it when you link your app in the Developer Console.
You will then need to specify your release keystore when you export your apk from Unity.


In Detail

The demo scenes are a good way to test the basic functionality of the plugin, when you want to incorporate the plugin into your own games, you need to do the following:

Always have a gameobject called 'UnityGameObjectReceiver' in your scene if you want to handle responses
Always call GPGSUnityPlugin.StartPlay(true) before calling any of the other GPGSUnityPlugin methods (stick it in Start()!)

Note that if you have other plugins that need to be the main activity, use the AndroidManifestNoAct.xml (rename it to AndroidManifest.xml) as the basis of your merged manifest.
Note the extra line (<activity android:name="com.platoevolved.gpgsunity.SubActivity"></activity>) is crucial for the plugin to work when not set up as the main activity.


Versions

1.031

Fixed missing resource folder in gpgsunity.jar
try...catch blocks added for Unity 4.2 changes

1.02

Added option to not be the main activity, alternative manifest file AndroidManifestNoAct.xml supplied

1.01

ShowLeaderboard(string id) added



