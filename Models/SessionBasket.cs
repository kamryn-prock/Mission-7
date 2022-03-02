using BookProject.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookProject.Models
{
    public class SessionBasket : Basket // set up instance of the session basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // pull information about session

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket(); // go get the json if there is some under the session basket that matches. if there isn't any, create a new session

            basket.Session = session; // update the session info to be what we found

            return basket;
        }

        [JsonIgnore] // prevents a property from being serialized or deserialized
        public ISession Session { get; set; }


        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

    }
}
