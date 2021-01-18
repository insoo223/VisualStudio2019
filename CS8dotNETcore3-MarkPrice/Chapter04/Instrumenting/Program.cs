using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Instrumenting
{
  class Program
  {
    static void Main(string[] args)
    {
            // write to a text file in the project folder
            Trace.Listeners.Add(new TextWriterTraceListener(
              File.CreateText("log.txt")));

            // text writer is buffered, so this option calls
            // Flush() on all listeners after writing
            Trace.AutoFlush = true;

            Debug.WriteLine("Debug says, 안녕 인수!, I am watching!");
            Trace.WriteLine("Trace says, 你好，仁秀！，I am watching!");

            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json",
                optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
              displayName: "PacktSwitch",
              description: "This switch is set via a JSON config.");

            configuration.GetSection("PacktSwitch").Bind(ts);

            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }//Main
        
        //sub2 function is a code snippet container added by Insoo (Mon Jan 18, 2021)
        //As to follow the text book, you need to modity the Main ft, 
        //and this snippet container make it easy to copy and paste along with your trial.
        public void sub2()
        {
            /*
            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");

            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json",
                optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
              displayName: "PacktSwitch",
              description: "This switch is set via a JSON config.");

            configuration.GetSection("PacktSwitch").Bind(ts);

            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
            */
        }
    }//Program
}//Instrumenting