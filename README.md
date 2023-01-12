# SvgImageResizing
Test task for resizing SVG image using Angular and .NET.:

API: RectangleAPI - .NET 7 web application with RectangleController. It has two methods:
- GET /rectangle/initialsize - returns initial size of rectangle
- POST /rectangle/perimenter - returns perimeter of rectangle, updates current size parameters to json file

UI: Angular 15 project that displays SVG rectangle figure with initial size, rectangle is resizable, current perimeter is shown below the figure

## To run this web application:
1. Git clone the repository
2. Open RectangleAPI project in Rider/VS Studio
3. Launch RectangleAPI with http configuration (port is set to http://localhost:5131)
4. Open angular project
5. Run **'npm install'** command
6. Run **'ng serve'** command (default port is http://localhost:4200/)

The page will look like (example):
![image](/assets/images/screenshot.png)

### Additional information:
There are two json files: *initialSize.json* and *currentSize.json* (location: Project\RectangleAPI\Data)
1. initialSize.json - file with initial size information. Height = 100. Width = 150. You can update these values to change initial size.
2. currentSize.json - file with current size information. It is updated automatically after resizing of rectangle figure.

## Task:
Create a webpage for drawing rectangle svg figure<br/>
Near to figure display the perimeter of the figure
## Requirements:
The initial dimensions of the svg figure needs to be taken from JSON file<br/>
The user should be able to resize the figure by mouse<br/>
Near to figure display the perimeter of the figure<br/>
After resizing, system must update JSON file with new dimensions