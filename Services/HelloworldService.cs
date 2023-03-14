using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_.NET.Services
{
    public class HelloworldService :IHelloWorldService
    {
        public string GetHelloWorld(){
            return "Hello Wordl";
        }
    }


    public interface IHelloWorldService{
    
    string GetHelloWorld();
}
}

