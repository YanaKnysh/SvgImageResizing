# SvgImageResizing
Test task for resizing SVG image using Angular and .NET.:
### Task:
Create a webpage for drawing rectangle svg figure<br/>
Near to figure display the perimeter of the figure
### Requirements:
The initial dimensions of the svg figure needs to be taken from JSON file<br/>
The user should be able to resize the figure by mouse<br/>
Near to figure display the perimeter of the figure<br/>
After resizing, system must update JSON file with new dimensions

## Implementation
API: RectangleAPI - .NET 7 web application with RectangleController. It has two methods:
- GET /rectangle/initial-size - returns initial size of rectangle
- POST /rectangle/perimenter - returns perimeter of rectangle, updates current size parameters to json file

UI: Angular 15 project that displays SVG rectangle figure with initial size, rectangle is resizable, current perimeter is shown below the figure

## Requirements to launch this project locally:
1. Download .NET 7 SDK
2. Install Angular (15 version)
3. Optionally install IDE (Rider / Visual Studio , etc.)

## To run this web application (Linux/Windows):
1. Git clone the repository
2. Go to RectangleAPI folder
3. Run **'dotnet run'** command (default port is set to http://localhost:5131)
4. Go to 'AngularSvgApp' folder
5. Run **'npm install'** command
6. Run **'ng serve'** command (default port is http://localhost:4200/)

## To run this web application (IDE):
1. Git clone the repository
2. Open RectangleAPI project in Rider/VS Studio
3. Launch RectangleAPI with http configuration (default port is set to http://localhost:5131)
4. Open angular project
5. Open console
6. Run **'npm install'** command
7. Run **'ng serve'** command (default port is http://localhost:4200/)

The page will look like (example):
![image](/assets/images/screenshot.png)

### Additional information:
There is a json file called: *currentSize.json* (location: Project\RectangleAPI\Data)
It is the file with current size information. It is updated automatically after resizing of rectangle figure.

