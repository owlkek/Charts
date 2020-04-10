using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charts.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Charts.Controllers
{
	public class TrackController : Controller
	{
		// GET: Track
		public ActionResult Index()
		{
			return View();
		}

		// GET: Track/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Track/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Track/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Track/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Track/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Track/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Track/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public IActionResult Info(string id)
		{
			var model = LocalStorage.Insatence.Tracks
				.Single(x => x.Name == id);

			return View(model);
		}
	}
}