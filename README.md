# Extra Practical: Prototyping Tangible Interaction with AR Markers

This practical has two main learning aims:

- To continue to develop your technical skills for Augmented Reality (AR) by giving you experience in applying the Vuforia marker tracking from the last practical in response to a design brief. You’ll learn, in particular, how to make code run when a marker is tracked.
- To teach you how to employ visual markers to put one of the Tangible Interaction concepts taught in the lecture into action

This practical can either be completed using a standard webcam in the Unity or by deploying to your Android tablets. Using a standard webcam will make prototyping and debugging quicker. However, using a mobile device might reveal some cool new opportunities for tangible interactions in the later tasks!

# Task 1: A Simple, More Tangible DJ Interface

Vuforia a really great platform for creating AR applications. However, you don’t have to just use it for that. Rather, it’s also possible to create tangible interfaces with it by using it by tracking the presence of physical objects with markers attached to them in a camera image. In this task, you are going to use Vuforia like this to create a (albeit simple) DJ interface that could make interaction more visible to an audience.

The interface you will create will be based on the STEMS multi-track audio file format (see http://www.stems-music.com/ for more information). STEMS files are broken down a track into four constituent parts: bass, melody, voice and drums. DJs use STEMS in live performance, because they allow different parts of tracks to be turned on and off at different times while mixing. The DJ interface you are going to create in this task should turn on and off the four parts of a STEMS file depending on whether particular AR markers are visible in the camera image. For instance, you might turn the bass part on when one particular marker (e.g. a book) is tracked.

To get started, create a copy of this git repository in your personal GitHub account and clone it onto your local machine.

Once you’ve got the package imported, the next step is to make it control some music. I’ve provided a prefab game object called ```DJMixer``` in ```Practical Assets``` that includes a component that plays the different parts of a STEMS file. Drag this into the scene.

This prefab game object includes a script called ```DJMixer.cs``` that contains a method that allows you to turn on and off the different parts of a STEMS file. This method simply turns the volume up or down on the part specified with the first integer parameter, depending on whether the second boolean parameter is true (volume all the way up) or false (volume all the way down). The code snippet below shows how to use this to turn the volume up for first part, which is the drums:

```c#
DJMixer mixer = // code for getting mixer component
mixer.SetTrackState(0, true);
```

