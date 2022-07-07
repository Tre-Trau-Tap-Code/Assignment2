using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetCategories() => CategoryDAO.Instance.GetCategories;
        public Category GetCategoryById(int categoryId) => CategoryDAO.Instance.GetCategoryByID(categoryId);
        public void InsertCategory(Category category) => CategoryDAO.Instance.AddNew(category);
        public void DeleteCategory(int categoryId) => CategoryDAO.Instance.Remove(categoryId);
        public void UpdateCategory(Category category) => CategoryDAO.Instance.Update(category);
    }
}
