/*------------------------------------------------------------------------
0. File: secureDIMain.cs
1. Purpose: To show the concept of Extensibility via "Dependency Injection"
2. Author: Insoo Kim ( insoo@timmanage.com )
3. Created: Tue. Jan 25, 2022
4. Updated: 
5. How to run on Ubuntu Linux:
  A. Install Mono dev. tool chain.
    $ sudo apt install mono-complete
  B. Build
    $ mcs -out:secureDIMain.exe secureDIMain.cs
    --> Linux built binaries can be run on Windows, 
    --> but its file extenstion should be modified as "exe" to run on Windows.
  C. Run on Linux or Windows
    $ ./secureDIMain
6. Ref
  A. How can I compile, run and decompile C# code in Ubuntu terminal?
  https://askubuntu.com/questions/1100537/how-can-i-compile-run-and-decompile-c-code-in-ubuntu-terminal
  B. Install the .NET SDK or the .NET Runtime on Ubuntu
  https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu
------------------------------------------------------------------------*/
using System;
using System.Security.Principal;

namespace TIM
{
    class EntryClass
    {
        private static void Main()
        {
            IMessageWriter writer = new ConsoleMsgWriter();
            var salute = new Salute(writer);
            salute.Exclaim();
        }
    }//EntryClass

    public class Salute
    {
        private readonly IMessageWriter writer;
        public Salute(IMessageWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.writer = writer;
        }//constructor

        public void Exclaim()
        {
            this.writer.Write("Hello, Dependency Injection World!");
        }
    }//class Salute

    public interface IMessageWriter
    {
        void Write(string msg);
    }//interface IMessageWriter

    public class ConsoleMsgWriter : IMessageWriter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }//class ConsoleMsgWriter

    public class SecureMsgWriter : IMessageWriter
    {
        private readonly IMessageWriter writer;
        private readonly IIdentity identity;

    }

}