using FamazonAssignment.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            //session class is gereated below
            cart.Session = session;

            return cart;
        }

        //we override the previous cart class in order to pass around and edit the json string we will be passing around
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(BookData book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(BookData book)
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
