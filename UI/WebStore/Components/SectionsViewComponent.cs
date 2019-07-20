using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using WebStore.Services.Map;

namespace WebStore.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public SectionsViewComponent(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        public IViewComponentResult Invoke(string sectionID)
        {
            var section_id = int.TryParse(sectionID, out var id) ? id : (int?)null;
            var sections = GetSections(section_id, out var parent_section_id);
            return View(new SectionCompleteViewModel            {
                Sections = sections,
                CurrentSectionId = section_id,
                CurrentParentSectionId = parent_section_id
            });
        }

        //public async Task<IViewComponentResult> InvokeAsync() { }

        private IEnumerable<SectionViewModel> GetSections(int? SectionId, out int? ParentSectionId)
        {
            ParentSectionId = null;
            var sections = _ProductData.GetSections();
            var parent_sections = sections
                .Where(section => section.ParentId == null)
                .Select(SectionViewModelMapper.CreateViewModel)
                .ToList();
            foreach (var parent_section in parent_sections)
            {
                var child_sections = sections
                    .Where(section => section.ParentId == parent_section.Id)
                    .Select(SectionViewModelMapper.CreateViewModel);
                parent_section.ChildSections.AddRange(child_sections);

                foreach (var child_section in child_sections)
                {
                    if (child_section.Id == SectionId)
                        ParentSectionId = parent_section.Id;
                    parent_section.ChildSections.Add(child_section);
                }
                parent_section.ChildSections.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            }           

            parent_sections.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            return parent_sections;
        }
    }
}
