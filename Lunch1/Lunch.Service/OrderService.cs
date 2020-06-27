using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lunch.Service.Dto;
using Lunch.Data;
using Lunch.DataAccess;

namespace Lunch.Service
{
    public class OrderService
    {
        private readonly LunchContext _dbContext;

        public OrderService(LunchContext dbContex)
        {
            _dbContext = dbContex;
        }

        public List<OrderDto> GetOrders(QueryDto dto, out int total)
        {

            var data = from a in _dbContext.Orders
                       join d in _dbContext.Users
                       on a.UserId equals d.Id
                       select new OrderDto
                       {
                           Id = a.Id,
                           UserName = d.Name,
                           Address = d.Address,
                           Phone = d.Phone,
                           CreateTime = a.CreateTime,
                           Status = a.Status,
                           Price = a.Price
                       };

            total = data.Count();
            var orders = data.Skip((dto.PageNo - 1) * dto.PageSize).Take(dto.PageSize).ToList();

            var orderIds = orders.Select(x => x.Id).ToList();
            var foods = (from a in _dbContext.Order_Foods.Where(x => orderIds.Contains(x.OrderId))
                         join b in _dbContext.FoodMenus
                         on a.FoodId equals b.Id
                         select new
                         {
                             a.OrderId,
                             b.Name,
                             a.Count
                         }).ToList();

            orders.ForEach(x =>
            {
                var foodList = foods.Where(y => y.OrderId == x.Id)
                    .Select(y => new Tuple<string, int>(y.Name, y.Count)).ToList();
                x.FoodDic = foodList;
            });

            return orders;
        }

        public async Task<bool> UpdateOrderStatus(int orderId, string stauts)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null) return false;

            order.Status = stauts;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool OrderingFood(int userId, decimal totalPrice, List<int> foodIds)
        {
            var order = new Order()
            {
                UserId = userId,
                Price = totalPrice,
                Status = "已付款",
                CreateTime = DateTime.Now
            };
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            var addedIds = new List<Order_Food>();
            foreach(var id in foodIds)
            {
                var added = addedIds.FirstOrDefault(x => x.FoodId == id);
                if (added == null) {
                    var orderFood = new Order_Food()
                    {
                        OrderId = order.Id,
                        FoodId = id,
                        Count = 1
                    };
                    _dbContext.Order_Foods.Add(orderFood);
                }
                else
                {
                    added.Count++;
                }
            }

            return _dbContext.SaveChanges() > 0;
        }
    }
}
