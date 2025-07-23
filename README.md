# UnoAnimationCompleteIssue
Reported as issue #12788
Title:
[iOS, Android] Keyframe animation of Rotation is not handled correctly

Current behaviour:
On iOS the animated object will be translated off screen at the end of the animation if the angle is not set to zero.

On iOS the animation of rotation at the same time as translation does not require the animation of the CenterX and CenterY properties which is required on Windows.

If the animation of the CenterX and CenterY properties are added on iOS then the storyboard completion event is never fired.

Works correctly on Windows and WASM.

Android has different problems which have been covered in other issues that need to be resolved however there is also a rotation problem in that including the animation of the CenterX and CenterY properties causes the target to be animated incorrectly.
On Android the storyboard completion event is fired however the target moves back to its original location which is incorrect.

Expected behaviour:
The animation of Rotation on iOS should work the same as it does on Windows, code should not need to be removed for the animation to complete. 

Reproduced in the sample at 
https://github.com/BrianDT/UnoAnimationCompleteIssue

In the sample the code to add the unnecessary final change to the rotation and to remove the animation of CentreX and CentreY is included using ifdefs. These can be adjusted to show the undesirable effects.

Workarounds
The inclusion of the final rotation to zero and the removal of the CenterX and CenterY animations on iOS bypass some of the issues. 
However, the inclusion of the unnecessary final change to the rotation can lead to inappropriate changes in the UI of the app which mean object positions are out of context.

==================================================================================================================================================================================================================================================================================================================
Reported issue #14382
Title: [Android] programmatically started storybord animation cannot be stopped.

Current behaviour:
On Android the animation does not stop when storyboard.Stop(); is called.

Works correctly on Windows, WASM and iOS.

Expected behaviour:
The animation should stop.

Reproduced in the sample at 
https://github.com/BrianDT/UnoAnimationCompleteIssue

In the sample app start either of the code animations and then press the stop animation button.

Workaround:
None found

Updated to Uno 5.2.175
#14382 Still an issue
#12788 Still an issue - workarounds commented out in sample.

Updated to Uno 6.0.96
#14382 Still an issue

Updated to Uno 6.1.23 with SkiaRenderer
Confirmed resolved
