using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Identity;
using SupportSystemApp.Repository;
using SupportSystemApp.Service.Implementation;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SupportSystemApp.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ISiteService _siteService;
        private readonly ISupportGroupService _supportGroupService;
        private readonly ITicketModeService _ticketModeService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly IService_CategoryService _serviceCategoryService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly ICategoryItemService _categoryItemService;
        private readonly IImpactService _impactService;
        private readonly IUrgencyService _urgencyService;

        private readonly UserManager<SupportSystemAppUser> _userManager;

        public TicketsController(ITicketService ticketService, ISiteService siteService, 
            ISupportGroupService supportGroupService,
            ITicketModeService ticketModeService,
            ITicketTypeService ticketTypeService,
            IService_CategoryService serviceCategoryService,
            UserManager<SupportSystemAppUser> userManager,
            IPriorityService priorityService, IStatusService statusService,
            ICategoryItemService categoryItemService,
            ISubcategoryService subcategoryService,
            ICategoryService categoryService,
            IImpactService impactService,
            IUrgencyService urgencyService)
        {
            _ticketService = ticketService;
            _siteService = siteService;
            _supportGroupService = supportGroupService;
            _ticketModeService = ticketModeService;
            _ticketTypeService = ticketTypeService;
            _serviceCategoryService = serviceCategoryService;
            _userManager = userManager;
            _priorityService = priorityService;
            _statusService = statusService;
            _categoryItemService = categoryItemService;
            _subcategoryService = subcategoryService;
            _categoryService = categoryService;
            _impactService = impactService;
            _urgencyService = urgencyService;
        }


        private void PopulateDropdowns(Guid? categoryId = null, Guid? subcategoryId = null)
        {
            ViewBag.Categories = _categoryService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.Subcategories = categoryId.HasValue
                ? _subcategoryService.GetAllByCategoryId(categoryId.Value)
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    })
                    .ToList()
                : _subcategoryService.GetAll()
                    .Where(s => s.Name == "Not Specified")
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name,
                        Selected = true
                    })
                    .ToList();


            ViewBag.Items = subcategoryId.HasValue
              ? _categoryItemService.GetCategoryItemsBySubcategoryID(subcategoryId.Value)
                  .Select(i => new SelectListItem
                  {
                      Value = i.Id.ToString(),
                      Text = i.Name
                  })
                  .ToList()
              : _categoryItemService.GetAll()
                .Where(s => s.Name == "Not Specified")
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = i.Name
                })
                .ToList();


            //THE REST OF THE DROPDOWNS

            ViewBag.Sites = _siteService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.SupportGroups = _supportGroupService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.Users = _userManager.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName
                })
                .ToList();

            ViewBag.Priorities = _priorityService.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            ViewBag.Statuses = _statusService.GetAll()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();

            ViewBag.Sites = _siteService.GetAll()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();

            ViewBag.TicketModes = _ticketModeService.GetAll()
                .Select(tm => new SelectListItem
                {
                    Value = tm.Id.ToString(),
                    Text = tm.Name
                })
                .ToList();

            ViewBag.TicketTypes = _ticketTypeService.GetAll()
                .Select(tt => new SelectListItem
                {
                    Value = tt.Id.ToString(),
                    Text = tt.Name
                })
                .ToList();

            ViewBag.ServiceCategories = _serviceCategoryService.GetAll()
                .Select(sc => new SelectListItem
                {
                    Value = sc.Id.ToString(),
                    Text = sc.Name
                })
                .ToList();

            ViewBag.Impacts = _impactService.GetAll()
                .Select(sc => new SelectListItem
                {
                    Value = sc.Id.ToString(),
                    Text = sc.Name
                }
                ).ToList();

            ViewBag.Urgencies = _urgencyService.GetAll()
                .Select(sc => new SelectListItem
                {
                    Value = sc.Id.ToString(),
                    Text = sc.Name
                }
                ).ToList();
        }

        public IActionResult Index()
        {
            PopulateDropdowns();

            return View(_ticketService.GetAll());
        }

        public IActionResult Details(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        public IActionResult Create()
        {
            PopulateDropdowns();

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("TicketNumber,Header,Details,Status,Priority,CreatedAt,DueBy,ResolvedAt,RequesterId,TechnitianId,SiteId,SupportGroupId,Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.Insert(ticket);
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdowns(ticket.CategoryId, ticket.SubcategoryId);
            return View(ticket);
        }


        public IActionResult Edit(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            PopulateDropdowns();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("TicketNumber,Header,Details,Status,Priority,CreatedAt,DueBy,ResolvedAt,RequesterId,TechnitianId,SiteId,SupportGroupId,Id")]
            Ticket ticket, List<IFormFile> attachments)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.Update(ticket);

                    if (attachments != null && attachments.Any())
                    {
                        foreach (var file in attachments)
                        {
                            if (file.Length > 0)
                            {
                                // max 25 MB
                                if (file.Length > 25 * 1024 * 1024)
                                {
                                    ModelState.AddModelError(
                                        "attachments",
                                        "Maximum file size is 25 MB.");

                                    PopulateDropdowns(
                                        ticket.CategoryId,
                                        ticket.SubcategoryId);

                                    return View(ticket);
                                }

                                // tuka ke go zacuvame attachmentot
                            }
                        }
                    }
                    }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdowns(ticket.CategoryId, ticket.SubcategoryId);

            return View(ticket);
        }


        public IActionResult Delete(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket != null)
            {
                _ticketService.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _ticketService.GetById(id) != null;
        }
    }
}
