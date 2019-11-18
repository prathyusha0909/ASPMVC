using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class CategoryRepository :IRepository<Category,int>
    {
        CategoryDataAccess dataAccess;
        public CategoryRepository()
        {
            dataAccess = new CategoryDataAccess();
        }
        public void CreateNew(Category item)
        {
            dataAccess.CreateOrUpdate(item: item, createOrUpdate: 'C');
        }
        
        public IQueryable<Category> GetAll()
        {
            return dataAccess.GetCategories().AsQueryable();
        }
        public Category GetDetails(int identity)
        {
            return dataAccess.GetCategory(categoryId: identity);
        }
        public void Update(Category item)
        {
            dataAccess.CreateOrUpdate(item: item, createOrUpdate: 'U');
        }
        public void Delete(int identity)
        {
            throw new NotImplementedException();
        }
    }
}