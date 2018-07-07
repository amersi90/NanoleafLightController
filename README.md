# NanoleafLightController

This application uses nanoleaf-api to allow users to control their nanoleaf lights from a windows-computer. Users can toogle lights, change color, adjust brightness and select effect. 

### Installing
Clone the project directly in visual studio, or download the ZIP file and run NanoleafLightController.sln. After that build the project and open project directory and navigate to bin/Debug folder, from there you can start the program. 

### Running the application
When the application is started it will check for a connection file under My Documents/nanoleaf light controller/ folder. If the file doesen't exist, the application will run through a setup-process that looks for nanoleaf lights on the local network to establish connection.

After the setup-process, users can control their lights
<p align="left">
 <blockquote class="imgur-embed-pub" lang="en" data-id="wSynrfu"><a href="//imgur.com/wSynrfu">View post on imgur.com</a></blockquote><script async src="//s.imgur.com/min/embed.js" charset="utf-8"></script>
</p>

## Built with
MetroFramework https://github.com/dennismagno/metroframework-modern-ui<br/>
Tmds.MDns https://github.com/tmds/Tmds.MDns<br/>
Newtonsoft.Json https://github.com/JamesNK/Newtonsoft.Json
