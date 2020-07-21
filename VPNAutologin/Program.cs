using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System;
using System.Threading;

namespace VPNAutologin
{
    class Program
    {
        static void Main(string[] args)
        {
            var appPath = args[0];
            var userName = args[1];
            var userPass = args[2];

            try
            {
                using (var app = FlaUI.Core.Application.Launch(appPath))
                using (var automation = new UIA3Automation())
                {
                    var window = app.GetMainWindow(automation);
                    var vpnItem = window.FindFirstDescendant(c => c.ByControlType(ControlType.ListItem)).AsListBoxItem();

                    if (vpnItem.Patterns.SelectionItem.TryGetPattern(out var inv))
                    {
                        inv.Select();
                        Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.CONTROL);
                        Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_B);

                        Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.CONTROL);
                        Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_B);
                    }

                    Thread.Sleep(1000);

                    var login = window.FindFirstDescendant(c => c.ByName("Username:").And(c.ByControlType(ControlType.Edit)));
                    if (login.Patterns.Value.TryGetPattern(out var loginText))
                    {
                        loginText.SetValue(userName);
                    }

                    var password = window.FindFirstDescendant(c => c.ByName("Password:").And(c.ByControlType(ControlType.Edit)));
                    if (password.Patterns.Value.TryGetPattern(out var passwordText))
                    {
                        passwordText.SetValue(userPass);
                    }

                    var ok = window.FindFirstDescendant(c => c.ByName("OK").And(c.ByControlType(ControlType.Button)));
                    if (ok.Patterns.Invoke.TryGetPattern(out var okBtn))
                    {
                        okBtn.Invoke();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
