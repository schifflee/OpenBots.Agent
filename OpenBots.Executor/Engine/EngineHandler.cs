using OpenBots.Executor.Model;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OpenBots.Executor
{
    public class EngineHandler
    {
        private Assembly _engineAssembly;
        private EngineAssemblyInfo _assemblyInfo;
        public EngineHandler()
        {
            _assemblyInfo = new EngineAssemblyInfo();
            LoadEngineAssembly();
        }

        private void LoadEngineAssembly()
        {
            var engineAssemblyFilePath = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, _assemblyInfo.FileName).FirstOrDefault();
            if (engineAssemblyFilePath != null)
                _engineAssembly = Assembly.LoadFrom(engineAssemblyFilePath);
            else
                throw new Exception($"Assembly path for {_assemblyInfo.FileName} not found.");
        }

        public void ExecuteScript(string filePath)
        {
            Type t = _engineAssembly.GetType(_assemblyInfo.ClassName);

            var methodInfo = t.GetMethod(_assemblyInfo.MethodName, new Type[] { typeof(string) });
            if (methodInfo == null)
            {
                throw new Exception($"No method exists with name {_assemblyInfo.MethodName} within Type {_assemblyInfo.ClassName}");
            }

            //
            // Specify paramters for the constructor: 'AutomationEngineInstance(bool isRemoteExecution = false)'
            //
            object[] engineParams = new object[1];
            engineParams[0] = true;
            //
            // Create instance of Class "AutomationEngineInstance".
            //
            var engine = Activator.CreateInstance(t, engineParams);

            //
            // Specify parameters for the method we will be invoking: 'void ExecuteScriptSync(string filePath)'
            //
            object[] parameters = new object[1];
            parameters[0] = filePath;            // 'filePath' parameter

            //
            // 6. Invoke method 'void ExecuteScriptSync(string filePath)'
            //
            methodInfo.Invoke(engine, parameters);
        }
    }
}
