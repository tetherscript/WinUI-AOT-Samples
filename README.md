# WinUI AOT Samples

Not sure if it's just me, but I couldn't find a coherent guide on how to publish AOT for packaged AND unpackaged WinUI c# apps.  Even ChatGPT said it could not be done.  But various posts hinted that it was being done.  Then this post https://github.com/dotnet/runtime/issues/109452 gave me a sample app and clues to figure it out.  So now i can compile packaged and unpackaged AOT code, so it can't be decompiled back to c#. Victory.  Sweet victory.

<img width="403" height="308" alt="image" src="https://github.com/user-attachments/assets/325895d4-ec6c-45ec-9109-0215fc36ef9a" />

This project uses:

- .Net 8
- c#
- WinUI
- WinAppSDK 1.7

Detailed instructions are included in the 

/Documents/Notes.txt in each project.

View the Wiki for more info.

