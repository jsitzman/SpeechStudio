using System.Diagnostics;

class Program
{
    static void Main()
    {
    LaunchCommandLineApp();
    }

    /// <summary>
    /// Launch the legacy application with some options set.
    /// </summary>
    static void LaunchCommandLineApp()
    {

    // Use ProcessStartInfo class
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.CreateNoWindow = false;
    startInfo.UseShellExecute = false;
    startInfo.FileName = "../../bin/Debug/pocketsphinx_continuous.exe";
    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    startInfo.Arguments = "-inmic yes -hmm ../../model/en-us/en-us -lm ../../model/en-us/en-us.lm.dmp -dict ../../model/en-us/cmudict-en-us.dict";

    try
    {
        // Start the process with the info we specified.
        // Call WaitForExit and then the using statement will close.
        using (Process exeProcess = Process.Start(startInfo))
        {
        exeProcess.WaitForExit();
        }
    }
    catch
    {
        // Log error.
    }
    }
}