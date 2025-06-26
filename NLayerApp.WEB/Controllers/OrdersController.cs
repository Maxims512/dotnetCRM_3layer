using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.Services;
using NLayerApp.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerApp.WEB.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IMapper mapper, IUserService userService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var orderDtos = _orderService.GetAllOrders();
            var orderViewModels = _mapper.Map<IEnumerable<OrderViewModel>>(orderDtos);
            return View(orderViewModels);
        }

        public IActionResult Create()
        {
           
            ViewBag.Users = _userService.GetUsers().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var orderDto = _mapper.Map<OrderDTO>(orderViewModel);
                _orderService.CreateOrder(orderDto);
                return RedirectToAction(nameof(Index));
            }
            return View(orderViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDto = _orderService.GetOrder(id);
            if (orderDto == null)
            {
                return NotFound();
            }

            var orderViewModel = _mapper.Map<OrderViewModel>(orderDto);
            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderViewModel orderViewModel)
        {
            if (id != orderViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var orderDto = _mapper.Map<OrderDTO>(orderViewModel);
                    _orderService.UpdateOrder(orderDto);
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                    return View(orderViewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            _orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}