using System.Diagnostics;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace OmegaStartupMarquee
{
    public class OmegaStartupMarquee_SystemEventHandler : ISystemEventsPlugin
    {
        void ISystemEventsPlugin.OnEventRaised(string eventType)
        {
            if (eventType == SystemEventTypes.BigBoxStartupCompleted)
            {
                //Kill the marquee startup video now that the main screen video has completed.
                Process[] Process = System.Diagnostics.Process.GetProcesses();
                for (int i = 0; i < Process.Length; i++)
                {
                    if (Process[i].ProcessName.StartsWith("BigBoxWithStartupMarquee"))
                    {
                        Process[i].Kill();
                    }
                }
            }
        }
    }
}
