using System;
using Crestron.SimplSharp;                          	// For Basic SIMPL# Classes
using Crestron.SimplSharpPro;                       	// For Basic SIMPL#Pro classes
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading
using Crestron.SimplSharpPro.Diagnostics;		    	// For System Monitor Access
using Crestron.SimplSharpPro.DeviceSupport;         	// For Generic Device Support
using Crestron.SimplSharpPro.UI;
using Captial_function;

namespace Captial
{
    public class ControlSystem : CrestronControlSystem
    {
        
        public ComPort comport;
        public XpanelForSmartGraphics UserInterface;
        public Captial.ControlSystem Processor;
        public Page_Function PageInterlock;

        const int projector_on = 100;
        const int projector_off = 101;

        public const string rs232_delimiter = "\x0d";
        public const string rs232_on = "ON";
        public const string rs232_off = "OFF";


        

        public ControlSystem()
            : base()
        {
            try
            {
                Thread.MaxNumberOfUserThreads = 20;

                //Subscribe to the controller events (System, Program, and Ethernet)
                CrestronEnvironment.SystemEventHandler += new SystemEventHandler(ControlSystem_ControllerSystemEventHandler);
                CrestronEnvironment.ProgramStatusEventHandler += new ProgramStatusEventHandler(ControlSystem_ControllerProgramEventHandler);
                CrestronEnvironment.EthernetEventHandler += new EthernetEventHandler(ControlSystem_ControllerEthernetEventHandler);

                //Subscribe to the touchpanel
                UserInterface = new XpanelForSmartGraphics(03, this);
                UserInterface.SigChange += new SigEventHandler(UserInterface_SigChange);
                UserInterface.Register();

                
                //subscribe to comport
                comport = ComPorts[1];
                comport.Register();
                comport.SetComPortSpec(Crestron.SimplSharpPro.ComPort.eComBaudRates.ComspecBaudRate9600,
                                        Crestron.SimplSharpPro.ComPort.eComDataBits.ComspecDataBits8,
                                        Crestron.SimplSharpPro.ComPort.eComParityType.ComspecParityNone,
                                        Crestron.SimplSharpPro.ComPort.eComStopBits.ComspecStopBits1,
                                        Crestron.SimplSharpPro.ComPort.eComProtocolType.ComspecProtocolRS232,
                                        Crestron.SimplSharpPro.ComPort.eComHardwareHandshakeType.ComspecHardwareHandshakeNone,
                                        Crestron.SimplSharpPro.ComPort.eComSoftwareHandshakeType.ComspecSoftwareHandshakeNone,
                                        false);
                                      

                //interlock function

            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in the constructor: {0}", e.Message);
            }

            
        }

        /// <summary>
        /// InitializeSystem - this method gets called after the constructor 
        /// has finished. 
        /// 
        /// Use InitializeSystem to:
        /// * Start threads
        /// * Configure ports, such as serial and verisports
        /// * Start and initialize socket connections
        /// Send initial device configurations
        /// 
        /// Please be aware that InitializeSystem needs to exit quickly also; 
        /// if it doesn't exit in time, the SIMPL#Pro program will exit.
        /// </summary>
        public override void InitializeSystem()
        {
            try
            {
              //PageInterlock = new Page_Function();
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in InitializeSystem: {0}", e.Message);
            }
        }

        /// <summary>
        /// Event Handler for Ethernet events: Link Up and Link Down. 
        /// Use these events to close / re-open sockets, etc. 
        /// </summary>
        /// <param name="ethernetEventArgs">This parameter holds the values 
        /// such as whether it's a Link Up or Link Down event. It will also indicate 
        /// wich Ethernet adapter this event belongs to.
        /// </param>
        /// 

        void UserInterface_SigChange(BasicTriList currentDevice, SigEventArgs args)
        {
            switch (args.Sig.Type)
            {
                case eSigType.Bool:
                    {
                        if (args.Sig.BoolValue)
                        {
                            if (args.Sig.Number == projector_on)
                            {
                                UserInterface.BooleanInput[projector_on].BoolValue = true;
                                UserInterface.BooleanInput[projector_off].BoolValue = false;
                                comport.Send(rs232_on + rs232_delimiter);
                                UserInterface.StringInput[1].StringValue = rs232_on + rs232_delimiter;
                            }

                            else if (args.Sig.Number == projector_off)
                            {
                                UserInterface.BooleanInput[projector_off].BoolValue = true;
                                UserInterface.BooleanInput[projector_on].BoolValue = false;
                                comport.Send(rs232_off + rs232_delimiter);
                                UserInterface.StringInput[1].StringValue = rs232_off + rs232_delimiter;
                            }
                            // PageInterlock.Interlock(args.Sig.Number, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60);

                        }
                        break;
                    }
                case eSigType.String:
                    {
                        break;
                    }

                case eSigType.UShort:
                    {
                        break;
                    }
            }
        }
        void ControlSystem_ControllerEthernetEventHandler(EthernetEventArgs ethernetEventArgs)
        {
            switch (ethernetEventArgs.EthernetEventType)
            {//Determine the event type Link Up or Link Down
                case (eEthernetEventType.LinkDown):
                    //Next need to determine which adapter the event is for. 
                    //LAN is the adapter is the port connected to external networks.
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {
                        //
                    }
                    break;
                case (eEthernetEventType.LinkUp):
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {

                    }
                    break;
            }
        }

        /// <summary>
        /// Event Handler for Programmatic events: Stop, Pause, Resume.
        /// Use this event to clean up when a program is stopping, pausing, and resuming.
        /// This event only applies to this SIMPL#Pro program, it doesn't receive events
        /// for other programs stopping
        /// </summary>
        /// <param name="programStatusEventType"></param>
        void ControlSystem_ControllerProgramEventHandler(eProgramStatusEventType programStatusEventType)
        {
            switch (programStatusEventType)
            {
                case (eProgramStatusEventType.Paused):
                    //The program has been paused.  Pause all user threads/timers as needed.
                    break;
                case (eProgramStatusEventType.Resumed):
                    //The program has been resumed. Resume all the user threads/timers as needed.
                    break;
                case (eProgramStatusEventType.Stopping):
                    //The program has been stopped.
                    //Close all threads. 
                    //Shutdown all Client/Servers in the system.
                    //General cleanup.
                    //Unsubscribe to all System Monitor events
                    break;
            }

        }

        /// <summary>
        /// Event Handler for system events, Disk Inserted/Ejected, and Reboot
        /// Use this event to clean up when someone types in reboot, or when your SD /USB
        /// removable media is ejected / re-inserted.
        /// </summary>
        /// <param name="systemEventType"></param>
        void ControlSystem_ControllerSystemEventHandler(eSystemEventType systemEventType)
        {
            switch (systemEventType)
            {
                case (eSystemEventType.DiskInserted):
                    //Removable media was detected on the system
                    break;
                case (eSystemEventType.DiskRemoved):
                    //Removable media was detached from the system
                    break;
                case (eSystemEventType.Rebooting):
                    //The system is rebooting. 
                    //Very limited time to preform clean up and save any settings to disk.
                    break;
            }

        }
    }
}