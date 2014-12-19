/**
 * @license MIT <http://opensource.org/licenses/MIT>
 * 
 * @file TemplateVariableParser.cs
 * @date 2014-12-16 20:01:34 UTC+05:00
 * @author Mubeen Iqbal <mubeen.ace@gmail.com>
 * 
 * @description
 * Destination path: $PROJECT_HOME/Assets/Editor/TemplateVariableParser.cs
 * 
 * $PROJECT_HOME is the directory where the Unity project is created. This script must be placed only inside a Unity
 * project in $PROJECT_HOME/Assets/Editor/ directory. Since this is a Unity editor script it needs to be inside the
 * "Editor" directory.
 * 
 * By default Unity templates don't support many template variables. A few supported variables are:
 * 
 * #NAME#
 * #SCRIPTNAME#
 * 
 * And there might be others but very very few.
 * 
 * The purpose of this script is to add support for more template variables to Unity templates. The script will replace
 * the script template variables with their corresponding values for every new script created by Unity based on Unity's
 * templates. That is, when you create a file from within Unity e.g. when you right-click in Unity's project browser and
 * create a C# script (right-click > Create > C# Script) the template variables in Unity's C# script template from which
 * Unity is going to create the new C# script will be replaced with their values in the newly created C# script.
 * 
 * The added template variables are given in the "TemplateVariables" region in the code. Any number of template
 * variables can be added.
 * 
 * The naming convention being followed for the template variables is:
 * 
 * #<variable_name>#
 * 
 * variable_name
 *     A string in uppercase using underscore as space separator.
 * 
 * You can modify Unity templates by putting in the template variables in the template files.
 * 
 * For example you can add comments to the C# template like so:
 * 
 *   // @author #AUTHOR# <#AUTHOR_EMAIL#>
 *   // @date #DATE#
 * 
 * and whenever you will create a C# script from within Unity it will have the comments like so:
 * 
 *   // @author Linus Torvalds <torvalds@kruuna.helsinki.fi>
 *   // @date 1991-08-25 10:05:46 UTC+02:00
 */

using UnityEngine;
using UnityEditor;
using System.Collections;

// TODO(mubeeniqbal): Separate out configuration/values into a text file rather than providing values here in code. Use
// an associative array/dictionary created by reading values from the text file and loop through that array to
// configure/replace the template variables with their values.
public class TemplateVariableParser : UnityEditor.AssetModificationProcessor {
// public:
    public static void OnWillCreateAsset(string path) {
        #region TemplateVariables
        string DATE = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss UTCzzz");
        string YEAR = System.DateTime.Now.ToString("yyyy");
        string MONTH = System.DateTime.Now.ToString("MM");
        string DAY = System.DateTime.Now.ToString("dd");
        string TIME = System.DateTime.Now.ToString("HH:mm:ss");
        string HOUR = System.DateTime.Now.ToString("HH");
        string MINUTE = System.DateTime.Now.ToString("mm");
        string SECOND = System.DateTime.Now.ToString("ss");
        string UTC_OFFSET = System.DateTime.Now.ToString("zzz");
        string AUTHOR = "FirstName LastName";
        string AUTHOR_EMAIL = "author@email.com";
        string PRODUCT = PlayerSettings.productName;
        string LICENSE = "[license_name]";
        string LICENSE_URL = "http://license.url";
        string COMPANY = PlayerSettings.companyName;
        string COMPANY_URL = "http://company.url";
        string COMPANY_EMAIL = "company@email.com";
        string DESCRIPTION = "[add_description_here]";
        #endregion

        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");

        // Check for a file extension.
        if (index == -1) {
            return;
        }

        string file = path.Substring(index);
        
        if ((file != ".cs") && (file != ".js") && (file != ".boo")) {
            return;
        }
        
        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        file = System.IO.File.ReadAllText(path);

        file = file.Replace("#DATE#", DATE);
        file = file.Replace("#YEAR#", YEAR);
        file = file.Replace("#MONTH#", MONTH);
        file = file.Replace("#DAY#", DAY);
        file = file.Replace("#TIME#", TIME);
        file = file.Replace("#HOUR#", HOUR);
        file = file.Replace("#MINUTE#", MINUTE);
        file = file.Replace("#SECOND#", SECOND);
        file = file.Replace("#UTC_OFFSET#", UTC_OFFSET);
        file = file.Replace("#AUTHOR#", AUTHOR);
        file = file.Replace("#AUTHOR_EMAIL#", AUTHOR_EMAIL);
        file = file.Replace("#PRODUCT#", PRODUCT);
        file = file.Replace("#LICENSE#", LICENSE);
        file = file.Replace("#LICENSE_URL#", LICENSE_URL);
        file = file.Replace("#COMPANY#", COMPANY);
        file = file.Replace("#COMPANY_URL#", COMPANY_URL);
        file = file.Replace("#COMPANY_EMAIL#", COMPANY_EMAIL);
        file = file.Replace("#DESCRIPTION#", DESCRIPTION);
        
        System.IO.File.WriteAllText(path, file);
        AssetDatabase.Refresh();
    }
}
