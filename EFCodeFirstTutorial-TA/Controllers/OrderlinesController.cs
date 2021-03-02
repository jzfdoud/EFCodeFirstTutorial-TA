using EFCodeFirstTutorial_TA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial_TA.Controllers
{
    public class OrderlinesController
    {
        private readonly AppDBContext _context = null;

        private async Task CalculateOrderTotal(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new Exception("Order not found for calculation");
            var orderlines = await _context.Orderlines.Where(ol => ol.OrderId == orderId).ToListAsync();

            decimal total = 0;
            foreach (var line in orderlines)
            {
                total += line.Quantity * line.Item.Price;
            }
            order.Total = total;
            await _context.SaveChangesAsync();
        }

        public async Task<Orderline> GetByPK(int id)
        {
            return await _context.Orderlines.FindAsync(id);
        }

        public async Task<Orderline> Create(Orderline orderline)
        {
            if (orderline == null) throw new Exception("Orderline cannot be null");

            await _context.Orderlines.AddAsync(orderline);
            await _context.SaveChangesAsync();
            await CalculateOrderTotal(orderline.OrderId);

            return orderline;
        }

        public async Task Change(int id, Orderline orderline)
        {
            if (orderline == null) throw new Exception("Orderline cannot be null");
            if (id != orderline.Id) throw new Exception("Orderline not found");

            _context.Entry(orderline).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Refresh(orderline);
            await CalculateOrderTotal(orderline.OrderId);
        }

        private void Refresh(Orderline orderline)
        {
            _context.Entry(orderline).State = EntityState.Detached;
            _context.Orderlines.Find(orderline.Id);
        }

        public async Task Remove(Orderline orderline)
        {
            if (orderline == null) throw new Exception("Orderline cannot be null");
            _context.Orderlines.Remove(orderline);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var ordLine = Get(id);
            if (ordLine == null) throw new Exception("Orderline does not exist");
            await Remove(ordLine.Result);
        }


        public OrderlinesController()
        {
            _context = new AppDBContext();
        }
    }
}
