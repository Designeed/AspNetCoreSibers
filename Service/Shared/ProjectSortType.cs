using System.ComponentModel.DataAnnotations;

namespace AspNetCoreSibers.Service.Shared
{
    public enum ProjectSortType
    {
        [Display(Name = "Имени")]
        Name,
        [Display(Name = "Дате начала")]
        StartDate,
        [Display(Name = "Дате окончания")]
        EndDate,
        [Display(Name = "Приоритету")]
        Priority,
    }
}
