using banner.Context;
using banner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace banner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly BannersContext _context;
        public BannerController(BannersContext context) => _context = context;
        [HttpGet] public IEnumerable<Banner> GetBanners() => _context.banner.ToList();
        [HttpPost, Authorize] public Banner PostBanners(Banner banner) { var newBanner = _context.banner.Add(banner); _context.SaveChanges(); return newBanner.Entity; }
        [HttpDelete("{id}"), Authorize] public Banner PostBanner(Guid id) { Banner deleteBanner = _context.banner.FirstOrDefault(i => i.Id == id); _context.banner.Remove(deleteBanner); _context.SaveChanges(); return deleteBanner; }
        [HttpPut, Authorize] public Banner UpdateBanner(Banner banner) { var bannerToUpdate=_context.banner.Update(banner); _context.SaveChanges(); return bannerToUpdate.Entity; }
    }
}
