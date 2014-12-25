Unity Setup
===========

Setup resources for the Unity game engine. The purpose of these resources is to cuztomize the Unity editor.

## Unity Templates

Repository path: `unity-resources/Resources/ScriptTemplates/*.txt`  
Destination path (Windows): `$UNITY_HOME/Editor/Data/Resources/ScriptTemplates/*.txt`  
Destination path (OS X): `$UNITY_HOME/Editor/Data/Resources/ScriptTemplates/*.txt`

`$UNITY_HOME` is the directory where Unity is installed. The template files must be placed at the destination path mentioned above.

A Unity template is a plain text file which contains biolerplate text for every new file that is created from within Unity, mostly using Unity's create context menu (e.g. `right-click > Create > C# Script`).

The template files for Unity are located at:  
Windows:  `$UNITY_HOME/Editor/Data/Resources/ScriptTemplates/`  
OS X:  `$UNITY_HOME/Unity.app/Contents/Resources/ScriptTemplates/`

You can modify the templates by editting the text files and you can also add more templates to your liking. Any text can be added to a template, there are no restrictions on that.

For example you can add some `using` directives at the top of the C# template like so:

    using System.Collections;
    using System.DateTime;

and whenever you will create a C# script from within Unity it will already have those `using` directives so you won't have to type them every time you create a C# script.

For creating your own templates take note that the template file name follows a specific naming convention which must be strictly followed (given below).

`<id>-<context_menu_entry>-<default_file_name>.<extension>.txt`

`id`  
> A unique number. If you use the same id more than once only the first template with that id will be read by Unity and the rest will be ignored.

`context_menu_entry`  
> The text that will be visible in the "Create" context menu when you right-click in Unity to create a new file. Hyphens cannot be used.

`default_file_name`  
> The default name given to the newly created file (if you don't choose to change it). Hyphens can be used and will be part of the default file name.

`extension`  
> The file extension e.g. "cs" for a C# script, "shader" for shaders, etc.

For example:

`85-C# Script 2-NewScript - C2.cs.txt`

Here `85` is the id, `"C# Script 2"` is the text that will be displayed in Unity's "Create" context menu entry, `"NewScript - C2"` is the name which will be given by default to the C# script which you will create by clicking on the entry in the context menu and `"cs"` is the file extension of the newly created script.

## Template Variable Parser

Repository path: `project-resources/Assets/Editor/TemplateVariableParser.cs`  
Destination path: `$PROJECT_HOME/Assets/Editor/TemplateVariableParser.cs`

`$PROJECT_HOME` is the directory where the Unity project is created. This script must be placed only inside a Unity project in `$PROJECT_HOME/Assets/Editor/` directory. Since this is a Unity editor script it needs to be inside the "Editor" directory.

By default Unity templates don't support many template variables. A few supported variables are:

    #NAME#
    #SCRIPTNAME#

And there might be others but very very few.

The purpose of this script is to add support for more template variables to Unity templates. The script will replace the script template variables with their corresponding values for every new script created by Unity based on Unity's templates. That is, when you create a file from within Unity e.g. when you right-click in Unity's project browser and create a C# script (`right-click > Create > C# Script`) the template variables in Unity's C# script template from which Unity is going to create the new C# script will be replaced with their values in the newly created C# script.

The added template variables are given in the `"TemplateVariables"` region in the code. Any number of template variables can be added.

The naming convention being followed for the template variables is:

`#<variable_name>#`

`variable_name`  
> A string in uppercase using underscore as space separator.

You can modify Unity templates by putting in the template variables in the template files.

For example you can add comments to the C# template like so:

    // @author #AUTHOR# <#AUTHOR_EMAIL#>
    // @date #DATE#

and whenever you will create a C# script from within Unity it will have the comments like so:

    // @author Linus Torvalds <torvalds@kruuna.helsinki.fi>
    // @date 1991-08-25 10:05:46 UTC+02:00

## TODO
[ ] Automate builds for Unity preferably with Jenkins. Write script(s) which work on both Windows and OS X.
