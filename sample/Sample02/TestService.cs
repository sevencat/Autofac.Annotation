using Autofac.Annotation;

namespace Sample02;

[Component]
public class TestService
{
	[Value("testcnt", DefaultValue = 3)]
	private int Count;

	[Value("testcnt2")]
	private List<int>? TestList;

	public List<WeatherForecast> WeatherForCast()
	{
		var summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		var forecast = Enumerable.Range(1, Count).Select(index =>
				new WeatherForecast
				{
					Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = summaries[Random.Shared.Next(summaries.Length)]
				})
			.ToList();
		return forecast;
	}
}