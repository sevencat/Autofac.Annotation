using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Autofac.Annotation.Test.test6
{
    [Pointcut(Class = "LogAspectTest?",Method = "Test1")]
    [Pointcut("name1",Class = "LogAspectT1est",Method = "Test1")]
    [Pointcut("name2",Class = "LogAspect[ABC]")]
    [Pointcut("name3",Class = "LogAroundTest",Method="Hello*")]
    [Pointcut("name4",Class = "LogTaskTest",Method="Hello*")]
    [Pointcut("name5",Class = "TestCacheAop3*",Method="TestInterceptor2")]
    public class LogAspect
    {
        [Autowired("A3612",CircularDependencies = true)]
        public A36 A36 { get; set; }
        
        [Value("aaaaa")]
        public string Test { get; set; }
        
        
        [Before]
        public void Before()
        {
            Console.WriteLine("Before");
        }
        
        [AfterReturn]
        public void AfterReturn()
        {
            Console.WriteLine("AfterReturn");
        }
        
        [Before("name1")]
        public void Before1()
        {
            Console.WriteLine("Before1");
        }
        
        [AfterReturn("name1")]
        public void AfterReturn1()
        {
            Console.WriteLine("AfterReturn1");
        }
        
        
        [Before("name2")]
        public void Before2()
        {
            Console.WriteLine("Before2");
        }
        
        [AfterReturn("name2")]
        public void AfterReturn2()
        {
            Console.WriteLine("AfterReturn2");
        }

        [Around("name3")]
        public async Task Around(AspectContext context,AspectDelegate _next)
        {
            Console.WriteLine(context.TargetMethod.Name + "-->Start");
            await _next(context);
            Console.WriteLine(context.TargetMethod.Name + "-->End");
        }
        
        
        [Before("name4")]
        public async Task Before4()
        {
            await Task.Delay(1000);
            Console.WriteLine("Before4");
        }
        
        [AfterReturn("name4")]
        public async Task AfterReturn4()
        {
            await Task.Delay(1000);
            Console.WriteLine("AfterReturn4");
        }
        
        [Before("name5")]
        public async Task Before5()
        {
            await Task.Delay(1000);
            Console.WriteLine("Before5");
        }
        
        [AfterReturn("name5")]
        public async Task AfterReturn5()
        {
            await Task.Delay(1000);
            Console.WriteLine("AfterReturn5");
        }
    }

    [Component]
    public class LogAspectTest1
    {
        //  [Pointcut(Class = "LogAspectTest?",Method = "Test1")]
        public virtual void Test1()
        {
            Console.WriteLine("Test1");
        }
        
        //不会被切面
        public virtual void Test2()
        {
            Console.WriteLine("Test2");
        }
    }
    
    [Component]
    public class LogAspectTest2
    {
        public virtual void Test1()
        {
            Console.WriteLine("Test1");
        }
        
        public virtual void Test2()
        {
            Console.WriteLine("Test2");
        }
    }
    
    
    [Component]
    public class LogAspectT1est
    {
        public virtual void Test1()
        {
            Console.WriteLine("Test1");
        }
        
        public virtual void Test2()
        {
            Console.WriteLine("Test2");
        }
    }
    
    public interface IAspectA
    {
        void Hello(string msg);
        string Hello2(string msg);
    }

    [Component]
    public class LogAspectA : IAspectA
    {
        public void Hello(string msg)
        {
            Console.WriteLine(msg);
        }

        public string Hello2(string msg)
        {
            return msg;
        }
    }
    public interface IAspecB
    {
        void Hello(string msg);
        string Hello2(string msg);
    }
    [Component]
    public class LogAspectB : IAspecB
    {
        //name2 的切面
        public void Hello(string msg)
        {
            Console.WriteLine(msg);
        }
        //name2 的切面
        public string Hello2(string msg)
        {
            return msg;
        }
    }
    
    [Component]
    public class LogAroundTest
    {
        public virtual void Hello(string msg)
        {
            Console.WriteLine(msg);
        }
        
        public virtual string Hello2(string msg)
        {
            return msg;
        }
    }
    
    [Component]
    public class LogTaskTest
    {
        public virtual void Hello(string msg)
        {
            Console.WriteLine(msg);
        }
        
        public virtual string Hello2(string msg)
        {
            return msg;
        }
    }

    // *Controller 代表匹配 只要是Controller结尾的类都能匹配
    // Get* 代表上面匹配成功的类下 所以是Get打头的方法都能匹配
    [Pointcut(Class = "*Controller",Method = "Get*")]
    public class LoggerPointCut
    {
        /// <summary>
        /// 打上Before标签 代表满足匹配的方法 在执行之前会执行下面的Before()方法
        /// </summary>
        [Before]
        public void Befor()
        {
            Console.WriteLine("before");
        }

        /// <summary>
        /// 打上After标签 代表满足匹配的方法 在执行之前会执行下面的After()方法
        /// </summary>
        [AfterReturn]
        public void AfterReturn()
        {
            Console.WriteLine("after");
        }
        
        /// <summary>
        /// 打上Around标签 承接了 匹配成功的类的方法的执行权
        /// </summary>
        /// <param name="context"></param>
        // [Around]
        // public void Around(AspectContext context)
        // {
        //     //执行原目标方法前
        //     Console.WriteLine(context.InvocationContext.MethodInvocationTarget.Name + "-->Start");
        //     //执行原目标方法
        //     context.InvocationProceedInfo.Invoke();
        //     //执行原目标方法后
        //     Console.WriteLine(context.InvocationContext.MethodInvocationTarget.Name + "-->End");
        // }
    }
    
    
    [Component]
    public class ProductController
    {
        public virtual string GetProduct(string productId)
        {
            return "GetProduct:" + productId;
        }
        
        public virtual string UpdateProduct(string productId)
        {
            return "UpdateProduct:" + productId;
        }
    }
    
    [Component]
    public class UserController
    {
        public virtual string GetUser(string userId)
        {
            return "GetUser:" + userId;
        }
        
        public virtual string DeleteUser(string userId)
        {
            return "DeleteUser:" + userId;
        }
    }
}