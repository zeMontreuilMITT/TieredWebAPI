using TieredWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TieredWebAPI.Data;
using TieredWebAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TieredWebAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TieredWebAPIContext") ?? throw new InvalidOperationException("Connection string 'TieredWebAPIContext' not found.")));

builder.Services.AddScoped<ICustomerRepo,  CustomerRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepository>();

var app = builder.Build();

app.MapGet("/customers", async (ICustomerRepo repo) =>
{
    return repo.GetCustomers();
});

app.MapGet("/customers/{id}/accounts", async (IAccountRepo accountRepo, string id) =>
{
    return;
    // Response Model
    // RModel.Account = get account, RModel.Customer = getCustoemr
});

app.MapGet("/customers/{id}/total-balance", async (TieredWebAPIContext db, string id) =>
{
    List<BankAccount> accounts = await db.BankAccount.Where(ba => ba.CustomerId == Int32.Parse(id)).ToListAsync();

    return accounts.Sum(a => a.Balance);
});

app.MapPost("/account/{id}/deposit/{amount}", async (TieredWebAPIContext db, string amount, string id) =>
{
    BankAccount account = db.BankAccount.Find(Int32.Parse(id));
    // BankAccountRepo.GetAccount(int id);

    if(Int32.Parse(amount) > account.Balance)
    {
        throw new Exception();
    }
    else
    {
        account.Balance += Int32.Parse(amount);
        db.SaveChanges(); // repo.Edit
    }
});


app.UseHttpsRedirection();

app.Run();
