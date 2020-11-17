using System;
using Crestron.SimplSharp;                          	// For Basic SIMPL# Classes
using Crestron.SimplSharpPro;                       	// For Basic SIMPL#Pro classes
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading
using Crestron.SimplSharpPro.Diagnostics;		    	// For System Monitor Access
using Crestron.SimplSharpPro.DeviceSupport;         	// For Generic Device Support
using Crestron.SimplSharpPro.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Captial;



namespace Captial_function
{
    public class Page_Function : ControlSystem
    {

        public void Interlock(uint signal, uint clear, uint interlock1, uint interlock2, uint interlock3, uint interlock4, uint interlock5, uint interlock6, uint interlock7, uint interlock8, uint interlock9, uint interlock10)
        {
            UserInterface.StringInput[1].StringValue = "set value";
            if (signal == clear)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
            }
            
            
            
            else if (signal == 51)
            {
                UserInterface.StringInput[1].StringValue = "test2";
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock1].BoolValue = true;
            }

            else if (signal == interlock2)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = true;
            }

            else if (signal == interlock3)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = true;
            }

            else if (signal == interlock4)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = true;
            }

            else if (signal == interlock5)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = true;
            }

            else if (signal == interlock6)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = true;
            }

            else if (signal == interlock7)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = true;
            }

            else if (signal == interlock8)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = true;
            }

            else if (signal == interlock9)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = true;
            }

            else if (signal == interlock10)
            {
                UserInterface.BooleanInput[interlock1].BoolValue = false;
                UserInterface.BooleanInput[interlock2].BoolValue = false;
                UserInterface.BooleanInput[interlock3].BoolValue = false;
                UserInterface.BooleanInput[interlock4].BoolValue = false;
                UserInterface.BooleanInput[interlock5].BoolValue = false;
                UserInterface.BooleanInput[interlock6].BoolValue = false;
                UserInterface.BooleanInput[interlock7].BoolValue = false;
                UserInterface.BooleanInput[interlock8].BoolValue = false;
                UserInterface.BooleanInput[interlock9].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = false;
                UserInterface.BooleanInput[interlock10].BoolValue = true;
            }
        }

        public void test()
        {
            UserInterface.StringInput[1].StringValue = "working well";
        }
    }
}