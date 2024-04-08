using Autofac;
using Autofac.Annotation;

namespace Sample01;

class Program
{
	static void Main(string[] args)
	{
		var builder = new ContainerBuilder();
		builder.RegisterSpring(r => r.RegisterAssembly(typeof(Program).Assembly));
		var container = builder.Build();
		var a1 = container.Resolve<Test12Bean1>();
		var a2 = container.Resolve<Test12Bean1>();
		return;
	}
}