using Dapper;
using System.Data;

namespace Hadisene.Lib;
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-8.0&tabs=visual-studio#asynchronous-timed-background-task
public class TimedHostedService : BackgroundService
{
	private readonly ILogger<TimedHostedService> _logger;
	private int _executionCount;
	private readonly IDbCon db;

	public TimedHostedService(ILogger<TimedHostedService> logger, IDbCon db)
	{
		_logger = logger;
		this.db = db;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation("Timed Hosted Service running. {RunTime}", DateTime.Now);

		// When the timer should have no due-time, then do the work once now.
		// DoWork(); //Hemen yapmasına gerek yok

		await DoWork();
		using PeriodicTimer timer = new(TimeSpan.FromHours(1));

		try
		{
			while (await timer.WaitForNextTickAsync(stoppingToken))
			{
				await DoWork();
			}
		}
		catch (OperationCanceledException)
		{
			_logger.LogInformation("Timed Hosted Service is stopping. {RunTime}", DateTime.Now);
		}
	}

	// Could also be a async method, that can be awaited in ExecuteAsync above
	private async Task DoWork()
	{
		int count = Interlocked.Increment(ref _executionCount);

		_logger.LogInformation("Timed Hosted Service {RunTime} NoC:{count}", DateTime.Now, count);

		using var conn = db.GetConnection();
		await conn.ExecuteAsync("PP2OO", param: null, commandType: CommandType.StoredProcedure);
	}
}
