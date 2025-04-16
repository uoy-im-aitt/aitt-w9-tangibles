# Prototyping Tangible Interaction with AR Markers

This practical has two main learning aims:

- To continue to develop your technical skills for Augmented Reality (AR) by giving you experience in applying the Vuforia marker tracking from the last practical in response to a design brief. You’ll learn, in particular, how to make code run when a marker is tracked.
- To teach you how to employ visual markers to put one of the Tangible Interaction concepts taught in the lecture into action

This practical can either be completed using a standard webcam in the Unity or by deploying to your Android tablets. Using a standard webcam will make prototyping and debugging quicker. However, using a mobile device might reveal some cool new opportunities for tangible interactions in the later tasks!

> **Note** The instructions below assume you've already done the practical from AR week. If you need a reminder on how to set up your Unity project to work with Vuforia, please go back and see the instructions there.
> I've provided some image markers in ```Assets/Markers``` and you can get print outs at the front of the room. You can also use the printer in the building to make your own.

## Task 1: A Simple, More Tangible DJ Interface

Vuforia a really great platform for creating AR applications. However, you don’t have to just use it for that. Rather, it’s also possible to create tangible interfaces with it by using it by tracking the presence of physical objects with markers attached to them in a camera image. In this task, you are going to use Vuforia like this to create a (albeit simple) DJ interface that could make interaction more visible to an audience.

The interface you will create will be based on the STEMS multi-track audio file format (see http://www.stems-music.com/ for more information). STEMS files are broken down a track into four constituent parts: bass, melody, voice and drums. DJs use STEMS in live performance, because they allow different parts of tracks to be turned on and off at different times while mixing. The DJ interface you are going to create in this task should turn on and off the four parts of a STEMS file depending on whether particular AR markers are visible in the camera image. For instance, you might turn the bass part on when one particular marker (e.g. a book) is tracked.

To get started, create a copy of this git repository in your personal GitHub account and clone it onto your local machine.

Once you’ve got the package imported, the next step is to make it control some music. I’ve provided a prefab game object called ```DJMixer``` in ```Practical Assets``` that includes a component that plays the different parts of a STEMS file. Drag this into the scene.

This prefab game object includes a script called ```DJMixer.cs``` that contains methods that allows you to turn on and off the different parts of a STEMS file. These methods simply turn the volume (`PlayTrack`) up or down (`StopTrack`) on the part specified with the first integer parameter, depending on whether the second boolean parameter is true (volume all the way up) or false (volume all the way down). The code snippet below shows how to use this to turn the volume up/down for first part, which is the drums:

```c#
DJMixer mixer = // your code for getting mixer component (e.g. via GetComponent<DJMixer>())
mixer.PlayTrack(0);
mixer.StopTrack(0);
```

In this task, you will write a script that uses this code to turn the drums component (id = 0) on/off when the first marker is added/removed.

To achieve this, you’ll need to call some code when markers are tracked and also when they lose tracking. There are a few ways to do this, but the simplest is to use the “Default Trackable Event Handler” component that’s already on the Image game objects you’ve created. You can use this component to call your own code when a maker is tracked and lost by: 

1. Create your own script that has methods that you want to be called when markers are tracked and lost and add it to an Image object
2. Use the drop-down menus found in the inspector of the ```Default Observer Event Handler``` component to specify that the methods in your script should be called when the marker is tracked and lost respectively

You may also need to change the ```Consider target as visible if status is``` value in the inspector to ```Tracked``` in order to make tracks stop playing when they are lost from view.

## Task 2: Adding Bass, Voice and Melody

By this point you should have an interface that plays the drums part when one marker is visible. In this task, you should extend the scene so that the bass, melody and voice tracks are played when three additional markers are present in the scene.

Before you start this task, you’ll need to enable the tracking of multiple markers simultaneously. This can be done by setting the ```Max Simultaneous Tracked Images``` property in the Vuforia Config (```Window > Vuforia Config```) to the max number you want to track (e.g. 4 here). 

Here are some tips that can help you find the solution to this challenge:

- You can complete this task by creating new markers for each of the respective tracks and linking them to the existing ```DJMixer``` component
- To tell the mixer to play/pause a different track you can simply change the trackId parameter passed to SetTrackState method
- You shouldn’t need to create any new scripts to complete this task. Rather, you should be able to complete the task creating new instances of the script(s) created in the previous task and configuring them to behave differently using parameters.
- You’ll need to make multiple image objects with different target markers for this task. Therefore, if you only found one object to track in the previous exercise you’ll need to find more now!

## Task 3: Making it More Tangible

The Unity scene you’ve created in the last task has the potential to form the basis of a number of different interfaces that make performing using STEMS more visible, like the "ReacTable" example from the lecture. For example, it could be used to create interfaces in which:

1. The user mutes STEM parts by obscuring the different markers using large, visible hand gestures
2. The user turns on the STEM parts by placing building blocks with AR markers on them on a table
3. A physical cube with different AR markers on each face is used to turn on/off the STEM parts

In this final task, you should get creative and try and make an interface for controlling the DJMixer that makes DJ-ing more visually interesting to an audience.

What is visually interesting? Some might argue that for it relates to being able to understand what the performer is doing. However, others would argue that this does not matter as long as the performer’s actions are visually compelling in some way. Have a think about what your views on this are and implement your interface accordingly. 

One cool thing to experiment with when completing this task might be how you leverage the AR capabilities of Vuforia to augment the performer’s body and performance space. Imagine you’re live-streaming a performance during Covid, how would you use AR to make the video stream more interesting? 

## Optional Extensions

If you complete all of the above tasks before the end of the practical, or would like to continue to develop your skills in your free study time, then you should consider experimenting with some of the following tasks: 

- Explore whether you can go beyond just turning the different audio sources on and off when markers and tracked and lost. Could you, for example, change the volume or pitch of a source based upon the pose of a tracked marker?
- Can you make AR visuals change based on current sound of a track (e.g. to change the size of a visual object based on how much bass frequencies are present)? This is tricky to do, but can lead to some nice effects. If you want to try this advanced task, the following method would be a good place to start: https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html. This method uses something called a Fast Fourier Transform to give you the current volume of the track in different frequency ranges (e.g. how much bass is there?).

