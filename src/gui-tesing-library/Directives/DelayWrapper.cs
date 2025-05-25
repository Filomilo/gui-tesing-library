using MethodDecorator.Fody.Interfaces;
using System;
using System.Reflection;
using System.Threading;
using gui_tesing_library;

namespace gui_tesing_library_CS.Directives
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
    class DelayAttribute : Attribute, IMethodDecorator
    {
        private MethodBase _method;
        public void Init(object instance, MethodBase method, object[] args)
        {

        }

        public void OnEntry()
        {
            Thread.Sleep(Configuration.ActionDelay);
        }

        public void OnExit()
        {
            //Console.WriteLine($"{_method.Name} finshed");
        }

        public void OnException(Exception exception)
        {
            //ErrorController.Throw($"{_method.Name} executed with excpetion", exception);
        }
    }
}
