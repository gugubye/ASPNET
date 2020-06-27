using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lunch.Service.Dto;
using Lunch.Data;
using Lunch.DataAccess;

namespace Lunch.Service
{
    public class FoodService
    {
        private readonly LunchContext _dbContext;
        public FoodService(LunchContext dbContex)
        {
            _dbContext = dbContex;
        }

        public FoodMenu GetFood(int id)
        {
            return _dbContext.FoodMenus.FirstOrDefault(x => x.Id == id);
        }

        public List<FoodMenu> QueryFoods(string keyword, string type, int pageSize, int pageIndex, out int total)
        {
            var query = _dbContext.FoodMenus.AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(x => x.Type == type);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            var foods = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            total = query.Count();
            return foods;
        }

        public int AddFoodMenu(FoodMenuDto food, byte[] image, string imageType)
        {
            if (food.Id > 0) {
                var model = _dbContext.FoodMenus.FirstOrDefault(x => x.Id == food.Id);
                if (model == null) return 0;

                model.Image = image;
                model.ImageType = imageType;
                model.Name = food.Name;
                model.Description = food.Description;
                model.Type = food.Type;
                model.Price = food.Price;
                model.StockCount = food.StockCount;
            }
            else
            {
                var foodModel = new FoodMenu()
                {
                    Name = food.Name,
                    Description = food.Description,
                    Type = food.Type,
                    Image = image,
                    ImageType = imageType,
                    Price = food.Price,
                    StockCount = food.StockCount,
                    CreateTime = DateTime.Now
                };
                _dbContext.FoodMenus.Add(foodModel);
            }

            return _dbContext.SaveChanges();
        }

        public List<StatisticsDto> GetStatistics(QueryDto filter)
        {
            var query = from a in _dbContext.Orders
                        join b in _dbContext.Order_Foods
                        on a.Id equals b.OrderId
                        join c in _dbContext.FoodMenus
                        on b.FoodId equals c.Id
                        select new
                        {
                            a.CreateTime,
                            c.Name,
                            b.Count,
                            c.Price
                        };
            if (filter.Start != null)
            {
                query = query.Where(x => x.CreateTime >= filter.Start);
            }
            if (filter.End != null)
            {
                query = query.Where(x => x.CreateTime <= filter.End);
            }

            var data = query.ToList();

            var list = data.GroupBy(x => x.Name).Select(x => new StatisticsDto
            {
                FoodName = x.Key,
                Count = x.Sum(y => y.Count),
                Price = x.Sum(y => y.Price)
            });
            return list.ToList();
        }

        public bool Delete(int id)
        {
            var model = _dbContext.FoodMenus.FirstOrDefault(x => x.Id == id);
            if (model == null) return false;

            _dbContext.FoodMenus.Remove(model);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
