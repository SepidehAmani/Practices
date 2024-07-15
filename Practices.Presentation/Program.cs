
using Microsoft.EntityFrameworkCore;
using Practices.Application.Mappings.Profiles;
using Practices.Application.Services.Implementations;
using Practices.Application.Services.Interfaces;
using Practices.Domain.IRepositories;
using Practices.Domain.UnitOfWorkInterface;
using Practices.Infrastructure.DBContext;
using Practices.Infrastructure.Repositories;
using Practices.Infrastructure.UnitOfWorkImplementation;
using System;

namespace Practices.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(GeneralMappingProfile));

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("PracticesDb")));

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBookService, BookService>();
            

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
        }
    }
}
