using BookCatalog.DataAccess.Interfaces;
using BookCatalog.Entities.Attributes;
using BookCatalog.Entities.Data;
using BookCatalog.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.DataAccess.Repositories
{
    [ServiceDependency]
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookCatalogDbContext dbContext;
        private readonly ILogger<CategoryRepository> logger;

        public CategoryRepository(BookCatalogDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                var result = await dbContext.Categories.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Fetching Categories!");
                throw;
            }
        }
    }
}
