using lab_03.BL.IRepositories;
using lab_03.BL.Services;
using lab_03.DA.dbContext;
using lab_03.DA.dbContext.PostgreSQL;
using lab_03.DA.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = new ConfigurationBuilder()
                                       .AddJsonFile("appsettings.json")
                                       .Build();
builder.Services.AddSingleton<dbContextFactory, pgSqlDbContextFactory>();
builder.Services.AddSingleton(configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMatchRepository, MatchRepository>();
builder.Services.AddTransient<ILeagueRepository, LeagueRepository>();
builder.Services.AddTransient<IClubRepository, ClubRepository>();

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<MatchService>();
builder.Services.AddTransient<LeagueService>();
builder.Services.AddTransient<ClubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
