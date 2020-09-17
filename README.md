# Print to PDF Repro

When the "Microsoft Print to PDF" printer tries to show a Save File Dialog and the Avalonia window is the topmost, the dialog will never be shown and the window becomes unresponsive. To test, that the print service actually works, you can for example add a breakpoint in the ViewModel on line 43 or uncomment the window hide and show methods.
