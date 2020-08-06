using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using ex11.Entities.Enums;

namespace ex11.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem items)
        {
            Items.Add(items);
        }

        public void RemoveItem(OrderItem items)
        {
            Items.Remove(items);
        }

        public double Total()
        {
            double total = 0.0;
            
            foreach(OrderItem items in Items)
            {
                total += items.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder txt = new StringBuilder();
            txt.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            txt.AppendLine("Order status: " + Status);
            txt.AppendLine("Client: " + Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " + Client.Email);
            txt.AppendLine("Order Items:");
            foreach (OrderItem item in Items)
            {
                txt.AppendLine(item.ToString());
            }
            txt.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return txt.ToString();
        }
    }
}
