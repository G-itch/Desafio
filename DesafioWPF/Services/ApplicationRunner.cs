using System.Diagnostics;

namespace DesafioWPF.Services
{
    public class WindowsApplicationRunner : IApplicationRunner
    {
        public void RunApplication(string path)
        {
            string workingDirectory = System.IO.Directory.GetCurrentDirectory();
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c start \"\" {path}";
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.CreateNoWindow = true; // Hides the command window
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.Start();
        }
    }
}