﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Category;
using PetStore.Web.Models.Categories;

namespace PetStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DetailsCategoryServiceModel category = categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            var viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel catEditInputModel)
        {
            if (!categoryService.Exists(catEditInputModel.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var editCatServModel = new EditCategoryServiceModel()
            {
                Id = catEditInputModel.Id,
                Name = catEditInputModel.Name,
                Description = catEditInputModel.Description
            };

            categoryService.Edit(editCatServModel);

            return RedirectToAction("Details", "Categories", new { id=editCatServModel.Id });
        }

        [HttpGet]
        public IActionResult Details( int id)
        {
            DetailsCategoryServiceModel category = categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            if (viewModel.Description == null)
            {
                viewModel.Description = "No description.";
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var serviceModel = new CreateCategoryServiceModel()
            {
                Name = inputModel.Name,
                Description = inputModel.Description
            };

            categoryService.Create(serviceModel);

            return RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categories = categoryService.All()
                .Select(csm => new CategoryListingViewModel()
                {
                    Id = csm.Id,
                    Name = csm.Name
                }).ToArray();

            return View(categories);
        }
    }
}