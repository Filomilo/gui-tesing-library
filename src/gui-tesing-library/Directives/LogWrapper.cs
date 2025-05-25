using gui_tesing_library.Controllers;
using MethodDecorator.Fody.Interfaces;
using System;
using System.Reflection;
using gui_tesing_library_CS.Controllers;

namespace gui_tesing_library_CS.Directives
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
    class LogAttribute : Attribute, IMethodDecorator
    {
        private MethodBase _method;
        public void Init(object instance, MethodBase method, object[] args)
        {
            _method = method; ;
        }

        public void OnEntry()
        {
            Console.WriteLine($"{_method.Name} started");
        }

        public void OnExit()
        {
            Console.WriteLine($"{_method.Name} finshed");
        }

        public void OnException(Exception exception)
        {
            ErrorController.Throw($"{_method.Name} executed with excpetion", exception);
        }
    }
}
