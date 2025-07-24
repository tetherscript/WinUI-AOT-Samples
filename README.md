# WinUI AOT Samples

Not sure if it's just me, but I couldn't find a coherent guide on how to publish AOT for packaged AND unpackaged WinUI c# apps.  Even ChatGPT said it could not be done.  

But various posts hinted that it was being done.  Then this post https://github.com/dotnet/runtime/issues/109452 gave me a sample app and clues to figure it out.  

So now i can compile packaged and unpackaged AOT code, so it can't be decompiled back to c#. 

Victory.  Sweet victory.

Included is the AOTCombined project that allows you to create both packaged AND unpackaged installers.

Here's the executable of the AOTSample project, installed via it's .msix.
<img alt="image" src="https://github.com/user-attachments/assets/325895d4-ec6c-45ec-9109-0215fc36ef9a" />

And here's the executable of the AOTSampleUnpackged prject, just waiting to be included in an installer (Inno, anyone?)
<img alt="image" src="https://github.com/user-attachments/assets/1af2c612-2157-4391-97eb-052e01a3e744" />

This project uses:

- .Net 8
- c#
- WinUI
- WinAppSDK 1.7

I hope to add some additional projects that show what kind of code works and doesn't work when compiling AOT.  There's a bunch of gotcha's, noted here, although they really don't talk about WinUI specifically:

https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=windows%2Cnet8

Detailed instructions are included in the 

/Documents/Notes.txt in each project.

View the Wiki for more info.

