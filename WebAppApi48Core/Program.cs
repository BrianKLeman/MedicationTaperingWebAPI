using Data.Services.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using WebAppApi48Core.Services;

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

const string MyAllowSpecificOrigins = "MyAllowSpecificOrigins";
CorsPolicy policy = new CorsPolicyBuilder().WithOrigins("http://localhost:4200").AllowAnyHeader()
    .AllowAnyMethod().SetIsOriginAllowed(x => true).Build();
builder.Services.AddCors(x => x.AddPolicy(MyAllowSpecificOrigins, policy));


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(connectionString));
builder.Services.AddScoped<ITableNotesLinksDataAccess, NoteLinksDataAccess>();
builder.Services.AddScoped<INotesDataAccess, NotesDataAccess>();
builder.Services.AddScoped<IMedicationDataAccess, MedicationDataAccess>();
builder.Services.AddScoped<IPrescriptionDataAccess, PrescriptionDataAccess>();
builder.Services.AddScoped<IPersonDataAccess, PersonDataAccess>();
builder.Services.AddScoped<ILearningAimsDataAccess, LearningAimsDataAccess>();
builder.Services.AddScoped<IProjectsDataAccess, ProjectsDataAccess>();
builder.Services.AddScoped<ISleepsDataAccess, SleepsDataAccess>();
builder.Services.AddScoped<IPhenomenaDataAccess, PhenomenaDataAccess>();
builder.Services.AddScoped<IAppointmentsDataAccess, AppointmentsDataAccess>();
builder.Services.AddScoped<IJobsAtHomeViewsDataAccess, JobsAtHomeViewsDataAccess>();
builder.Services.AddScoped<IJobsAtHomeLogDataAccess, JobsAtHomeLogDataAccess>();
builder.Services.AddScoped<ITasksDataAccess, TasksDataAccess>();
builder.Services.AddScoped<ITableTasksLinksDataAccess, TaskLinksDataAccess>();
builder.Services.AddScoped<IGroupsDataAccess, GroupsDataAccess>();
builder.Services.AddScoped<IAdhocTablesDataAccess, AdhocTablesDataAccess>();
builder.Services.AddScoped<IAdhocColumnDataAccess, AdhocTablesColumnsDataAccess>();
builder.Services.AddScoped<IAdhocTablesDetailsDataAccess, AdhocTablesDetailsDataAccess>();
builder.Services.AddScoped<IAdhocTableRowDataAccess, AdhocTablesRowsDataAccess>();
builder.Services.AddScoped<IFeaturesDataAccess, FeaturesDataAccess>();
builder.Services.AddScoped<IAuthService, AuthService>();


// OData
ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<ShoppingItems>("ShoppingItems");
modelBuilder.EntitySet<Alcohol>("Alcohol");
modelBuilder.EntitySet<Sprint>("Sprints");


builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
    "odata",
        modelBuilder.GetEdmModel()));
var app = builder.Build();
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
