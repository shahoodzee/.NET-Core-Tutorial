using MyStore.Api.Endpoints;
using MyStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

/*
When you want to connect MongoDb with .nET COre
var MongoDbConnString = "mongodb+srv://shahoodzee:Ayeshah00d@shahoodcluster.e8sm86d.mongodb.net/?retryWrites=true&w=majority&appName=ShahoodCluster";
var MongoDbName= "MyStore";


builder.Services.AddDbContext<MyStoreContext>(options=>{
    options.UseMongoDB(MongoDbConnString,MongoDbName);
});

*/
var builder = WebApplication.CreateBuilder(args);

var SQLiteConnString = builder.Configuration.GetConnectionString("MyStore");
builder.Services.AddSqlite<MyStoreContext>(SQLiteConnString);   //it usses scoped lifetime. 
//this ensures New instance of db context is created on each reequest

var app = builder.Build();

app.MapItemsEndpoints();
//app.MapItemTypesEndpoints();
app.MigrateDbAsync();
app.Run();
