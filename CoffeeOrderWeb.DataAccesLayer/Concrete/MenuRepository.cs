using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Data;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Concrete
{
    public class MenuRepository : BaseRepository<Menu>,IMenuRepository
    {
        public MenuRepository(ApplicationDbContext db) : base(db) { }

    }
}
