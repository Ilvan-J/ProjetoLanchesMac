﻿using LancheMac.Models;
using LancheMac.Repositories;
using LancheMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LancheMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoria = "Todos os lanches";
            }
            else
            {
                if(string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l =>
                    l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(l =>
                    l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
                }
                categoriaAtual = _categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            
            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            if (lanche == null)
            {
               // return ("~/Views/Error/Error.cshtml");
            }
            return View(lanche);
        }

        public IActionResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lanche> lanches;
            string _categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(_searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);    
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(l => l.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel { Lanches = lanches, CategoriaAtual = "Todos os lanches" });
        }
    }
}
