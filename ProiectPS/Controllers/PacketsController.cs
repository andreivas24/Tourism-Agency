using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectPS.Data;
using ProiectPS.Models;
using ProiectPS.Models.Domain;

namespace ProiectPS.Controllers
{
    [Authorize(Roles="Employee")]
    public class PacketsController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public PacketsController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var packets = await mvcDemoDbContext.Packets.ToListAsync();
            return View(packets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddPacketViewModel addPacketRequest)
        {
            var packet = new Packet()
            {
                //Id = Guid.NewGuid(),
                Destination = addPacketRequest.Destination,
                Price = addPacketRequest.Price,
                StartPeriodOfTime = addPacketRequest.StartPeriodOfTime,
                EndPeriodOfTime = addPacketRequest.EndPeriodOfTime
            };

            await mvcDemoDbContext.Packets.AddAsync(packet);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var packet = await mvcDemoDbContext.Packets.FirstOrDefaultAsync(x => x.Id == id);

            if (packet != null)
            {
                var viewModel = new UpdatePacketViewModel()
                {
                    Id = packet.Id,
                    Destination = packet.Destination,
                    Price = packet.Price,
                    StartPeriodOfTime = packet.StartPeriodOfTime,
                    EndPeriodOfTime = packet.EndPeriodOfTime
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdatePacketViewModel model)
        {
            var packet = await mvcDemoDbContext.Packets.FindAsync(model.Id);

            if (packet != null)
            {
                packet.Destination = model.Destination;
                packet.Price = model.Price;
                packet.StartPeriodOfTime = model.StartPeriodOfTime;
                packet.EndPeriodOfTime = model.EndPeriodOfTime;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePacketViewModel model)
        {
            var packet = await mvcDemoDbContext.Packets.FindAsync(model.Id);

            if (packet != null)
            {
                mvcDemoDbContext.Packets.Remove(packet);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }

}
