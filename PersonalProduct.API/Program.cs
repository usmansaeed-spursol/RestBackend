

using PersonalCompany.PersonalProduct.Utility.Configuration;
using Sentry;
using Serilog;

using (SentrySdk.Init(o =>
{
o.Dsn = "https://aa77cc2d602542fcb0b14963fad169df@o1322639.ingest.sentry.io/6579721";
// When configuring for the first time, to see what the SDK is doing:
o.Debug = true;
// Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
// We recommend adjusting this value in production.
o.TracesSampleRate = 1.0;
}))
{

    var builder = WebApplication.CreateBuilder(args);



    

    

    IConfiguration Configuration = builder.Configuration;
    IWebHostEnvironment Environment = builder.Environment;

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            //.WriteTo.MSSqlServer(AppSettings.ConnectionString)
            .CreateLogger();

    Log.Information("Server has started");

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    //Write code here

    AppSettings.IntializeConfiguration(Configuration);




    app.Run();

}
