
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
 
/// <summary>
/// The main entry point for the application.
/// </summary>
[STAThread]
int main(array<System::String ^> ^args)
{
    if (args->Length < 1)
    {
        Console::WriteLine("Usage: Executable_file_name <name to resolve>");
        Console::WriteLine("Example: Executable_file_name www.yahoo.com");
        return 0;
    }
 
    try
    {
        IPHostEntry^ IPHost = Dns::GetHostEntry(args[0]->ToString());
 
        // Print out the host name that was queried
        Console::WriteLine("The primary host name is: " + IPHost->HostName->ToString());
 
        // Print out any aliases that are found
        if (IPHost->Aliases->Length > 0)
        {
            Console::WriteLine("Aliases found are:");
            for each (String^ Alias in IPHost->Aliases)
            {
                Console::WriteLine(Alias);
            }
        }
        Console::WriteLine("No Aliases found...");
        Console::WriteLine("IP addresses found are:");
 
        int IPv4Count = 0;
        int IPv6Count = 0;
 
        // Print out all the IP addresses that are found
        Console::WriteLine("\nPrinting out all the found IP addresses...");
        for each (IPAddress^ Address in IPHost->AddressList)
        {
            if (Address->AddressFamily == AddressFamily::InterNetwork)
            {
                IPv4Count++;
                Console::WriteLine("IPv4 Address #" + IPv4Count.ToString() + " is " + Address->ToString());
            }
                 else if (Address->AddressFamily == AddressFamily::InterNetworkV6)
            {
                IPv6Count++;
                Console::WriteLine("IPv6 Address #" + IPv6Count.ToString() + " is " + Address->ToString());
            }
        }
    }
    catch (Exception^ e)
    {
        Console::WriteLine("GetHostEntry() failed with error: " + e->Message);
    }
    return 0;
}