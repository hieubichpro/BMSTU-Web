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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<IClubRepository, ClubRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MatchService>();
builder.Services.AddScoped<LeagueService>();
builder.Services.AddScoped<ClubService>();
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

app.Run();
