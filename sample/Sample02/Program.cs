using Autofac;
using Autofac.Annotation;
using Autofac.Extensions.DependencyInjection;

namespace Sample02;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		var afsp = new AutofacServiceProviderFactory(x =>
		{
			x.RegisterModule(new AutofacAnnotationModule().SetDefaultAutofacScopeToSingleInstance());
		});
		builder.Host.UseServiceProviderFactory(afsp);

		var app = builder.Build();
		app.MapGet("/weatherforecast", (HttpContext httpContext, TestService ts) => ts.WeatherForCast());

		app.Run();
	}
}