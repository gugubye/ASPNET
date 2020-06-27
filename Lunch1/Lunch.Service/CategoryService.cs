using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunch.Service.Dto;
using Lunch.Data;
using Lunch.DataAccess;

namespace Lunch.Service
{
    public class CategoryService
    {
        private readonly LunchContext _dbContext;

        public CategoryService(LunchContext dbContex)
        {
            _dbContext = dbContex;
        }

        public List<Category> GetCategory()
        {
            var query = _dbContext.Categorys;
            return query.ToList();
        }

        public bool EditCategory(CategoryDto dto)
        {
            if (dto.Id > 0)
            {
                var model = _dbContext.Categorys.FirstOrDefault(x => x.Id == dto.Id);
                if (model == null) return false;
                model.Name = dto.Name;
            }
            else
            {
                var category = new Category()
                {
                    Name = dto.Name,
                };
                _dbContext.Categorys.Add(category);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteCategory(int id)
        {
            var model = _dbContext.Categorys.FirstOrDefault(x => x.Id == id);
            if (model == null) return false;

            _dbContext.Categorys.Remove(model);
            return _dbContext.SaveChanges() >0;
        }
    }
}
