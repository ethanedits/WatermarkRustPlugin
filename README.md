# WatermarkRustPlugin
This is a plugin script for Rust Servers, using oxide mod manager (https://umod.org/games/rust).

Drag **Watermark.cs** into your **rustserver > oxide > plugins** folder

A **Watermark.JSON** should be created in your **rustserver > oxide > config** folder

Open **Watermark.JSON**,
![Image of Watermark Config](https://media.discordapp.net/attachments/733974815735808041/773573091477159946/Capture.PNG)

Now change `Watermark text` to whatever you would like the text to display in the top left.
Change `16` to whatever font size you would like your text to use.
Change `1 0 0 1` to whatever RGBA value you would like (its a float) the first value is Red, the second Green, the third Blue, and the fourth Alpha.

type `oxide.reload Watermark` in your rust server console, and disconnect and rejoin your rust server.
**Now you should have something like this:**

![Image of Watermark Text](https://media.discordapp.net/attachments/733974815735808041/773574091118477322/unknown.png?width=937&height=507)
